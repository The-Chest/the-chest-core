namespace TheChest.Core.Inventories.Tests.Containers
{
    public partial class InventoryTests<T>
    {
        [TestCase(-1)]
        [TestCase(22)]
        public void AddItemAt_InvalidSlotIndex_ThrowsArgumentOutOfRangeException(int index)
        {
            var inventory = this.containerFactory.EmptyContainer();

            Assert.That(
                () => inventory.AddItemAt(this.itemFactory.CreateDefault(), index),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>()
            );
        }

        [Test]
        public void AddItemAt_EmptySlot_AddsTheItem()
        {
            var size = this.random.Next(10,20);
            var inventory = this.containerFactory.EmptyContainer(size);

            var randomIndex = this.random.Next(0, size);
            var item = this.itemFactory.CreateDefault();
            inventory.AddItemAt(item, randomIndex);

            Assert.That(inventory[randomIndex].Content, Is.EqualTo(item));
        }

        [Test]
        public void AddItemAt_EmptySlot_ReturnsNull()
        {
            var size = this.random.Next(10, 20);
            var inventory = this.containerFactory.EmptyContainer(size);

            var randomIndex = this.random.Next(0, size);
            var item = this.itemFactory.CreateDefault();
            var result = inventory.AddItemAt(item, randomIndex);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void AddItemAt_FullSlot_ReplacesTheItem()
        {
            var size = this.random.Next(10, 20);
            var oldItem = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, oldItem);

            var randomIndex = this.random.Next(0, size);
            var item = this.itemFactory.CreateRandom();
            inventory.AddItemAt(item, randomIndex);

            Assert.Multiple(() =>
            {
                var randomSlot = inventory[randomIndex];
                Assert.That(randomSlot.Content, Is.EqualTo(item));
                Assert.That(randomSlot.Content, Is.Not.EqualTo(oldItem));
            });
        }

        [Test]
        public void AddItemAt_FullSlot_ReturnsOldItem()
        {
            var size = this.random.Next(10, 20);
            var oldItem = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, oldItem);

            var randomIndex = this.random.Next(0, size);
            var item = this.itemFactory.CreateRandom();
            var result = inventory.AddItemAt(item, randomIndex);

            Assert.That(result, Is.EqualTo(oldItem));
        }

        [Test]
        public void AddItemAt_FullSlotReplaceFalse_DoNotReplaceTheItem()
        {
            var size = this.random.Next(10, 20);
            var oldItem = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, oldItem);

            var randomIndex = this.random.Next(0, size);
            var item = this.itemFactory.CreateRandom();
            inventory.AddItemAt(item, randomIndex, false);

            Assert.Multiple(() =>
            {
                var randomSlot = inventory[randomIndex];
                Assert.That(randomSlot.Content, Is.Not.EqualTo(item));
                Assert.That(randomSlot.Content, Is.EqualTo(oldItem));
            });
        }

        [Test]
        public void AddItemAt_FullSlotReplaceFalse_ReturnsSameItem()
        {
            var size = this.random.Next(10, 20);
            var oldItem = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, oldItem);

            var randomIndex = this.random.Next(0, size);
            var item = this.itemFactory.CreateDefault();
            var result = inventory.AddItemAt(item, randomIndex, false);

            Assert.That(result, Is.EqualTo(item));
        }
    }
}
