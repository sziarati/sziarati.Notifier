namespace Notifier
{
    public class AppSettings
    {
        public FeatureConfiguration FeatureConfiguration { get; set; }
        public Connection Connection { get; set; }
        public RabbitMqConfiguration RabbitMqConfiguration { get; set; }
    }
    public class FeatureConfiguration
    {
        public SmsConfiguration SmsConfiguration { get; set; }
    }
    public class SmsConfiguration
    {
        public Farapayamak Farapayamak { get; set; }
    }
    public class Farapayamak
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }

    }
    public class Connection
    {
        public string Host { get; set; }
        public string DatabaseName { get; set; }
    }
    public class RabbitMqConfiguration
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
