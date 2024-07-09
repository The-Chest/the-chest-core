using TheChest.Core.Slots.Base;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Slots.Factories.Interfaces;
namespace TheChest.Core.Tests.Slots.Factories.Base
{
    public class BaseSlotFactory<T, Y> : ISlotFactory<Y> where T : BaseSlot<Y>
    {
        public ISlot<Y> EmptySlot()
        {
            //TODO: use Activator.CreateInstanceFrom
            var type = typeof(T);
            var slot = Activator.CreateInstance(type, default(Y));
            return (ISlot<Y>)slot;
        }

        public ISlot<Y> FullSlot(Y item)
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(new Type[1]{ typeof(Y?) });
            var slot = constructor!.Invoke(new object[1] { item });
            return (ISlot<Y>)slot;
        }
    }
}
