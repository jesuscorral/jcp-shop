using BuildingBlocks.EventBus.Events;
using JCP.Catalog.Domain.OrderAggregate;
using System;

namespace JCP.Ordering.Application.IntegrationEvents.Events
{
    public record OrderCreatedAwaitingStockValidationIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; }

        public string Name { get; }

        public string UserId { get; init; }
        public string Username { get; init; }
        public int CardTypeId { get; init; }
        public string CardNumber { get; init; }
        public OrderStatus Status { get; init; }

        public OrderCreatedAwaitingStockValidationIntegrationEvent(Guid orderId, string name, string userId, string username, int cardTypeId, string cardNumber, OrderStatus status)
        {
            OrderId = orderId;
            Name = name;
            UserId = userId;
            Username = username;
            CardTypeId = cardTypeId;
            CardNumber = cardNumber;
            Status = status;
        }
    }
}
