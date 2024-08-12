using TheChest.ConsoleApp.Items;
using TheChest.Core.Inventories.Containers;

namespace TheChest.ConsoleApp.Inventory
{
    public class Inventory : Inventory<Item>
    {
        public Inventory(Slot[] slots) : base(slots) { }
    }
}
