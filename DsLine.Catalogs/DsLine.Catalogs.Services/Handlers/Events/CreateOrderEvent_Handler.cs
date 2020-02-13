using DsLine.Catalogs.Services.IntegrationMessages.Events;
using DsLine.Core.Handlers;
using DsLine.Core.RabbitMQ;
using System;
using System.Threading.Tasks;

namespace DsLine.Catalogs.Services.Handlers.Events
{
    public class CreateOrderEvent_Handler : IEventHandler<CreateOrderEvent>
    {
        public CreateOrderEvent_Handler(IBusPublisher busPublisher)
        {
            var subs = busPublisher;
        }
        public async Task HandleAsync(CreateOrderEvent command, ICorrelationContext context)
        {
            Console.WriteLine($"Creating an order discount, value: '{command.Products}%'");
            //   return Task.CompletedTask;

        }
    }
}
