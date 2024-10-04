using TheChest.ConsoleApp.Items;
using TheChest.Core.Inventories.Slots;

namespace TheChest.ConsoleApp.Inventories.Stack
{
    public class InventoryStackSlot : InventoryStackSlot<Item>
    {
        public InventoryStackSlot(Item[] items) : base(items) { }
        public InventoryStackSlot(Item[] items, int maxStackAmount) : base(items, maxStackAmount) { }
    }
}
