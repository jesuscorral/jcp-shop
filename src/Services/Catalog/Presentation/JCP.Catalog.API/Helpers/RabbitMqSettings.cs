namespace JCP.Catalog.API.Helpers
{
    public class RabbitMqSettings
    {
        public string Hostname { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public int RetryCount { get; set; }
    }
}
