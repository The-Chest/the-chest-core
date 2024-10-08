namespace TheChest.Core.Inventories.Tests.Containers
{
    public partial class InventoryTests<T>
    {
        [Test]
        public void GetItem_NoItems_ReturnsNull()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateMany(size / 2);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);
            
            var searchItem = this.itemFactory.CreateRandom();
            var result = inventory.Get(searchItem);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetItem_ExistingItems_ReturnsTheFirstFoundItem()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, item);

            var result = inventory.Get(item);

            Assert.That(result, Is.Not.Null.And.EqualTo(item));
        }

        [Test]
        public void GetItem_ExistingItems_RemovesTheFirstFoundItemFromSlot()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, item);

            inventory.Get(item);

            Assert.That(inventory.Slots[0].Content, Is.Null);
        }
    }
}
