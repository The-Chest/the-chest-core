using TheChest.ConsoleApp.Inventories.Stack;
using TheChest.ConsoleApp.Items;
using TheChest.Core.Inventories.Tests.Slots;

namespace TheChest.ConsoleApp.Tests.Slots
{
    [TestFixtureSource(nameof(SlotFixtureArgs))]
    public class InventoryStackSlotTests : IInventoryStackSlotTests<Item>
    {
        static readonly object[] SlotFixtureArgs = {
            new object[] {
                new InventoryStackSlotFactory<InventoryStackSlot, Item>(),
                new SlotItemFactory<Item>(),
            }
        };
        public InventoryStackSlotTests(IInventoryStackSlotFactory<Item> slotFactory, ISlotItemFactory<Item> itemFactory) : base(slotFactory, itemFactory)
        {
        }
    }
}
