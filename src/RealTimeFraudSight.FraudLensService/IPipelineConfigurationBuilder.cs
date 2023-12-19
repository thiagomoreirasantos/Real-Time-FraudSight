namespace RealTimeFraudSight.FraudLensService
{
    public interface IPipelineConfigurationBuilder
    {
        IPipelineConfigurationBuilder AddPipeline(Action<IFlowKeeperBuilder> action);
    }
}