using NsbBridgeExperiments.Shared;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace NsbBridgeExperiments.RightReceiver;

public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
{
  public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
  {
    Console.WriteLine($"Received {nameof(PlaceOrder)} Command with Id {message.OrderId}");

    await context.Reply(new OrderResponse { OrderId = message.OrderId }).ConfigureAwait(false);
  }
}