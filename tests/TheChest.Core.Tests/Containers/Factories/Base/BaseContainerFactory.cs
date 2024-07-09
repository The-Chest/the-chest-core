using System.Reflection;
using TheChest.Core.Containers.Base;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Containers.Factories.Interfaces;
using TheChest.Core.Tests.Slots.Factories.Interfaces;

namespace TheChest.Core.Tests.Containers.Factories.Base
{
    public class BaseContainerFactory<T, Y> : IContainerFactory<Y>
        where T : BaseContainer<Y>
    {
        private readonly ISlotFactory<Y> slotFactory;

        public BaseContainerFactory(ISlotFactory<Y> slotFactory)
        {
            this.slotFactory = slotFactory;
        }

        public IContainer<Y> EmptyContainer(int size = 20)
        {
            var type = typeof(T);
            var container = Activator.CreateInstance(type, size);
            return (IContainer<Y>)container!;
        }

        public IContainer<Y> FullContainer(int size, Y item = default)
        {
            var containerType = typeof(T);
            if (!typeof(IContainer<Y>).IsAssignableFrom(containerType))
            {
                throw new ArgumentException($"Type '{containerType.FullName}' does not implement IContainer<{typeof(Y).Name}>.");
            }

            var constructor = containerType.GetConstructors()
                .FirstOrDefault(ctor =>
                {
                    var parameters = ctor.GetParameters();
                    return parameters.Length == 1 && parameters[0].ParameterType.IsArray && !typeof(ISlot<Y>).IsAssignableFrom(parameters[0].ParameterType.GetElementType());
                });

            var slotParameter = containerType.GetConstructors()[0].GetParameters().FirstOrDefault(
                x => x.Name == "slots"
            );

            var slotType = slotParameter.ParameterType.GetElementType();
            if (!typeof(ISlot<Y>).IsAssignableFrom(slotType))
            {
                throw new ArgumentException($"Type '{slotType.FullName}' does not implement ISlot<{typeof(Y).Name}>.");
            }

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                slots.SetValue(this.slotFactory.FullSlot(item), i);
            }

            var res = containerType.GetConstructors()[0].Invoke(new object[1]{ slots });

            var container = Activator.CreateInstance(containerType, slots);

            return (IContainer<Y>)container!;
        }

        public IContainer<Y> ShuffledItemContainer(int size, Y item = default!)
        {
            throw new NotImplementedException();
        }

        public IContainer<Y> ShuffledItemsContainer(int size, params Y[] items)
        {
            throw new NotImplementedException();
        }
    }
}
