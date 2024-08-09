using TheChest.ConsoleApp.Items;
using TheChest.Core.Containers;

namespace TheChest.ConsoleApp.Containers.Stack
{
    public class StackContainer : StackContainer<Item>
    {
        public StackContainer(StackSlot[] slots) : base(slots)
        {
        }
    }
}
