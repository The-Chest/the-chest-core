using TheChest.ConsoleApp.Items;
using TheChest.Core.Slots;

namespace TheChest.ConsoleApp.Containers
{
    public class Slot : Slot<Item>
    {
        public Slot(Item? currentItem = null) : base(currentItem) { }
    }
}
