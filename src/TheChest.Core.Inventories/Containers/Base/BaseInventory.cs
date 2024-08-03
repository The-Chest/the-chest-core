using TheChest.Core.Containers;
using TheChest.Core.Inventories.Containers.Interfaces;
using TheChest.Core.Inventories.Slots.Base;
using TheChest.Core.Slots;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Containers.Base
{
    /// <summary>
    /// Generic Inventory with <see cref="IInventory{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    [Obsolete("Not implemented")]
    public abstract class BaseInventory<T> : Container<T>, IInventory<T>
    {
        protected BaseInventory(ISlot<T>[] slots) : base(slots)
        {
        }

        public T[] AddItem(T item, int amount)
        {
            throw new NotImplementedException();
        }

        public T[] AddItem(T[] items)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(T item)
        {
            throw new NotImplementedException();
        }

        public T AddItemAt(T item, int index, bool replace = true)
        {
            throw new NotImplementedException();
        }

        public T[] Clear()
        {
            throw new NotImplementedException();
        }

        public T[] GetAll(T item)
        {
            throw new NotImplementedException();
        }

        public T GetItem(int index)
        {
            throw new NotImplementedException();
        }

        public T GetItem(T item)
        {
            throw new NotImplementedException();
        }

        public T[] GetItemAmount(T item, int amount = 1)
        {
            throw new NotImplementedException();
        }

        public int GetItemCount(T item)
        {
            throw new NotImplementedException();
        }

        public bool MoveItem(int origin, int target)
        {
            throw new NotImplementedException();
        }
    }
}
