using TheChest.Core.Inventories.Slots.Interfaces;
using TheChest.Core.Slots;
using TheChest.Core.Tests.Slots.Factories;

namespace TheChest.Core.Inventories.Tests.Slots.Factories
{
    public class InventorySlotFactory<Slot, Item> : SlotFactory<Slot, Item>, IInventorySlotFactory<Item> 
        where Slot : Slot<Item>
    {
        public override IInventorySlot<Item> EmptySlot()
        {
            var slot = Activator.CreateInstance(typeof(Slot), default(Item));
            return (IInventorySlot<Item>)slot!;
        }

        public override IInventorySlot<Item> FullSlot(Item item)
        {
            var constructor = typeof(Slot).GetConstructor(new Type[1] { typeof(Item?) });
            var slot = constructor!.Invoke(new object[1] { item });
            return (IInventorySlot<Item>)slot;
        }
    }
}
