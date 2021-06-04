namespace JCP.Catalog.Domain.OrderAggregate
{
    public enum OrderStatus
    {
        AwaitingStockValidation = 1,
        ConfirmedStockValidation = 2,
        RejectedStockValidation = 3
    }
}
