
using RealTimeFraudSight.Domain;

namespace RealTimeFraudSight.FraudLensService.Pipeline
{
    public class Parse : Flowkeeper
    {
        protected override async Task<FlowContext> ExecutePipeline(FlowContext context)
        {
            try
            {
                await Task.CompletedTask;

                var order = new Order
                {
                    OrderId = context.OrderId,
                    CustomerId = context.CustomerId,
                    OrderDate = context.OrderDate,
                    Items = context.Items,
                    TotalAmount = context.TotalAmount,
                    ShippingAddress = context.ShippingAddress,
                    BillingAddress = context.BillingAddress,
                    PaymentMethod = context.PaymentMethod,
                    OrderStatus = context.OrderStatus,
                    ShippingMethod = context.ShippingMethod,
                    TrackingNumber = context.TrackingNumber,
                    CustomerNotes = context.CustomerNotes
                };

                context.AddToBucket("order", order);

            }
            catch (Exception ex)
            {
                context.AddError(ex);
            }     

            return context;       
        }
    }
}