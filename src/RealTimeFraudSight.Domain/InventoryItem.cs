namespace RealTimeFraudSight.Domain
{
    public class InventoryItem
    {
        public Guid ItemId { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int ReorderLevel { get; set; }
        public Guid SupplierId { get; set; }
        public double Weight { get; set; }
        public double Dimensions { get; set; }
        public bool Discontinued { get; set; }
    }
}