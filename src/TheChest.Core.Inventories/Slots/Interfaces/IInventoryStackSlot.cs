using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Slots.Interfaces
{
    /// <summary>
    /// Interface with methods for a basic Inventory Stackable Slot 
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    public interface IInventoryStackSlot<T> : IStackSlot<T>
    {
        /// <summary>
        /// Checks if is possible to add one item to the slot
        /// </summary>
        /// <param name="item">item to be checked to add</param>
        /// <returns>true if is possible to add the item</returns>
        bool CanAdd(T item);
        /// <summary>
        /// Checks if is possible to add an array of items to the slot
        /// </summary>
        /// <param name="items">items to be checked to add</param>
        /// <returns>true if is possible to add the item</returns>
        bool CanAdd(T[] items);
        /// <summary>
        /// Adds an array of items to the slot.
        /// </summary>
        /// <param name="items">items to bem added to the slot</param>
        void Add(ref T[] items);
        /// <summary>
        /// Tries to add an array of items to the slot. 
        /// </summary>
        /// <param name="items">items to bem added to the slot</param>
        /// <returns>true if is possible to add</returns>
        bool TryAdd(ref T[] items);
        /// <summary>
        /// Replaces the items from slot to <paramref name="items"/>
        /// </summary>
        /// <param name="items">items that will replace items from slots</param>
        /// <returns>old items from the current slot</returns>
        T[] Replace(ref T[] items);
        /// <summary>
        /// Gets an amount of items from the slot.
        /// </summary>
        /// <param name="amount">Amount of items to get</param>
        /// <returns>an array with the size of the param <paramref name="amount"/></returns>
        T[] GetAmount(int amount);
        /// <summary>
        /// Gets all items from inside the Slot. 
        /// </summary>
        /// <returns>an array with all items from slot</returns>
        T[] GetAll();
    }
}
