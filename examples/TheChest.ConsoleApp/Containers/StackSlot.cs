using TheChest.Core.Slots;

namespace TheChest.ConsoleApp.Containers
{
    public class StackSlot : StackSlot<Item>
    {
        public StackSlot(Item[] items) : base(items) { }
        public StackSlot(Item[] items, int maxStack) : base(items, maxStack) { }
    }
}
