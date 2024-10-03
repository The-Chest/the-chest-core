using TheChest.ConsoleApp.Items;
using TheChest.Core.Inventories.Containers;

namespace TheChest.ConsoleApp.Inventories
{
    public class Inventory : Inventory<Item>
    {
        public Inventory(InventorySlot[] slots) : base(slots) { }
    }
}
