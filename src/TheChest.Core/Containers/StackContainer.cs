using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers
{
    public class StackContainer<T> : IStackContainer<T>
    {
        public IStackSlot<T>[] Slots { get; protected set; }

        public IStackSlot<T> this[int index] => Slots[index];

        public virtual bool IsFull => Slots.All(x => x.IsFull);

        public virtual bool IsEmpty => Slots.All(x => x.IsEmpty);

        public int Size => Slots.Length;

        public StackContainer(IStackSlot<T>[] slots)
        {
            Slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }
    }
}
