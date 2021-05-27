using System;

namespace JCP.Catalog.Domain.OrderAggregate
{
    // TODO : Extend : AuditableEntity when AuditableEntity will be a accesible from crosscuting project
    public class Order
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        //public Address address { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
    }
}
