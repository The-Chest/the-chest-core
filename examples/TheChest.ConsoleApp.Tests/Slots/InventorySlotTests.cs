using TheChest.ConsoleApp.Items;
using TheChest.ConsoleApp.Inventories;
using TheChest.Core.Inventories.Tests.Slots;

namespace TheChest.ConsoleApp.Tests.Slots
{
    [TestFixtureSource(nameof(SlotFixtureArgs))]
    public class InventorySlotTests : IInventorySlotTests<Item>
    {
        static readonly object[] SlotFixtureArgs = {
            new object[] {
                new InventorySlotFactory<Slot, Item>(),
                new SlotItemFactory<Item>(),
            }
        };
        public InventorySlotTests(IInventorySlotFactory<Item> slotFactory, ISlotItemFactory<Item> itemFactory) : base(slotFactory, itemFactory)
        {
        }
    }
}
