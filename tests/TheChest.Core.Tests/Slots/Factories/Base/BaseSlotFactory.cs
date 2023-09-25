using TheChest.Core.Slots.Base;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Slots.Factories.Interfaces;

using System.Reflection;

namespace TheChest.Core.Tests.Slots.Factories.Base
{
    public abstract class BaseSlotFactory<T, Y> : ISlotFactory<Y>
        where T : BaseSlot<Y>
    {
        public ISlot<Y> EmptySlot()
        {
            var type = typeof(T);
            //TODO: use Activator.CreateInstanceFrom
            throw new NotImplementedException();
        }

        public ISlot<Y> FullSlot(Y item)
        {
            throw new NotImplementedException();
        }
    }
}
