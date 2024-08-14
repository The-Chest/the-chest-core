using TheChest.ConsoleApp.Items;
using TheChest.ConsoleApp.Inventory;
using TheChest.Core.Inventories.Tests.Slots;
using TheChest.Core.Inventories.Tests.Slots.Factories;
using TheChest.Core.Inventories.Tests.Slots.Factories.Interfaces;

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
