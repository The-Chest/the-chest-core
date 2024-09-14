namespace TheChest.Core.Inventories.Tests.Containers
{
    public partial class InventoryTests<T>
    {
        [TestCase(-1)]
        [TestCase(30)]
        public void GetItem_InvalidIndex_ThrowsArgumentOutOfRangeException(int index)
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, item);

            Assert.That(
                () => inventory.GetItem(index), 
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>()
            );
        }

        [Test]
        public void GetItem_ValidIndexFullSlot_ReturnsItem()
        {
            var size = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, item);

            var randomIndex = this.random.Next(0, size);
            var result = inventory.GetItem(randomIndex);
           
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(item));
                Assert.That(inventory[randomIndex].IsEmpty, Is.True);
            });
        }

        [Test]
        public void GetItem_ValidIndexEmptySlot_ReturnsNull()
        {
            var size = this.random.Next(10, 20);
            var inventory = this.containerFactory.EmptyContainer(size);

            var randomIndex = this.random.Next(0, size);
            var result = inventory.GetItem(randomIndex);

            Assert.That(result, Is.Null);
        }
    }
}
