using TheChest.Core.Containers;

namespace TheChest.ConsoleApp.Containers
{
    public class StackContainer : StackContainer<Item>
    {
        public StackContainer(StackSlot[] slots) : base(slots)
        {
        }
    }
}
