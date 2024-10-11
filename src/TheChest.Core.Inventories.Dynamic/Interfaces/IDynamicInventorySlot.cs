using TheChest.Core.Inventories.Dynamic.Actions;
using TheChest.Core.Inventories.Slots.Interfaces;

namespace TheChest.Core.Inventories.Dynamic.Interfaces
{
    public interface IDynamicInventorySlot<T> : IInventorySlot<T>
    {
        ISlotAction<T>[] Actions { get; }
    }
}
