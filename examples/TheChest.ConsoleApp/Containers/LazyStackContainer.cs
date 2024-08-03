using TheChest.Core.Containers;

namespace TheChest.ConsoleApp.Containers
{
    public class LazyStackContainer : StackContainer<Item>
    {
        public LazyStackContainer(LazyStackSlot[] slots) : base(slots)
        {
        }
    }
}
