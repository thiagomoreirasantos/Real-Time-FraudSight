
using RealTimeFraudSight.Domain;

namespace RealTimeFraudSight.FraudLensService.Pipeline
{    
    public class PaymentProcessor : Flowkeeper
    {
        protected override Task<FlowContext> ExecutePipeline(FlowContext context)
        {
            Console.WriteLine($"Processando pagamento para o pedido {context.OrderId}");

            // Esta é uma simulação; na prática, você chamaria um serviço externo aqui
            bool isSuccess = CallExternalPaymentService(context, context.PaymentDetails);

            if (!isSuccess)
            {
                context.AddError(new Exception("Falha ao processar o pagamento"));
            }

            return Task.FromResult(context);

        }

        private bool CallExternalPaymentService(FlowContext context, PaymentDetails paymentDetails)
        {
            return true;
        }
    }
}