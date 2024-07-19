using TheChest.Core.Tests.Slots.Factories.Generics;

namespace TheChest.ConsoleApp.Tests.Containers
{
    [TestFixtureSource(nameof(FixtureArgs))]
    public class StackContainerTests : IStackContainerTests<Item>
    {
        static readonly object[] FixtureArgs = {
            new object[] {
                new BaseStackContainerFactory<StackContainer, Item>(
                    new BaseStackSlotFactory<StackSlot, Item>()
                ),
                new BaseSlotItemFactory<Item>(),
            }
        };
        public StackContainerTests(IStackContainerFactory<Item> containerFactory, ISlotItemFactory<Item> itemFactory)
            : base(containerFactory, itemFactory)
        {
        }
    }
}
