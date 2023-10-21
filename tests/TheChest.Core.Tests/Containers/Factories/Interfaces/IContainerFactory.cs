﻿using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Factories.Interfaces
{
    public interface IContainerFactory<T>
    {
        IContainer<T> EmptyContainer(int size = 20);
        IContainer<T> FullContainer(int size, T item = default!);
        IContainer<T> ShuffleItemsContainer(int size, T item = default!);
        IContainer<T> ShuffleItemsContainer(int size, params T[] items);
    }
}
