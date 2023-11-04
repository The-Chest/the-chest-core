using TheChest.ConsoleApp.Containers;
using TheChest.ConsoleApp.Tests.Fixtures;
using TheChest.Core.Tests.Slots.Factories.Interfaces;
using TheChest.Tests.Slots.Generics;

namespace TheChest.ConsoleApp.Tests.Slots
{
    [TestFixtureSource(typeof(TheChestSlotFixture), nameof(TheChestSlotFixture.FixtureArgs))]
    public class SlotTests : ISlotTests<Item>
    {
        public SlotTests(ISlotFactory<Item> slotFactory, ISlotItemFactory<Item> itemFactory) : base(slotFactory, itemFactory)
        {
        }
    }
}
