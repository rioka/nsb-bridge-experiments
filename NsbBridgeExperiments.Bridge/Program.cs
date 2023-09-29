using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NsbBridgeExperiments.Shared;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace NsbBridgeExperiments.Bridge;

internal static class Program
{
  internal static async Task Main()
  {
    Console.Title = "Samples.Bridge";

    await Host.CreateDefaultBuilder()
      .ConfigureLogging(logging => {
        logging.ClearProviders();
        logging.AddSimpleConsole(options => {
          options.IncludeScopes = false;
          options.SingleLine = true;
          options.TimestampFormat = "hh:mm:ss ";
        });
      })
      .UseNServiceBusBridge((ctx, bridgeConfiguration) => {

        #region Bridged transport for "left" side

        var leftSqlTransport = new SqlServerTransport(@"Server=(localdb)\MSsqlLocalDb;Initial Catalog=Samples.Bridge.Left;Integrated Security=true") ;
        var leftBridgeTransport = new BridgeTransport(leftSqlTransport) {
          Name = "sql-left",
          AutoCreateQueues = true
        };
        leftBridgeTransport.HasEndpoint("Samples.Bridge.LeftSender");

        #endregion

        #region Bridged transport for "right" side
        
        var rightSqlTransport = new SqlServerTransport(@"Server=(localdb)\ProjectsV13;Initial Catalog=Samples.Bridge.Right;Integrated Security=true");
        var rightBridgeTransport = new BridgeTransport(rightSqlTransport) {
          Name = "sql-right",
          AutoCreateQueues = true
        };

        var rightReceiver = new BridgeEndpoint("Samples.Bridge.RightReceiver");
        rightReceiver.RegisterPublisher(typeof(OrderReceived), "Samples.Bridge.LeftSender");

        #endregion

        rightBridgeTransport.HasEndpoint(rightReceiver);

        #region Add transports to bridge

        bridgeConfiguration.AddTransport(leftBridgeTransport);
        bridgeConfiguration.AddTransport(rightBridgeTransport);
        
        bridgeConfiguration.RunInReceiveOnlyTransactionMode();
        
        #endregion
      })
      .Build()
      .RunAsync().ConfigureAwait(false);
  }
}