using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories.Interfaces
{
    public interface ISlotFactory<T>
    {
        ISlot<T> EmptySlot();

        ISlot<T> FullSlot(T item);
    }
}
