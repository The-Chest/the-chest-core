using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories
{
    public abstract class SlotFactory<T>
    {
        public abstract ISlot<T> EmptySlot();

        public abstract ISlot<T> FullSlot(T item);
    }
}
