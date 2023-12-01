namespace RealTimeFraudSight.Domain
{
    public class CustomerProfile
    {
        public Guid CustomerID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string BillingAddress { get; set; }
        public required string ShippingAddress { get; set; }
        public required IList<InventoryItem> OrderHistory { get; set; }
        public int PaymentMethods { get; set; }
        public required IList<string> Preferences { get; set; }
        public int LoyaltyPoints { get; set; }
        public int AccountStatus { get; set; }
    }
}