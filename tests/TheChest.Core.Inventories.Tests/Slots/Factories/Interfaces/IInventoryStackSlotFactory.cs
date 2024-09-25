using TheChest.Core.Inventories.Slots.Interfaces;

namespace TheChest.Core.Inventories.Tests.Slots.Factories.Interfaces
{
    public interface IInventoryStackSlotFactory<T> : IStackSlotFactory<T>
    {
        new IInventoryStackSlot<T> EmptySlot();
        new IInventoryStackSlot<T> WithItem(T item, int amount = 1, int maxAmount = 10);
        IInventoryStackSlot<T> WithItems(T[] items, int maxAmount = 10);
        new IInventoryStackSlot<T> FullSlot(T item);
        IInventoryStackSlot<T> FullSlot(T[] items);
    }
}
