using TheChest.Core.Inventories.Slots.Enums;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Slots.Base
{
    /// <summary>
    /// Interface with methods for a basic Inventory Stackable Slot 
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    [Obsolete("Contract not fully defined")]
    public interface IInventoryStackSlot<T> : IStackSlot<T>, IInventorySlot<T>
    {
        /// <summary>
        /// Add an amount of items inside the current slot
        /// </summary>
        /// <param name="item">The item to be added </param>
        /// <param name="amount">The amount of items added</param>
        /// <returns>Return 0 if all items are fully added to slot , else will return the amount left</returns>
        int Add(T item, int amount);

        /// <summary>
        /// Try adds an array of items inside the current slot
        /// </summary>
        /// <param name="items">array of items to be added</param>
        /// <returns>returns the amount of items that couldn't be added</returns>
        int Add(T[] items);

        /// <summary>
        /// Remove the current item of Slot and replace by a new one
        /// </summary>
        /// <param name="item">The item wich will replace the old one</param>
        /// <param name="amount">The amount of the New item</param>
        /// <returns>Returns an array of the old item</returns>
        T[] Replace(T item, int amount);

        T[] Replace(T[] items);

        /// <summary>
        /// Returns an array of item from slot
        /// </summary>
        /// <param name="amount">The amount of items to be returned</param>
        /// <returns>Returns an array from slot or an empty array if <see cref="ISlot{T}.IsEmpty"/> </returns>
        T[] GetAmount(int amount);

        /// <summary>
        /// Clear the slot and return all this items
        /// </summary>
        /// <returns>Returns all item from slot</returns>
        T[] GetAll();
    }

    public delegate void StackInventorySlotChangeEvent<T>(IInventorySlot<T> slot, InventorySlotEventType eventType, T? item, int amount = 0);
}
