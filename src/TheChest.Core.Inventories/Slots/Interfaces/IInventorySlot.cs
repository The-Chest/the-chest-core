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

        /// <summary>
        /// Replaces the content of slot to item
        /// </summary>
        /// <param name="item">Item to replace <see cref="ISlot{T}.Content"/></param>
        /// <returns>Old value of <see cref="ISlot{T}.Content"/></returns>
        T? Replace(T item);

        /// <summary>
        /// Returns an item from slot
        /// </summary>
        /// <returns>Returns an item of the slot, if <see cref="ISlot{T}.IsEmpty"/> is true, then returns null</returns>
        T? GetOne();

        /// <summary>
        /// Checks if <paramref name="item"/> is the same that <see cref="ISlot{T}.Content"/>
        /// </summary>
        /// <param name="item">The item to be checked</param>
        /// <returns>Returns true if the item is equal to the Content</returns>
        bool Contains(T item);
    }
}