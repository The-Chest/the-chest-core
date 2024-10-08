using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Inventories.Containers.Interfaces
{
    /// <summary>
    /// Interface with methods for interaction with the Container 
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public interface IInteractiveContainer<out T> : IContainer<T>
    {
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
    }
}
