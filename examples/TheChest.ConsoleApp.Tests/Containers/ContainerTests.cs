using TheChest.ConsoleApp.Containers;
using TheChest.ConsoleApp.Tests.Fixtures;
using TheChest.Core.Tests.Containers.Factories.Interfaces;
using TheChest.Core.Tests.Slots.Factories.Generics.IContainerTests;
using TheChest.Core.Tests.Slots.Factories.Interfaces;

namespace TheChest.ConsoleApp.Tests.Containers
{
    [TestFixtureSource(typeof(TheChestSlotFixture), nameof(TheChestSlotFixture.ContainerFixtureArgs))]
    public class ContainerTests : IContainerTests<Item>
    {
        public ContainerTests(IContainerFactory<Item> containerFactory, ISlotItemFactory<Item> itemFactory) 
            : base(containerFactory, itemFactory)
        {
        }
    }
}
