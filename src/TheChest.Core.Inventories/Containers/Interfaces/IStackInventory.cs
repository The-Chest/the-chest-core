using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Inventories.Containers.Interfaces
{
    /// <summary>
    /// Interface with methods for interaction with the Inventory using stacks
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    [Obsolete("Contract not fully defined")]
    public interface IStackInventory<T> : IInventory<T>, IStackContainer<T>
    {
        /// <summary>
        /// Returns an amount of items inside the Inventory Slot
        /// </summary>
        /// <param name="index">Index of the slot</param>
        /// <param name="amount">Amount of the item to be returned</param>
        /// <returns>Returns the amount of items inside the slot (or the max it can)</returns>
        T[] GetItemAmount(int index, int amount);

        /// <summary>
        /// Returns all the items from the selected slot 
        /// </summary>
        /// <param name="index">Index of the slot</param>
        /// <returns>An array with of items</returns>
        T[] GetAll(int index);

        /// <summary>
        /// Adds an amount of item in a specific slot
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <param name="index">slot where the item will be added</param>
        /// <param name="amount">amount of the item</param>
        /// <param name="replace"></param>
        /// <returns>Returns the item that couldn't be added or the replaced items</returns>
        T[] AddItemAt(T item, int index, int amount, bool replace = true);

        /// <summary>
        /// Adds an array of item inside the inventory
        /// </summary>
        /// <param name="items">Array of item of the same type wich will be added to inventory</param>
        /// <param name="index">Wich slot the items will be added</param>
        /// <param name="replace">Defines if the current Slot item will be replaced by the <see cref="items"/> param</param>
        /// <returns>Returns a array of items replaced or could'nt be added</returns>
        T[] AddItemAt(T[] items, int index, bool replace = true);
    }
}
