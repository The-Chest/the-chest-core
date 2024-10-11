using TheChest.Core.Inventories.Dynamic.Actions;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Dynamic.Interfaces
{
    public interface IDynamicSlot<T> : ISlot<T>
    {
        ISlotAction<T>[] Actions { get; }
    }
}
