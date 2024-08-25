using TheChest.Core.Inventories.Containers;
using TheChest.Core.Inventories.Containers.Interfaces;
using TheChest.Core.Tests.Containers.Factories;

namespace TheChest.Core.Inventories.Tests.Containers.Factories
{
    public class InventoryFactory<T, Y> : ContainerFactory<T, Y>, IInventoryFactory<Y>
        where T : Inventory<Y>
    {
        public InventoryFactory(ISlotFactory<Y> slotFactory) : base(slotFactory)
        {
        }

        public override IInventory<Y> EmptyContainer(int size = 20)
        {
            throw new NotImplementedException();
        }

        public override IInventory<Y> FullContainer(int size, Y item)
        {
            throw new NotImplementedException();
        }

        public override IInventory<Y> ShuffledItemContainer(int size, Y item)
        {
            throw new NotImplementedException();
        }

        public override IInventory<Y> ShuffledItemsContainer(int size, params Y[] items)
        {
            throw new NotImplementedException();
        }
    }
}
