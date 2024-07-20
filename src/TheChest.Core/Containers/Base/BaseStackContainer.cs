using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers.Base
{
    public abstract class BaseStackContainer<T> : IStackContainer<T>
    {
        public IStackSlot<T>[] Slots { get; protected set; }

        public IStackSlot<T> this[int index] => this.Slots[index];

        public virtual bool IsFull  => this.Slots.All(x => x.IsFull);

        public virtual bool IsEmpty => this.Slots.All(x => x.IsEmpty);

        public int Size => this.Slots.Length;

        protected BaseStackContainer(IStackSlot<T>[] slots)
        {
            this.Slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }
    }
}
