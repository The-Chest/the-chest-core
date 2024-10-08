namespace TheChest.Core.Inventories.Containers.Interfaces
{
    /// <summary>
    /// Inventory Interface
    /// <para>
    /// This interface is still unstable. Some methods can be moved to a separated interface.
    /// </para>
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public interface IInventory<T> : IInteractiveContainer<T>
    {
        /// <summary>
        /// Gets an <see cref="item"/> inside a slot
        /// </summary>
        /// <param name="index">Slot's inventory to be searched</param>
        /// <returns>Returns the item inside <paramref name="index"/> Slot</returns>
        T? Get(int index);

        /// <summary>
        /// Search an Item from inventory
        /// </summary>
        /// <param name="item">The item to be searched</param>
        /// <returns>Returns the first item founded</returns>
        T? Get(T item);

        /// <summary>
        /// Search an amount of items in the inventory
        /// </summary>
        /// <param name="item">Item to be founded</param>
        /// <param name="amount">Amount to be returned</param>
        /// <returns>Returns the amount of items searched (or the max it can)</returns>
        T[] Get(T item, int amount);

        /// <summary>
        /// Get all Item of the selected type from all slots
        /// </summary>
        /// <param name="item">Item to be search</param>
        /// <returns>Returns a list with all items founded in the inventory</returns>
        T[] GetAll(T item);

        /// <summary>
        /// Returns the amount of an item inside the inventory
        /// </summary>
        /// <param name="item">The item to de counted</param>
        /// <returns>Returns the current amount of the item in the Inventory</returns>
        int GetCount(T item);

        /// <summary>
        /// Adds and array of item in a avaliable <see cref="ISlot{T}"/> 
        /// </summary>
        /// <param name="items">Array of items to be added to any avaliable <see cref="ISlot{T}"/> founded</param>
        /// <returns></returns>
        T[] Add(T[] items);

        /// <summary>
        /// Adds an item in a avaliable <see cref="ISlot{T}"/> 
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <returns>returns true if the item could be added</returns>
        bool Add(T item);

        /// <summary>
        /// Adds an item in a specific slot
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <param name="index">slot where the item will be added</param>
        /// <param name="replace"></param>
        /// <returns>Returns the item that couldn't be added or the replaced item</returns>
        T? AddAt(T item, int index, bool replace = true);
    }
}
