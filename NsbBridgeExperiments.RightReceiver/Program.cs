using NsbBridgeExperiments.Shared;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace NsbBridgeExperiments.RightReceiver;

internal static class Program
{
  private static readonly string ConnectionString = @"Server=(localdb)\ProjectsV13;Initial Catalog=Samples.Bridge.Right;Integrated Security=true";
  
  internal static async Task Main()
  {
    Console.Title = "Samples.Bridge.RightReceiver";
    
    SqlHelper.EnsureDatabaseExists(ConnectionString);
    
    var endpointConfiguration = new EndpointConfiguration("Samples.Bridge.RightReceiver");

    endpointConfiguration.Conventions().DefiningCommandsAs(t => t.Name == nameof(PlaceOrder));
    endpointConfiguration.Conventions().DefiningMessagesAs(t => t.Name == nameof(OrderResponse));
    endpointConfiguration.Conventions().DefiningEventsAs(t => t.Name == nameof(OrderReceived));

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