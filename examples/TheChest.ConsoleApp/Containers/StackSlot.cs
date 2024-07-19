using TheChest.Core.Slots.Base;

namespace TheChest.ConsoleApp.Containers
{
    public class StackSlot : BaseLazyStackSlot<Item>
    {
        public StackSlot(Item[] items, int maxStack) : base(items, maxStack) { }
    }
}
