namespace RealTimeFraudSight.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public required IList<InventoryItem> Items { get; set; }
        public decimal TotalAmount { get; set; }    
        public required string ShippingAddress { get; set; }
        public required string BillingAddress { get; set; }
        public int PaymentMethod { get; set; }
        public int OrderStatus { get; set; }
        public int ShippingMethod { get; set; }
        public required string TrackingNumber { get; set; }
        public required string CustomerNotes { get; set; }

        public bool CheckStatus()
        {
            return this.OrderStatus == 1;
        }

        public bool CheckPayment()
        {
            return this.PaymentMethod == 1;
        }

        public decimal CalculateTotal()
        {
            return this.Items.Sum(x => x.Price);
        }        

        public void AddItem(InventoryItem item)
        {
            this.Items.Add(item);
        }   

        public void RemoveItem(InventoryItem item)
        {
            this.Items.Remove(item);
        }

        public void UpdateOrder(DateTime orderDate, decimal totalAmount, string shippingAddress, string billingAddress, int paymentMethod, int orderStatus, int shippingMethod, string trackingNumber, string customerNotes)
        {
            this.OrderDate = orderDate;
            this.TotalAmount = totalAmount;
            this.ShippingAddress = shippingAddress;
            this.BillingAddress = billingAddress;
            this.PaymentMethod = paymentMethod;
            this.OrderStatus = orderStatus;
            this.ShippingMethod = shippingMethod;
            this.TrackingNumber = trackingNumber;
            this.CustomerNotes = customerNotes;
        }           

        public void CancelOrder()
        {
            this.OrderStatus = 2;
        }
    }
}