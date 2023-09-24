using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Generics.Factories
{
    public interface ISlotFactory<T>
    {
        public ISlot<T> EmptySlot();

        public ISlot<T> FullSlot(T item);
    }
}
