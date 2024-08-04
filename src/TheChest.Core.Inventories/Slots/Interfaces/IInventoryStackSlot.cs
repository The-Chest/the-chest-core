using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Slots.Interfaces
{
    /// <summary>
    /// Interface with methods for a basic Inventory Stackable Slot 
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    public interface IInventoryStackSlot<T> : IStackSlot<T>, IInventorySlot<T>
    {
        /// <summary>
        /// Try adds an array of items inside the current slot
        /// </summary>
        /// <param name="items">array of items to be added</param>
        /// <returns>returns the amount of items that couldn't be added</returns>
        int Add(T[] items);

        T[] Replace(T[] items);

        /// <summary>
        /// Returns an array of item from slot
        /// </summary>
        /// <param name="amount">The amount of items to be returned</param>
        /// <returns>Returns an array from slot or an empty array if <see cref="ISlot{T}.IsEmpty"/></returns>
        T[] GetAmount(int amount);

        /// <summary>
        /// Clear the slot and return all this items
        /// </summary>
        /// <returns>Returns all item from slot</returns>
        T[] GetAll();
    }
}
