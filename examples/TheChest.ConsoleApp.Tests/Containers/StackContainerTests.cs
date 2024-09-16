using TheChest.ConsoleApp.Containers.Stack;
using TheChest.ConsoleApp.Containers.Stack.Lazy;
using TheChest.ConsoleApp.Items;
using TheChest.Core.Tests.Containers;

namespace TheChest.ConsoleApp.Tests.Containers
{
    [TestFixtureSource(nameof(FixtureArgs))]
    public class StackContainerTests : IStackContainerTests<Item>
    {
        static readonly object[] FixtureArgs = new object[]{
            new object[] {
                new StackContainerFactory<StackContainer, Item>(
                    new StackSlotFactory<StackSlot, Item>()
                ),
                new SlotItemFactory<Item>(),
            },
            new object[] {
                new StackContainerFactory<LazyStackContainer, Item>(
                    new LazyStackSlotFactory<LazyStackSlot, Item>()
                ),
                new SlotItemFactory<Item>(),
            },
        };
        public StackContainerTests(IStackContainerFactory<Item> containerFactory, ISlotItemFactory<Item> itemFactory)
            : base(containerFactory, itemFactory)
        {
        }
    }
}
