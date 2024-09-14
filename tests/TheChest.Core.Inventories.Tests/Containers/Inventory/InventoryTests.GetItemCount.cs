namespace TheChest.Core.Inventories.Tests.Containers
{
    public partial class InventoryTests<T>
    {
        [Test]
        public void GetItemCount_ReturnsItemCount()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateMany(size);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);

            var count = inventory.GetItemCount(items[0]);

            Assert.That(count, Is.EqualTo(size));
        }

        [Test]
        public void GetItemCount_DoNotRemoveItems()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateMany(size);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);

            inventory.GetItemCount(items[0]);

            Assert.That(inventory.Slots[0].Content, Is.EqualTo(items[0]));
        }

        [Test]
        public void GetItemCount_NoItems_ReturnsZero()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateMany(size);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);
            
            var count = inventory.GetItemCount(this.itemFactory.CreateRandom());

            Assert.That(count, Is.Zero);
        }
    }
}
