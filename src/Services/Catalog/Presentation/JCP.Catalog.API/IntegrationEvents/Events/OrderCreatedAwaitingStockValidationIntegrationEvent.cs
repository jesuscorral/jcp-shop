using BuildingBlocks.EventBus.Events;
using System;

namespace JCP.Catalog.API.IntegrationEvents.Events
{
    public record OrderCreatedAwaitingStockValidationIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; }

        public string Name { get; }

        public string UserId { get; init; }
        public string Username { get; init; }
        public int CardTypeId { get; init; }
        public string CardNumber { get; init; }

        public OrderCreatedAwaitingStockValidationIntegrationEvent(Guid orderId, string name, string userId, string username, int cardTypeId, string cardNumber)
        {
            OrderId = orderId;
            Name = name;
            UserId = userId;
            Username = username;
            CardTypeId = cardTypeId;
            CardNumber = CardNumber;
        }
    }
}
