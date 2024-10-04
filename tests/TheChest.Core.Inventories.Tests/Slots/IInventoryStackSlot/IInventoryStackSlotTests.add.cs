namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void Add_EmptySlot_WithLessItemsThanMaxAmount_AddsAllItems()
        {
            var randomSize = this.random.Next(1,20);
            var slot = this.slotFactory.EmptySlot(randomSize);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.Add(ref addingItems);

            Assert.That(slot.StackAmount, Is.EqualTo(randomSize));
        }

        [Test]
        public void Add_EmptySlot_WithLessItemsThanMaxAmount_RemovesAllItemsFromParams()
        {
            var randomSize = this.random.Next(1,20);
            var slot = this.slotFactory.EmptySlot(randomSize);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.Add(ref addingItems);

            Assert.That(addingItems, Is.Empty);
        }

        [Test]
        public void Add_EmptySlot_WithMoreItemsThanMaxAmount_AddsAllItems()
        {
            var maxAmount = this.random.Next(1, 20);
            var slot = this.slotFactory.EmptySlot(maxAmount);

            var randomSize = this.random.Next(maxAmount + 1, 20);
            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.Add(ref addingItems);

            Assert.That(slot.StackAmount, Is.EqualTo(maxAmount));
        }

        [Test]
        public void Add_EmptySlot_WithMoreItemsThanMaxAmount_RemovesAllItemsFromParams()
        {
            var randomSize = this.random.Next(1, 20);
            var slot = this.slotFactory.EmptySlot(randomSize);

            var addingItemSize = randomSize * 2;
            var addingItems = this.itemFactory.CreateManyRandom(addingItemSize);
            slot.Add(ref addingItems);

            Assert.That(addingItems, Has.Length.EqualTo(addingItemSize - randomSize));
        }

        [Test]
        public void Add_FullSlot_WithAnyAmountOfItems_DoNotAdd()
        {
            var randomSize = this.random.Next(1, 20);
            var items = this.itemFactory.CreateMany(randomSize);
            var slot = this.slotFactory.FullSlot(items);

            var addingItems = this.itemFactory.CreateMany(randomSize);
            slot.Add(ref addingItems);

            Assert.That(slot.Content, Is.EqualTo(items));
        }

        [Test]
        public void Add_FullSlot_WithAnyAmountOfItems_ChangesItemsParam()
        {
            var randomSize = this.random.Next(1, 20);
            var items = this.itemFactory.CreateMany(randomSize);
            var slot = this.slotFactory.FullSlot(items);

            var addingItems = this.itemFactory.CreateMany(randomSize);
            slot.Add(ref addingItems);

            Assert.That(addingItems, Has.Length.EqualTo(randomSize));
        }

        [Test]
        public void Add_AddingDifferentItems_ThrowsArgumentException()
        {
            var slot = this.slotFactory.EmptySlot(20);

            var randomSize = this.random.Next(1, 20);
            var addingItems = this.itemFactory
                .CreateManyRandom(randomSize)
                .Append(this.itemFactory.CreateRandom())
                .ToArray();

            Assert.That(() => slot.Add(ref addingItems), Throws.ArgumentException);
        }

        [Test]
        public void Add_DifferentItemsFromSlot_ThrowsArgumentException()
        {
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault());

            var randomSize = this.random.Next(1, 10);
            var addingItems = this.itemFactory.CreateManyRandom(randomSize);

            Assert.That(() => slot.Add(ref addingItems), Throws.ArgumentException);
        }

        [Test]
        public void Add_OneItemDifferentFromSlot_ThrowsArgumentException()
        {
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault());

            var randomSize = this.random.Next(1, 10);
            var addingItems = this.itemFactory.CreateMany(randomSize)
                .Append(this.itemFactory.CreateRandom())
                .ToArray();

            Assert.That(() => slot.Add(ref addingItems), Throws.ArgumentException);
        }

        [Test]
        public void Add_AddingNoItems_ThrowsArgumentException()
        {
            var slot = this.slotFactory.EmptySlot();

            var addingItems = Array.Empty<T>();

            Assert.That(() => slot.Add(ref addingItems), Throws.ArgumentException);
        }
    }
}
