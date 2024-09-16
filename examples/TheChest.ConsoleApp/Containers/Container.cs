using TheChest.ConsoleApp.Items;
using TheChest.Core.Containers;

namespace TheChest.ConsoleApp.Containers
{
    public class Container : Container<Item>
    {
        public Container(Slot[] slots) : base(slots) { }
    }
}
