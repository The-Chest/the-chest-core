using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots.Base
{
    /// <summary>
    /// Generic Slot with with <see cref="ISlot{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public abstract class BaseSlot<T> : ISlot<T>
    {
        public virtual T Item { get; protected set; }

        public virtual bool IsFull => !IsEmpty;

        public virtual bool IsEmpty => Item == null;

        /// <summary>
        /// Creates a basic slot with an item
        /// </summary>
        /// <param name="currentItem">item that belongs to this slot (null if empty)</param>
        protected BaseSlot(T currentItem = default)
        {
            Item = currentItem;
        }
    }
}
