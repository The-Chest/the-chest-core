using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Slots.Interfaces
{
    /// <summary>
    /// Interface with methods for a basic Inventory Slot
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    public interface IInventorySlot<T> : ISlot<T>
    {
        /// <summary>
        /// Adds the item in the current Slot if <see cref="ISlot{T}.IsFull"/> is false
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>True if the value is successful added</returns>
        bool Add(T item);

        T? Replace(T item);

        /// <summary>
        /// Returns an item from slot
        /// </summary>
        /// <returns>Returns an item of the slot, if <see cref="ISlot{T}.IsEmpty"/> is true, then returns null</returns>
        T? GetOne();
    }
}