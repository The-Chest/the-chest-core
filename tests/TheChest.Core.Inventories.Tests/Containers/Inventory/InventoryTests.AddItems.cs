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
            var items = this.itemFactory.CreateItems(randomSize);
            inventory.AddItems(items);

            Assert.That(inventory.Slots[0..randomSize].Select(x => x.Content), Is.EqualTo(items));
        }

        [Test]
        public void AddItems_SuccessAdding_ReturnsEmptyArray()
        {
            var size = this.random.Next(10, 20);
            var inventory = this.containerFactory.EmptyContainer(size);

            var randomSize = this.random.Next(0, size);
            var items = this.itemFactory.CreateItems(randomSize);
            var result = inventory.AddItems(items);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void AddItems_NotAvailabeSlotsForAllItems_AddsSomeItems()
        {
            var size = this.random.Next(10, 20);
            var itemSize = this.random.Next(1, size / 2);
            var items = this.itemFactory.CreateItems(itemSize + 2);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);

            inventory.AddItems(items);

            Assert.That(inventory.GetItemCount(items[0]), Is.EqualTo(itemSize));
        }

        [Test]
        public void AddItems_NotAvailabeSlotsForAllItems_ReturnsNotAddedItems()
        {
            var size = this.random.Next(10, 20);
            var itemSize = this.random.Next(1, size / 2);
            var items = this.itemFactory.CreateItems(itemSize + 2);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);

            var result = inventory.AddItems(items);

            Assert.That(result.Length, Is.EqualTo(2));
        }

        [Test]
        public void AddItems_FullInventory_DoNotAddItems()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateItem();
            var inventory = this.containerFactory.FullContainer(size, item);

            var items = this.itemFactory.CreateItems(size);
            inventory.AddItems(items);

            Assert.That(inventory.GetItemCount(items[0]), Is.EqualTo(0));
        }

        [Test]
        public void AddItems_FullInventory_ReturnsAllNotAddedItems()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateItem();
            var inventory = this.containerFactory.FullContainer(size, item);

            var items = this.itemFactory.CreateItems(size);
            var result = inventory.AddItems(items);

            Assert.That(result, Is.EqualTo(items));
        }
    }
}
