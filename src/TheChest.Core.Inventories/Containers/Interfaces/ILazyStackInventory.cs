namespace TheChest.Core.Inventories.Containers.Interfaces
{
    public interface ILazyStackInventory<T> : IInventory<T>
    {
        /// <summary>
        /// Adds an amount of item in a specific slot
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <param name="index">slot where the item will be added</param>
        /// <param name="amount">amount of the item</param>
        /// <param name="replace"></param>
        /// <returns>Returns the item that couldn't be added or the replaced items</returns>
        T[] AddItemAt(T item, int index, int amount, bool replace = true);

        T[] AddItem(T item, int amount);
    }
}
