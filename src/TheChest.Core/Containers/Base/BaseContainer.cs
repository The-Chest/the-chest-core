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
        public virtual ISlot<T>[] Slots
        {
            get;
            protected set;
        }

        public virtual ISlot<T> this[int index] => Slots[index];

        public virtual int Size => Slots.Length;

        public virtual bool IsFull => Slots.All(x => x.IsFull);

        public virtual bool IsEmpty => Slots.All(x => x.IsEmpty);

        /// <summary>
        /// Creates a Container with slots
        /// </summary>
        /// <param name="slots">An array of slots</param>
        protected BaseContainer(ISlot<T>[] slots)
        {
            Slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }
    }
}
