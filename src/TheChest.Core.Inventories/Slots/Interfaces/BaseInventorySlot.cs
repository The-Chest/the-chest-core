using TheChest.Core.Inventories.Slots.Base;
using TheChest.Core.Slots;

namespace TheChest.Core.Inventories.Slots.Interfaces
{
    /// <summary>
    /// Generic Slot with with <see cref="IInventorySlot{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public abstract class BaseInventorySlot<T> : Slot<T>, IInventorySlot<T>
    {
        public bool Add(T item)
        {
            throw new NotImplementedException();
        }

        public T GetOne()
        {
            throw new NotImplementedException();
        }

        public T Replace(T item)
        {
            throw new NotImplementedException();
        }
    }
}
