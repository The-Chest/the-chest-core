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
        /// Adds an item in the current Slot if <see cref="ISlot{T}.IsFull"/> is false
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>True if the value is successful added</returns>
        [Obsolete("This method has not been tested yet (Use Add with the array param)")]
        bool Add(ref T item);
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
        /// Replaces the items from <see cref="ISlot{T}.Content"/> to <paramref name="items"/>
        /// </summary>
        /// <param name="items">items that will replace items from slots</param>
        /// <returns>old items from <see cref="ISlot{T}.Content"/> if the replacement is possible</returns>
        T[] Replace(ref T[] items);
        /// <summary>
        /// Gets a single item from inside the <see cref="ISlot{T}.Content"/>
        /// </summary>
        /// <returns>an item from <see cref="ISlot{T}.Content"/> or null if <see cref="ISlot{T}.IsEmpty"/> is true</returns>
        [Obsolete("This method has not been tested yet (Use Add with the int param)")]
        T? Get();
        /// <summary>
        /// Gets an amount of items from the slot.
        /// </summary>
        /// <param name="amount">Amount of items to get</param>
        /// <returns>an array with the size of the param <paramref name="amount"/></returns>
        T[] Get(int amount);
        /// <summary>
        /// Gets all items from inside the Slot. 
        /// </summary>
        /// <returns>an array with all items from slot</returns>
        T[] GetAll();
        /// <summary>
        /// Checks if <paramref name="item"/> is the same that <see cref="IStackSlot{T}.Content"/>
        /// </summary>
        /// <param name="item">The item to be checked</param>
        /// <returns>Returns true if the item is equal to the Content</returns>
        [Obsolete("This method has not been tested yet")] 
        bool Contains(T item);
    }
}
