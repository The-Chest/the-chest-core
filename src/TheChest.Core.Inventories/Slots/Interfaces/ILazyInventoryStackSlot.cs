namespace TheChest.Core.Inventories.Slots.Interfaces
{
    public interface ILazyInventoryStackSlot<T> : IInventoryStackSlot<T>
    {
        /// <summary>
        /// Remove the current item of Slot and replace by a new one
        /// </summary>
        /// <param name="item">The item wich will replace the old one</param>
        /// <param name="amount">The amount of the New item</param>
        /// <returns>Returns an array of the old item</returns>
        T[] Replace(T item, int amount);

        /// <summary>
        /// Add an amount of items inside the current slot
        /// </summary>
        /// <param name="item">The item to be added </param>
        /// <param name="amount">The amount of items added</param>
        /// <returns>Return 0 if all items are fully added to slot , else will return the amount left</returns>
        int Add(T item, int amount);
    }
}
