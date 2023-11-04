using TheChest.ConsoleApp.Containers;
using TheChest.Core.Tests.Slots.Factories.Base;

namespace TheChest.ConsoleApp.Tests.Fixtures
{
    public class TheChestSlotFixture
    {
        public static object[] FixtureArgs = {
            new object[] { 
                new BaseSlotFactory<Slot, Item>(),  
                new BaseSlotItemFactory<Item>(),
            }
        };
    }
}
