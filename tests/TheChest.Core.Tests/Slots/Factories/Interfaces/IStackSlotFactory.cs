using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories.Interfaces
{
    /// <summary>
    /// Factory interface to instantiate any <see cref="IStackSlot{T}"/> type
    /// </summary>
    /// <typeparam name="T">Any type of item inside ISlot</typeparam>
    public interface IStackSlotFactory<T>
    {
        /// <summary>
        /// Creates an <see cref="IStackSlot{T}"/> with no item inside it
        /// </summary>
        /// <returns>An empty <see cref="IStackSlot{T}"/></returns>
        IStackSlot<T> EmptySlot();

        IStackSlot<T> WithItem(T item, int amount = 1, int maxAmount = 10);
        /// <summary>
        /// Creates an <see cref="IStackSlot{T}"/> with the max supported amount of items inside it
        /// </summary>
        /// <param name="item">The item that will be inside the created N times inside it <see cref="IStackSlot{T}"/></param>
        /// <returns>A full <see cref="IStackSlot{T}"/></returns>
        IStackSlot<T> FullSlot(T item);
    }
}
