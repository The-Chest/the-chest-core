using TheChest.Core.Slots.Base;

namespace TheChest.ConsoleApp.Containers
{
    public class StackSlot : BaseStackSlot<Item>
    {
        public StackSlot(Item[] items, int maxStack) : base(items, maxStack) { }
    }
}
