namespace TheChest.Core.Tests.Slots.Factories.Interfaces
{
    /// <summary>
    /// Generic item creation.
    /// There is nothing special about this interface. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISlotItemFactory<T>
    {
        /// <summary>
        /// Creates an item
        /// </summary>
        /// <returns>Any <see cref="T"/> instance</returns>
        T CreateDefault();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Any <see cref="T"/> instance</returns>
        T CreateRandom();
        /// <summary>
        /// Creates an amount of item
        /// </summary>
        /// <param name="amount">Size of the returned array of items</param>
        /// <returns>Any <see cref="T"/> Array instance</returns>
        T[] CreateMany(int amount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        T[] CreateManyRandom(int amount);
    }
}
