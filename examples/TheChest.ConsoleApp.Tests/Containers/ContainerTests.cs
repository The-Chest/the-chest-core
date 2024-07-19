using TheChest.Core.Tests.Slots.Factories.Generics;

namespace TheChest.ConsoleApp.Tests.Containers
{
    [TestFixtureSource(nameof(FixtureArgs))]
    public class ContainerTests : IContainerTests<Item>
    {
        static readonly object[] FixtureArgs = {
            new object[] {
                new BaseContainerFactory<Container, Item>(
                    new BaseSlotFactory<Slot, Item>()
                ),
                new BaseSlotItemFactory<Item>(),
            }
        };
        public ContainerTests(IContainerFactory<Item> containerFactory, ISlotItemFactory<Item> itemFactory) 
            : base(containerFactory, itemFactory)
        {
        }
    }
}
