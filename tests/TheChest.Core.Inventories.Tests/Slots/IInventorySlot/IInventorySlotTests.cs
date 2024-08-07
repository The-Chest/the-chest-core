using TheChest.Core.Tests.Slots.Factories.Interfaces;
using TheChest.Tests.Slots;

namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventorySlotTests<T> : ISlotTests<T>
    {
        public IInventorySlotTests(ISlotFactory<T> slotFactory, ISlotItemFactory<T> itemFactory) : base(slotFactory, itemFactory)
        {
        }
    }
}
