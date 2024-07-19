namespace TheChest.Core.Slots.Interfaces
{
    public interface IStackSlot<T> : ISlot<IReadOnlyCollection<T>>, IReadOnlyCollection<T>
    {
        /// <summary>
        /// Defines the amount of items this slot is holding
        /// </summary>
        int StackAmount { get; }

        /// <summary>
        /// Defines the max amount of item that this slot can contain
        /// </summary>
        int MaxStackAmount { get; }
    }
}
