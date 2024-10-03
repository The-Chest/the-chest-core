using TheChest.ConsoleApp.Items;
using TheChest.Core.Inventories.Slots;

namespace TheChest.ConsoleApp.Inventories
{
    public class InventorySlot : InventorySlot<Item>
    {
        public InventorySlot(Item? currentItem = null) : base(currentItem) { }
    }
}
