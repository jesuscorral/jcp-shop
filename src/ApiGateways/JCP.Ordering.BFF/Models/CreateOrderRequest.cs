using System.Text.Json.Serialization;

namespace JCP.Ordering.BFF.Models
{
    public class CreateOrderRequest
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int CardTypeId { get; set; }

        public string CardNumber { get; set; }

        [JsonIgnore]
        public OrderStatus Status { get; set; }
    }
}
