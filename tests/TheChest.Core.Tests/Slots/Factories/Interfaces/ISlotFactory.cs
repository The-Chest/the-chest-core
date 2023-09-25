using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories.Interfaces
{
    public interface ISlotFactory<T>
    {
        public ISlot<T> EmptySlot();

        public ISlot<T> FullSlot(T item);
    }
}
