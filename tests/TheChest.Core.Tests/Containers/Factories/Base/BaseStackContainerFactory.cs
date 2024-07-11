using TheChest.Core.Containers.Base;
using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Factories.Base
{
    public class BaseStackContainerFactory<T, Y> : IStackContainerFactory<Y>
        where T : BaseContainer<Y>
    {
        private readonly IStackSlotFactory<Y> slotFactory;

        public BaseStackContainerFactory(IStackSlotFactory<Y> slotFactory)
        {
            this.slotFactory = slotFactory;
        }

        public IStackContainer<Y> EmptyContainer(int size = 20)
        {
            throw new NotImplementedException();
        }

        public IStackContainer<Y> FullContainer(int size, int stackSize, Y item = default)
        {
            throw new NotImplementedException();
        }

        public IStackContainer<Y> ShuffledItemContainer(int size, int stackSize, Y item = default)
        {
            throw new NotImplementedException();
        }

        public IStackContainer<Y> ShuffledItemsContainer(int size, int stackSize, params Y[] items)
        {
            throw new NotImplementedException();
        }
    }
}
