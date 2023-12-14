namespace RealTimeFraudSight.Domain
{
    public class PaymentDetails
    {
        public required string CardNumber { get; set; }
        public required string ExpiryDate { get; set; }
        public required string CVV { get; set; }        
    }
}