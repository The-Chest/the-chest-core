using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Inventories.Containers.Interfaces
{
    /// <summary>
    /// Interface with methods for interaction with the Inventory using stacks
    /// <para>
    /// This interface is still unstable. Some methods can be moved to a separated interface.
    /// </para>
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public interface IStackInventory<T> : IStackContainer<T>
    {
        #region ISlot
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
        void Add(T item);
        #endregion

        #region IStack
        /// <summary>
        /// Returns an amount of items inside the Inventory Slot
        /// </summary>
        /// <param name="index">Index of the slot</param>
        /// <param name="amount">Amount of the item to be returned</param>
        /// <returns>Returns the amount of items inside the slot (or the max it can)</returns>
        T[] Get(int index, int amount);

        /// <summary>
        /// Returns all the items from the selected slot 
        /// </summary>
        /// <param name="index">Index of the slot</param>
        /// <returns>An array with of items</returns>
        T[] GetAll(int index);

        /// <summary>
        /// Adds an item in a specific slot
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <param name="index">slot where the item will be added</param>
        /// <param name="replace"></param>
        /// <returns>Returns the item that couldn't be added or the replaced item</returns>
        T[] AddAt(T item, int index, bool replace = true);

        /// <summary>
        /// Adds an array of item inside the inventory
        /// </summary>
        /// <param name="items">Array of item of the same type wich will be added to inventory</param>
        /// <param name="index">Wich slot the items will be added</param>
        /// <param name="replace">Defines if the current Slot item will be replaced by the <see cref="items"/> param</param>
        /// <returns>Returns a array of items replaced or could'nt be added</returns>
        T[] AddAt(T[] items, int index, bool replace = true);
        #endregion

        #region IInteractive
        /// <summary>
        /// Move a item between two slots
        /// </summary>
        /// <param name="origin">Selected item</param>
        /// <param name="target">Where the item will be placed</param>
        void Move(int origin, int target);

        /// <summary>
        /// Returns every item from inventory
        /// </summary>
        /// <returns>Returns an Array of <see cref="{T}"/></returns>
        T[] Clear();
        #endregion
    }
}
