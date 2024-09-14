namespace TheChest.Core.Inventories.Tests.Containers
{
    public partial class InventoryTests<T>
    {
        [Test]
        public void AddItems_EmptySlots_AddsAllItems()
        {
            var size = this.random.Next(10, 20);
            var inventory = this.containerFactory.EmptyContainer(size);

            var randomSize = this.random.Next(0, size);
            var items = this.itemFactory.CreateMany(randomSize);
            inventory.AddItems(items);

            Assert.That(inventory.Slots[0..randomSize].Select(x => x.Content), Is.EqualTo(items));
        }

        [Test]
        public void AddItems_SuccessAdding_ReturnsEmptyArray()
        {
            var size = this.random.Next(10, 20);
            var inventory = this.containerFactory.EmptyContainer(size);

            var randomSize = this.random.Next(0, size);
            var items = this.itemFactory.CreateMany(randomSize);
            var result = inventory.AddItems(items);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void AddItems_NotAvailabeSlotsForAllItems_AddsSomeItems()
        {
            var size = this.random.Next(10, 20);
            var itemSize = size / 2;
            var items = this.itemFactory.CreateMany(itemSize);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);

            var addSize = itemSize + 2;
            var manyAdded = this.itemFactory.CreateManyRandom(addSize);
            inventory.AddItems(manyAdded);

            Assert.That(inventory.GetItemCount(manyAdded[0]), Is.EqualTo(itemSize));
        }

        [Test]
        public void AddItems_NotAvailabeSlotsForAllItems_ReturnsNotAddedItems()
        {
            var size = this.random.Next(10, 20);
            var itemSize = size / 2;
            var items = this.itemFactory.CreateMany(itemSize);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);

            var addSize = itemSize + 2;
            var manyAdded = this.itemFactory.CreateManyRandom(addSize);
            var result = inventory.AddItems(manyAdded);

            var expectNotAddedLength = Math.Abs(itemSize - addSize) - 1;
            Assert.That(result.Length, Is.EqualTo(expectNotAddedLength));
        }

        [Test]
        public void AddItems_FullInventory_DoNotAddItems()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, item);

            var items = this.itemFactory.CreateManyRandom(size);
            inventory.AddItems(items);

            Assert.That(inventory.GetItemCount(items[0]), Is.EqualTo(0));
        }

        [Test]
        public void AddItems_FullInventory_ReturnsAllNotAddedItems()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, item);

            var items = this.itemFactory.CreateMany(size);
            var result = inventory.AddItems(items);

            Assert.That(result, Is.EqualTo(items));
        }
    }
}
