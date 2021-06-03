namespace JCP.Ordering.BFF.Config
{
    public class UrlsConfig
    {
        public class OrdersOperations
        {
            public static string CreateOrder() => "/Order";
        }

        public string Orders { get; set; }

        public string GrpcCatalog { get; set; }
    }
}
