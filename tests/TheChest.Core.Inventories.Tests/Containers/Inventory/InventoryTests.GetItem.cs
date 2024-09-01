﻿namespace TheChest.Core.Inventories.Tests.Containers
{
    public partial class InventoryTests<T>
    {
        [Test]
        public void GetItem_NoItems_ReturnsNull()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateItems(size / 2);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);
            
            var searchItem = this.itemFactory.CreateItem();
            var result = inventory.GetItem(searchItem);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetItem_ExistingItems_ReturnsTheFirstFoundItem()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateItem();
            var inventory = this.containerFactory.FullContainer(size, item);

            var result = inventory.GetItem(item);

            Assert.That(result, Is.Not.Null.And.EqualTo(item));
        }

        [Test]
        public void GetItem_ExistingItems_RemovesTheFirstFoundItemFromSlot()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateItem();
            var inventory = this.containerFactory.FullContainer(size, item);

            inventory.GetItem(item);

            Assert.That(inventory.Slots[0].Content, Is.Null);
        }
    }
}
