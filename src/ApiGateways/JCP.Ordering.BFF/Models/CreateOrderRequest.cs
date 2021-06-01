using System;

namespace JCP.Ordering.BFF.Models
{
    public class CreateOrderRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        //public Address address { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
        public OrderStatus Status { get; set; }
    }
}
