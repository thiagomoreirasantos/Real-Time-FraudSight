
namespace RealTimeFraudSight.FraudLensService.Pipeline
{
    public class CustomerProfileFraudDetector : Flowkeeper
    {
        private const int SuspiciousAddressChangeLimit = 3;

        protected override Task<FlowContext> ExecutePipeline(FlowContext context)
        {
            if (CountRecentAddressChanges(context) > SuspiciousAddressChangeLimit)
            {
                Console.WriteLine($"Perfil suspeito detectado para o cliente {context.CustomerId}.");                
            }

            return Task.FromResult(context);
        }

        private int CountRecentAddressChanges(FlowContext profile)
        {
            return profile.AddressChanges.Count(a => a.OrderDate > DateTime.Now.AddDays(-30));
        }
    }
}