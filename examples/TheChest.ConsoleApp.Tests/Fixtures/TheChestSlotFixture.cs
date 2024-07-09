using TheChest.ConsoleApp.Containers;
using TheChest.Core.Tests.Containers.Factories.Base;
using TheChest.Core.Tests.Slots.Factories.Base;

namespace TheChest.ConsoleApp.Tests.Fixtures
{
    public static class TheChestSlotFixture
    {
        public static object[] FixtureArgs = {
            new object[] { 
                new BaseSlotFactory<Slot, Item>(),
                new BaseSlotItemFactory<Item>(),
            }
        };

        public static object[] ContainerFixtureArgs = {
            new object[] {
                new BaseContainerFactory<Container, Item>(
                    new BaseSlotFactory<Slot, Item>()
                ),
                new BaseSlotItemFactory<Item>(),
            }
        };
    }
}
