using TheChest.Tests.Slots.Generics;

namespace TheChest.ConsoleApp.Tests.Slots
{
    [TestFixtureSource(nameof(SlotFixtureArgs))]
    public class SlotTests : ISlotTests<Item>
    {
        static readonly object[] SlotFixtureArgs = {
            new object[] {
                new BaseSlotFactory<Slot, Item>(),
                new BaseSlotItemFactory<Item>(),
            }
        };
        public SlotTests(ISlotFactory<Item> slotFactory, ISlotItemFactory<Item> itemFactory) : base(slotFactory, itemFactory)
        {
        }
    }
}
