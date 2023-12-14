
using RealTimeFraudSight.Domain;

namespace RealTimeFraudSight.FraudLensService
{
    public class FlowContext
    {
        private List<FlowError> errors = new List<FlowError>();
        private Dictionary<string, object> bucket = new Dictionary<string, object>();

        public FlowContext(IMessageFlowContext context)
        {
            this.MessageFlowContext = context;
        }

        public Guid OrderId { get; internal set; }
        public Guid CustomerId { get; internal set; }
        public DateTime OrderDate { get; internal set; }
        public required IList<InventoryItem> Items { get; set; }
        public int TotalAmount { get; internal set; }
        public required string ShippingAddress { get; set; }
        public required string BillingAddress { get; set; }
        public int PaymentMethod { get; internal set; }
        public required PaymentDetails PaymentDetails { get; set; }
        public int OrderStatus { get; internal set; }
        public int ShippingMethod { get; internal set; }
        public required string TrackingNumber { get; set; }
        public required string CustomerNotes { get; set; }
        public IMessageFlowContext MessageFlowContext { get; }
        public IReadOnlyCollection<FlowError> Errors => (IReadOnlyCollection<FlowError>)this.errors.AsReadOnly();
        public List<Order> AddressChanges { get; internal set; } = new List<Order>();

        public void AddError(FlowError error) => this.errors.Add(error);
        public void AddError(Exception exception)
        {
            this.errors.Add(new FlowError() { Code = exception.GetType().Name, Message = exception.Message, StackTrace = exception.StackTrace ?? string.Empty });
        }
        public void AddToBucket(string key, object value) => this.bucket.Add(key, value);
    }
}