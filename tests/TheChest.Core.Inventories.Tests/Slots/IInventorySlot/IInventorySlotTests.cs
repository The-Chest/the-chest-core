using TheChest.Core.Inventories.Tests.Slots.Factories.Interfaces;
using TheChest.Core.Tests.Slots.Factories.Interfaces;
using TheChest.Tests.Slots;

namespace TheChest.Core.Inventories.Tests.Slots
{
    public abstract partial class IInventorySlotTests<T> : ISlotTests<T>
    {
        protected new readonly IInventorySlotFactory<T> slotFactory;

        public IInventorySlotTests(IInventorySlotFactory<T> slotFactory, ISlotItemFactory<T> itemFactory) : base(slotFactory, itemFactory)
        {
            this.slotFactory = slotFactory;
        }
    }
}
