using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Slots.Interfaces
{
    /// <summary>
    /// Interface with methods for a basic Inventory Stackable Slot 
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    public interface IInventoryStackSlot<T> : IStackSlot<T>
    {
        [Obsolete("Experimental")]
        bool CanAdd(T item);
        [Obsolete("Experimental")]
        bool CanAdd(T[] items);

        void Add(T[] items);

        [Obsolete("Experimental")]
        bool TryAdd(T[] items);

        T[] Replace(T[] items);

        T[] GetAmount(int amount);

        T[] GetAll();
    }
}
