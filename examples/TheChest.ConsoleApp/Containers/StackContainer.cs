using TheChest.Core.Containers.Base;

namespace TheChest.ConsoleApp.Containers
{
    public class StackContainer : BaseStackContainer<Item>
    {
        public StackContainer(StackSlot[] slots) : base(slots)
        {
        }
    }
}
