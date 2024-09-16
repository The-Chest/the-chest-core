using TheChest.Core.Slots;

namespace TheChest.Core.Inventories.Slots
{
    public class InventoryStackSlot<T> : StackSlot<T>
    {
        public InventoryStackSlot(T[] items) : base(items) { }

        public InventoryStackSlot(T[] items, int maxStackAmount) : base(items, maxStackAmount) { }
    }
}
