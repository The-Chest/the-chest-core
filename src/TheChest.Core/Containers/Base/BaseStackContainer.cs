using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers.Base
{
    public abstract class BaseStackContainer<T> : IStackContainer<T>
    {
        public IStackSlot<T>[] Slots { get; protected set; }

        public IStackSlot<T> this[int index] => this.Slots[index];

        public virtual bool IsFull => Slots?.All(x => x.IsFull) ?? false;

        public virtual bool IsEmpty => Slots?.All(x => x.IsEmpty) ?? true;

        public int Size => throw new NotImplementedException();


        protected BaseStackContainer(IStackSlot<T>[] slots)
        {
            this.Slots = slots;
        }
    }
}
