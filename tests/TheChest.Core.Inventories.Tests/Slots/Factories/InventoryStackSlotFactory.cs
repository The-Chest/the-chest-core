using TheChest.Core.Tests.Slots.Factories;
using TheChest.Core.Inventories.Slots.Interfaces;
using TheChest.Core.Inventories.Slots;

namespace TheChest.Core.Inventories.Tests.Slots.Factories
{
    public class InventoryStackSlotFactory<Slot, Item> : StackSlotFactory<Slot, Item>, IInventoryStackSlotFactory<Item>
        where Slot : InventoryStackSlot<Item>
    {
        public IInventoryStackSlot<Item> EmptySlot(int maxAmount = 10)
        {
            var type = typeof(Slot);
            var slot = Activator.CreateInstance(type, Array.Empty<Item>(), maxAmount);
            return (IInventoryStackSlot<Item>)slot!;
        }

        public IInventoryStackSlot<Item> FullSlot(Item[] items)
        {
            var type = typeof(Slot);

            var slot = Activator.CreateInstance(type, items, items.Length);
            return (IInventoryStackSlot<Item>)slot!;
        }

        public IInventoryStackSlot<Item> WithItems(Item[] items, int maxAmount = 10)
        {
            var type = typeof(Slot);

            var slot = Activator.CreateInstance(type, items, maxAmount);
            return (IInventoryStackSlot<Item>)slot!;
        }

        public override IInventoryStackSlot<Item> EmptySlot()
        {
            var type = typeof(Slot);
            var slot = Activator.CreateInstance(type, Array.Empty<Item>(), 10);
            return (IInventoryStackSlot<Item>)slot!;
        }

        public override IInventoryStackSlot<Item> FullSlot(Item item)
        {
            var type = typeof(Slot);

            var size = new Random().Next(1, 10);
            var items = new Item[size];
            Array.Fill(items, item);

            var slot = Activator.CreateInstance(type, items, size);
            return (IInventoryStackSlot<Item>)slot!;
        }

        public override IInventoryStackSlot<Item> WithItem(Item item, int amount, int maxAmount)
        {
            var type = typeof(Slot);
            var items = new Item[amount];
            Array.Fill(items, item);

            var slot = Activator.CreateInstance(type, items, maxAmount);
            return (IInventoryStackSlot<Item>)slot!;
        }
    }
}
        