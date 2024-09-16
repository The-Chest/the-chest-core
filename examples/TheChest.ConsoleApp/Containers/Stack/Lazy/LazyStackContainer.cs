using TheChest.ConsoleApp.Items;
using TheChest.Core.Containers;

namespace TheChest.ConsoleApp.Containers.Stack.Lazy
{
    public class LazyStackContainer : StackContainer<Item>
    {
        public LazyStackContainer(LazyStackSlot[] slots) : base(slots)
        {
        }
    }
}
