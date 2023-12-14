namespace RealTimeFraudSight.FraudLensService
{
    public class FraudDetector : Flowkeeper
    {
        private decimal HighAmountThreshold = 10000;
        private TimeSpan ShortOrderInterval = TimeSpan.FromMinutes(30);
        private Dictionary<Guid, DateTime> LastOrderTimes = new Dictionary<Guid, DateTime>();

        protected override Task<FlowContext> ExecutePipeline(FlowContext context)
        {
            if (context.TotalAmount > HighAmountThreshold)
            {
                Console.WriteLine("Alerta de fraude: valor do pedido muito alto.");                
            }
            
            if (LastOrderTimes.ContainsKey(context.OrderId))
            {
                var lastOrderTime = LastOrderTimes[context.CustomerId];
                if ((context.OrderDate - lastOrderTime) < ShortOrderInterval)
                {
                    Console.WriteLine("Alerta de fraude: pedidos muito frequentes.");                    
                }
            }
            LastOrderTimes[context.CustomerId] = context.OrderDate;     

            return Task.FromResult(context) ;           
        }
    }
}