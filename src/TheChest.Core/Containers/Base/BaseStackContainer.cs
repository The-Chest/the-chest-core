using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers.Base
{
    public abstract class BaseStackContainer<T> : BaseContainer<T>, IStackContainer<T>
    {
        protected virtual IStackSlot<T>[] slots => base.Slots as IStackSlot<T>[];

        public override bool IsFull => slots?.All(x => x.IsFull) ?? false;

        public override bool IsEmpty => slots?.All(x => x.IsEmpty) ?? true;

        protected BaseStackContainer(IStackSlot<T>[] slots) : base(slots)
        {
        }

        protected BaseStackContainer(int size = DEFAULT_SLOT_COUNT) : base(size)
        {
        }
    }
}
