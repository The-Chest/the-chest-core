using TheChest.Core.Inventories.Slots.Enums;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Slots.Base
{
    /// <summary>
    /// Interface with methods for a basic Inventory Slot
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    [Obsolete("Contract not fully defined")]
    public interface IInventorySlot<T> : ISlot<T>
    {
        /// <summary>
        /// Event dispatched every slot change
        /// </summary>
        /// event InventorySlotChangeEvent<T> OnChange;

        /// <summary>
        /// Adds the item in the current Slot if <see cref="ISlot{T}.IsFull"/> is false
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>True if the value is successful added</returns>
        bool Add(T item);

        T Replace(T item);

        /// <summary>
        /// Returns an item from slot
        /// </summary>
        /// <returns>Returns an item of the slot, if <see cref="ISlot{T}.IsEmpty"/> is true, then returns null</returns>
        T GetOne();
    }

    /// <summary>
    /// Event dispatched every time an inventory slot has a change
    /// </summary>
    /// <typeparam name="T">Type of the item inside the slot</typeparam>
    /// <param name="slot">Slot affected by the change</param>
    /// <param name="eventType">The change event type</param>
    /// <param name="item">The item that was changed inside the slot (null if none)</param>
    public delegate void InventorySlotChangeEvent<T>(IInventorySlot<T> slot, InventorySlotEventType eventType, T? item);
}