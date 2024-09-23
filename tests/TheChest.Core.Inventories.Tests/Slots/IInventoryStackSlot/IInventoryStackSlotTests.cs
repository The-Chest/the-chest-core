using TheChest.Core.Tests.Slots;

namespace TheChest.Core.Inventories.Tests.Slots
{
    public abstract partial class IInventoryStackSlotTests<T> : IStackSlotTests<T>
    {
        protected new readonly IInventoryStackSlotFactory<T> slotFactory;

        public IInventoryStackSlotTests(IInventoryStackSlotFactory<T> slotFactory, ISlotItemFactory<T> itemFactory) : base(slotFactory, itemFactory)
        {
            this.slotFactory = slotFactory;
        }
    }
}
