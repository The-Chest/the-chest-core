using TheChest.Tests.Slots.Generics;

namespace TheChest.ConsoleApp.Tests.Slots
{
    [TestFixtureSource(nameof(SlotFixtureArgs))]
    public class StackSlotTests : IStackSlotTests<Item>
    {
        static readonly object[] SlotFixtureArgs = {
            new object[] {
                new BaseStackSlotFactory<StackSlot, Item>(),
                new BaseSlotItemFactory<Item>(),
            }
        };

        public StackSlotTests(IStackSlotFactory<Item> slotFactory, ISlotItemFactory<Item> itemFactory) : base(slotFactory, itemFactory)
        {
        }
    }
}
