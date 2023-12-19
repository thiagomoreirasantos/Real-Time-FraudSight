using RealTimeFraudSight.FraudLensService.Context;

namespace RealTimeFraudSight.FraudLensService
{
    public interface IFlowKeeperBuilder
    {
        IFlowKeeperBuilder AddFlowkeeper<T>() where T : Flowkeeper;
    }
}