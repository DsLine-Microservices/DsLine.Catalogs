using DsLine.Core.Messages;
using Newtonsoft.Json;
using System;

namespace DsLine.Catalogs.Services.IntegrationMessages.Events
{
    public class CreateOrderEvent : IEvent
    {
        public Guid Id { get; }
        public int CustomerId { get; }
        public int Products { get; }

        [JsonConstructor]
        public CreateOrderEvent(Guid id, int customerId, int products)
        {
            Id = id;
            CustomerId = customerId;
            Products = products;
        }
    }
}

