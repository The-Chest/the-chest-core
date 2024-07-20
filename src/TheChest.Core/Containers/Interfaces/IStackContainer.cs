using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers.Interfaces
{
    public interface IStackContainer<T>
    {
        IStackSlot<T> this[int index] { get; }

        IStackSlot<T>[] Slots { get; }

        int Size { get; }

        /// <summary>
        /// Verify if the container is full
        /// </summary>
        bool IsFull { get; }

        /// <summary>
        /// Verify if the container is empty
        /// </summary>
        bool IsEmpty { get; }
    }
}
