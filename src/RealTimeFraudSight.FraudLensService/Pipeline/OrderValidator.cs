using RealTimeFraudSight.Domain;

namespace RealTimeFraudSight.FraudLensService
{
    public class OrderValidator : Flowkeeper
    {
        private Dictionary<Guid, InventoryItem> inventory;

        public OrderValidator(Dictionary<Guid, InventoryItem> inventory)
        {
            this.inventory = inventory;
        }
        protected override Task<FlowContext> ExecutePipeline(FlowContext context)
        {
            foreach (var item in context.Items)
            {
                if (!inventory.ContainsKey(item.ItemId) || inventory[item.ItemId].QuantityInStock < item.QuantityInStock)
                {
                    Console.WriteLine($"Item {item.ItemId} não está disponível em quantidade suficiente.");
                }
            }
            return Task.FromResult(context);
        }
    }
}