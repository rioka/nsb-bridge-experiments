using NsbBridgeExperiments.Shared;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace NsbBridgeExperiments.TopReceiver;

internal static class Program
{
  private static readonly string ConnectionString = @"Server=localhost,1455;Initial Catalog=Samples.Bridge.Top;User ID=sa;Password=StrongP@assw0rd;Encrypt=false";
  
  internal static async Task Main()
  {
    Console.Title = "Samples.Bridge.TopReceiver";
    
    SqlHelper.EnsureDatabaseExists(ConnectionString);
    
    var endpointConfiguration = new EndpointConfiguration("Samples.Bridge.TopReceiver");

    endpointConfiguration.Conventions().DefiningEventsAs(t => t.Name == "OrderReceived");

    var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
    transport
      .Transactions(TransportTransactionMode.TransactionScope)
      .ConnectionString(ConnectionString);

    endpointConfiguration.AuditProcessedMessagesTo("audit");
    endpointConfiguration.SendFailedMessagesTo("error");
    endpointConfiguration.EnableInstallers();

    var endpointInstance = await Endpoint
      .Start(endpointConfiguration)
      .ConfigureAwait(false);

    Console.WriteLine("Press any key to exit");
    Console.ReadKey();

    await endpointInstance
      .Stop()
      .ConfigureAwait(false);
  }
}