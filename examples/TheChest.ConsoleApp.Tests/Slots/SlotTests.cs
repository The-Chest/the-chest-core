using TheChest.ConsoleApp.Containers;
using TheChest.ConsoleApp.Items;
using TheChest.Tests.Slots;

namespace TheChest.ConsoleApp.Tests.Slots
{
    [TestFixtureSource(nameof(SlotFixtureArgs))]
    public class SlotTests : ISlotTests<Item>
    {
        static readonly object[] SlotFixtureArgs = {
            new object[] {
                new SlotFactory<Slot, Item>(),
                new SlotItemFactory<Item>(),
            }
        };
        public SlotTests(ISlotFactory<Item> slotFactory, ISlotItemFactory<Item> itemFactory) : base(slotFactory, itemFactory)
        {
        }
    }
}
