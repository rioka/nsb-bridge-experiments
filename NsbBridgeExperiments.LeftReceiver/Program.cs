using NsbBridgeExperiments.Shared;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace NsbBridgeExperiments.LeftReceiver;

static class Program
{
  private static readonly string ConnectionString = @"Server=(localdb)\MSsqlLocalDb;Initial Catalog=Samples.Bridge.Left;Integrated Security=true";
  
  static async Task Main()
  {
    Console.Title = "Samples.Bridge.LeftReceiver";
    
    SqlHelper.EnsureDatabaseExists(ConnectionString);
    
    var endpointConfiguration = new EndpointConfiguration("Samples.Bridge.LeftReceiver");
   
    var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
    transport
      .Transactions(TransportTransactionMode.TransactionScope)
      .ConnectionString(ConnectionString);

    endpointConfiguration.Conventions().DefiningEventsAs(t => t.Name == nameof(OrderReceived));

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