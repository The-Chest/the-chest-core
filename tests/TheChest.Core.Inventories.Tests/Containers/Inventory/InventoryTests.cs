using TheChest.Core.Tests.Containers;

namespace TheChest.Core.Inventories.Tests.Containers
{
    public abstract partial class InventoryTests<T> : IContainerTests<T>
    {
        protected new readonly IInventoryFactory<T> containerFactory;
        public InventoryTests(IInventoryFactory<T> containerFactory, ISlotItemFactory<T> itemFactory) : base(containerFactory, itemFactory) 
        { 
            this.containerFactory = containerFactory;
        }
    }
}
