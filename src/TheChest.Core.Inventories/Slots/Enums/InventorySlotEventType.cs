namespace TheChest.Core.Inventories.Slots.Enums
{
    /// <summary>
    /// Defines the slot change type on the Slot
    /// </summary>
    public enum InventorySlotEventType
    {
        /// <summary>
        /// The Slot change was an Item added
        /// </summary>
        Added,
        /// <summary>
        /// The Slot change was an Item replaced
        /// </summary>
        Replaced,
        /// <summary>
        /// The Slot change was an Item removed
        /// </summary>
        Removed
    }
}
