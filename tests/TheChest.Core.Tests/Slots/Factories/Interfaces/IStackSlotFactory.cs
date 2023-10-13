using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories.Interfaces
{
    public interface IStackSlotFactory<T>
    {
        public IStackSlot<T> EmptySlot();

        public IStackSlot<T> WithItem(T item, int amount = 1, int maxAmount = 10);

        public IStackSlot<T> FullSlot(T item);
    }
}
