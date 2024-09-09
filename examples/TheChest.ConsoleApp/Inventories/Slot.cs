using TheChest.ConsoleApp.Items;
using TheChest.Core.Inventories.Slots;

namespace TheChest.ConsoleApp.Inventories
{
    public class Slot : InventorySlot<Item>
    {
        public Slot(Item? currentItem = null) : base(currentItem) { }
    }
}
