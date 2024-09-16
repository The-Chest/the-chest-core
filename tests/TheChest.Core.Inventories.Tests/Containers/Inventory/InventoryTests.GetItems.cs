namespace TheChest.Core.Inventories.Tests.Containers
{
    public partial class InventoryTests<T>
    {
        [TestCase(0)]
        public void GetItems_InvalidAmount_ThrowsArgumentOutOfRangeException(int amount)
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, item);

            Assert.That(
                () => inventory.GetItems(item, amount),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>()
            );
        }

        [Test]
        public void GetItems_ValidAmountNotFoundItem_ReturnsEmptyArray()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, item);

            var amount = this.random.Next(1, size);
            var result = inventory.GetItems(this.itemFactory.CreateRandom(), amount);

            Assert.That(result, Has.Length.EqualTo(0));
        }

        [Test]
        public void GetItems_ValidAmountFullInventory_ReturnsItemArrayWithAmountSize()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, item);

            var amount = this.random.Next(1, size);
            var result = inventory.GetItems(item, amount);

            Assert.That(result, Has.Length.EqualTo(amount));
        }

        [Test]
        public void GetItems_ValidAmountWithItems_ReturnsItemArrayWithMaxAvailable()
        {
            var inventorySize = this.random.Next(10, 20);
            var expectedAmount = this.random.Next(1, inventorySize / 2);
            var items = this.itemFactory.CreateMany(expectedAmount);
            var inventory = this.containerFactory.ShuffledItemsContainer(inventorySize, items);

            var amount = this.random.Next(expectedAmount, inventorySize);
            var result = inventory.GetItems(items[0], amount);
        
            Assert.That(result, Has.Length.EqualTo(expectedAmount));
        }
    }
}
