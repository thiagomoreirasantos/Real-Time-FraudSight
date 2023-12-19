using RealTimeFraudSight.FraudLensService;

namespace RealTimeFraudSight.Dispatcher.Extensions
{
    public static class FlowSettingsExtension
    {
        public static IServiceCollection AddFlowPipeline(this IServiceCollection services, Action<IFlowKeeperBuilder> action)
        {
            return services;
        }
    }
}