using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers.Base
{
    /// <summary>
    /// Generic container with <see cref="IContainer{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public abstract class BaseContainer<T> : IContainer<T>
    {
        protected const int DEFAULT_SLOT_COUNT = 20;

        public virtual ISlot<T>[] Slots
        {
            get;
            protected set;
        }

        public virtual ISlot<T> this[int index] => Slots[index];

        public virtual int Size => Slots?.Length ?? 0;

        public virtual bool IsFull => Slots?.All(x => x.IsFull) ?? false;

        public virtual bool IsEmpty => Slots?.All(x => x.IsEmpty) ?? true;

        /// <summary>
        /// Creates a Container with slots
        /// </summary>
        /// <param name="slots">An array of slots</param>
        protected BaseContainer(ISlot<T>[] slots)
        {
            Slots = slots;
        }

        /// <summary>
        /// Creates a Container with a number of slots
        /// </summary>
        /// <param name="size">Sets the amount of slots (20 if not set)</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected BaseContainer(int size = DEFAULT_SLOT_COUNT)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), $"Invalid Container Size : {size}");
            }
            Slots = new ISlot<T>[size];
        }
    }
}
