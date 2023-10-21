using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories.Interfaces
{
    public interface IStackSlotFactory<T>
    {
        IStackSlot<T> EmptySlot();

        IStackSlot<T> WithItem(T item, int amount = 1, int maxAmount = 10);

        IStackSlot<T> FullSlot(T item);
    }
}
