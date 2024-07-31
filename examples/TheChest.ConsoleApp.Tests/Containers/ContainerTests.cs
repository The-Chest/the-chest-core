using TheChest.Core.Tests.Containers;

namespace TheChest.ConsoleApp.Tests.Containers
{
    [TestFixtureSource(nameof(FixtureArgs))]
    public class ContainerTests : IContainerTests<Item>
    {
        static readonly object[] FixtureArgs = {
            new object[] {
                new ContainerFactory<Container, Item>(
                    new SlotFactory<Slot, Item>()
                ),
                new SlotItemFactory<Item>(),
            }
        };
        public ContainerTests(IContainerFactory<Item> containerFactory, ISlotItemFactory<Item> itemFactory) 
            : base(containerFactory, itemFactory)
        {
        }
    }
}
