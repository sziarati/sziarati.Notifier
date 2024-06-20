using MassTransit;
using System.Reflection;

namespace Notifier
{
    public static class DependencyInjections
    {
        public static IServiceCollection RegisterMessageBroker(this IServiceCollection services, IConfiguration configuration)
        {
            var configs = configuration.Get<AppSettings>();

            services.AddMassTransit(x =>
            {
                var rabbitConfigs = configs.RabbitMqConfiguration;

                x.AddConsumers(typeof(INotifierAssembly).Assembly);

                x.UsingRabbitMq((context, config) =>
                {
                    config.UseRawJsonDeserializer();
                    config.Host(rabbitConfigs.Host, hostConfig =>
                    {
                        hostConfig.Username(rabbitConfigs.Username);
                        hostConfig.Password(rabbitConfigs.Password);
                    });
                    config.ConfigureEndpoints(context);
                });
            });

            services.AddMassTransitHostedService();

            return services;
        }
        public static IServiceCollection RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
