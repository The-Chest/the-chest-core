using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Inventories.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Containers.Base
{
    /// <summary>
    /// Generic Inventory with <see cref="IStackInventory{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    [Obsolete("Not implemented")]
    public abstract class BaseStackInventory<T> : BaseInventory<T>, IStackInventory<T>
    {
        protected BaseStackInventory(ISlot<T>[] slots) : base(slots)
        {
        }

        IStackSlot<T> IStackContainer<T>.this[int index] => throw new NotImplementedException();

        IStackSlot<T>[] IStackContainer<T>.Slots => throw new NotImplementedException();

        public T[] AddItemAt(T item, int index, int amount, bool replace = true)
        {
            throw new NotImplementedException();
        }

        public T[] AddItemAt(T[] items, int index, bool replace = true)
        {
            throw new NotImplementedException();
        }

        public T[] GetAll(int index)
        {
            throw new NotImplementedException();
        }

        public T[] GetItemAmount(int index, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
