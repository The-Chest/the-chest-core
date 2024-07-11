using TheChest.Core.Slots.Base;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories.Base
{
    public class BaseStackSlotFactory<T, Y> : IStackSlotFactory<Y> where T : BaseStackSlot<Y>
    {
        public IStackSlot<Y> EmptySlot()
        {
            throw new NotImplementedException();
        }

        public IStackSlot<Y> FullSlot(Y item)
        {
            throw new NotImplementedException();
        }

        public IStackSlot<Y> WithItem(Y item, int amount = 1, int maxAmount = 10)
        {
            throw new NotImplementedException();
        }
    }
}
