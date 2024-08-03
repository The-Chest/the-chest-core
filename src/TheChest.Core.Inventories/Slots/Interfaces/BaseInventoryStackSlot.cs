using TheChest.Core.Inventories.Slots.Base;
using TheChest.Core.Slots;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Slots.Interfaces
{
    /// <summary>
    /// Generic Slot with with <see cref="IInventoryStackSlot{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    [Obsolete("Class is not implemented")]
    public abstract class BaseInventoryStackSlot<T> : StackSlot<T>, IInventoryStackSlot<T>
    {
        protected BaseInventoryStackSlot(T[] items) : base(items)
        {
        }

        T ISlot<T>.Content => throw new NotImplementedException();

        public int Add(T item, int amount)
        {
            throw new NotImplementedException();
        }

        public int Add(T[] items)
        {
            throw new NotImplementedException();
        }

        public bool Add(T item)
        {
            throw new NotImplementedException();
        }

        public T[] GetAll()
        {
            throw new NotImplementedException();
        }

        public T[] GetAmount(int amount)
        {
            throw new NotImplementedException();
        }

        public T GetOne()
        {
            throw new NotImplementedException();
        }

        public T[] Replace(T item, int amount)
        {
            throw new NotImplementedException();
        }

        public T[] Replace(T[] items)
        {
            throw new NotImplementedException();
        }

        public T Replace(T item)
        {
            throw new NotImplementedException();
        }
    }
}
