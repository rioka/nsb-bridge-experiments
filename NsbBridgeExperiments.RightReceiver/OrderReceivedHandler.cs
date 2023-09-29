using NsbBridgeExperiments.Shared;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace NsbBridgeExperiments.RightReceiver;

public class OrderReceivedHandler :
  IHandleMessages<OrderReceived>
{
  static ILog log = LogManager.GetLogger<OrderReceivedHandler>();

  public Task Handle(OrderReceived message, IMessageHandlerContext context)
  {
    log.Info($"Subscriber has received OrderReceived event with OrderId {message.OrderId}.");
    return Task.CompletedTask;
  }
}