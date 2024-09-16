using TheChest.Core.Inventories.Containers.Interfaces;

namespace TheChest.Core.Inventories.Tests.Containers.Factories.Interfaces
{
    public interface IInventoryFactory<T> : IContainerFactory<T>
    {
        new IInventory<T> EmptyContainer(int size = 20);
        new IInventory<T> FullContainer(int size, T item);
        new IInventory<T> ShuffledItemContainer(int size, T item);
        new IInventory<T> ShuffledItemsContainer(int size, params T[] items);
    }
}
