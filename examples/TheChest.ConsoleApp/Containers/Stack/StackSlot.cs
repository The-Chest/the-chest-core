using TheChest.ConsoleApp.Items;
using TheChest.Core.Slots;

namespace TheChest.ConsoleApp.Containers.Stack
{
    public class StackSlot : StackSlot<Item>
    {
        public StackSlot(Item[] items) : base(items) { }
        public StackSlot(Item[] items, int maxStack) : base(items, maxStack) { }
    }
}
