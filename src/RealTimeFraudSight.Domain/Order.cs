namespace RealTimeFraudSight.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public required IList<InventoryItem> Items { get; set; }
        public int TotalAmount { get; set; }    
        public required string ShippingAddress { get; set; }
        public required string BillingAddress { get; set; }
        public int PaymentMethod { get; set; }
        public int OrderStatus { get; set; }
        public int ShippingMethod { get; set; }
        public required string TrackingNumber { get; set; }
        public required string CustomerNotes { get; set; }
    }
}