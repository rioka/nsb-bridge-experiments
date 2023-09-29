using NsbBridgeExperiments.Shared;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace NsbBridgeExperiments.LeftSender;

static class Program
{
  private static readonly string ConnectionString = @"Server=(localdb)\MSsqlLocalDb;Initial Catalog=Samples.Bridge.Left;Integrated Security=true";
  
  static async Task Main()
  {
    Console.Title = "Samples.Bridge.LeftSender";
    
    SqlHelper.EnsureDatabaseExists(ConnectionString);
    
    var endpointConfiguration = new EndpointConfiguration("Samples.Bridge.LeftSender");

    endpointConfiguration.Conventions().DefiningCommandsAs(t => t.Name == nameof(PlaceOrder));
    endpointConfiguration.Conventions().DefiningMessagesAs(t => t.Name == nameof(OrderResponse));
    endpointConfiguration.Conventions().DefiningEventsAs(t => t.Name == nameof(OrderReceived));

    var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
    transport
      .Transactions(TransportTransactionMode.TransactionScope)
      .ConnectionString(ConnectionString);
    transport
      .Routing()
      .RouteToEndpoint(typeof(PlaceOrder), "Samples.Bridge.RightReceiver");

    endpointConfiguration.AuditProcessedMessagesTo("audit");
    endpointConfiguration.SendFailedMessagesTo("error");
    endpointConfiguration.EnableInstallers();

    var endpointInstance = await Endpoint
      .Start(endpointConfiguration)
      .ConfigureAwait(false);

    await Start(endpointInstance)
      .ConfigureAwait(false);

    await endpointInstance.Stop()
      .ConfigureAwait(false);
  }

  static async Task Start(IEndpointInstance endpointInstance)
  {
    Console.WriteLine("Press '1' to send the PlaceOrder command");
    Console.WriteLine("Press '2' to publish the OrderReceived event");
    Console.WriteLine("Press 'esc' other key to exit");

    while (true)
    {
      var key = Console.ReadKey();
      Console.WriteLine();

      var orderId = Guid.NewGuid();
      switch (key.Key)
      {
        case ConsoleKey.D1:
          var placeOrder = new PlaceOrder {
            OrderId = orderId
          };
          await endpointInstance.Send(placeOrder)
            .ConfigureAwait(false);
          Console.WriteLine($"Send PlaceOrder Command with Id {orderId}");
          break;
        
        case ConsoleKey.D2:
          var orderReceived = new OrderReceived {
            OrderId = orderId
          };
          await endpointInstance.Publish(orderReceived)
            .ConfigureAwait(false);
          Console.WriteLine($"Published OrderReceived Event with Id {orderId}.");
          break;
        
        case ConsoleKey.Escape:
        default:  
          return;
      }
    }
  }
}