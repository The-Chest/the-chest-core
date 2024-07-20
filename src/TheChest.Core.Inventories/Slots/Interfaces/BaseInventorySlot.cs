using TheChest.Core.Inventories.Slots.Base;
using TheChest.Core.Inventories.Slots.Enums;
using TheChest.Core.Slots;

namespace TheChest.Core.Inventories.Slots.Interfaces
{
    /// <summary>
    /// Generic Slot with with <see cref="IInventorySlot{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public abstract class BaseInventorySlot<T> : Slot<T>, IInventorySlot<T>
    {
        public virtual bool Add(T item)
        {
            var eq = Content?.Equals(item) ?? false;
            if (IsEmpty || eq && !IsFull)
            {
                Content = item;
                return true;
            }

            return false;
        }

        public virtual T Replace(T item)
        {
            throw new NotImplementedException();
        }

        public virtual T? GetOne()
        {
            if (IsEmpty)
                return default;

            T item = Content;
            Content = default;

            return item;
        }
    }
}
