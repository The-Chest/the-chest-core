using TheChest.Core.Slots.Base;

namespace TheChest.ConsoleApp.Containers
{
    public class Slot : BaseSlot<Item>
    {
        public Slot(Item? currentItem = null) : base(currentItem)
        {
        }
    }
}
