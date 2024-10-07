namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void TryAdd_EmptySlot_WithLessItemsThanMaxAmount_AddsAllItems()
        {
            var randomSize = this.random.Next(1, 20);
            var slot = this.slotFactory.EmptySlot(randomSize);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.TryAdd(ref addingItems);

            Assert.That(slot.StackAmount, Is.EqualTo(randomSize));
        }

        [Test]
        public void TryAdd_EmptySlot_WithLessItemsThanMaxAmount_ReturnsTrue()
        {
            var randomSize = this.random.Next(1, 20);
            var slot = this.slotFactory.EmptySlot(randomSize);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            var result = slot.TryAdd(ref addingItems);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TryAdd_EmptySlot_WithLessItemsThanMaxAmount_RemovesAllItemsFromParams()
        {
            var randomSize = this.random.Next(1, 20);
            var slot = this.slotFactory.EmptySlot(randomSize);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.TryAdd(ref addingItems);

            Assert.That(addingItems, Is.Empty);
        }

        [Test]
        public void TryAdd_EmptySlot_WithMoreItemsThanMaxAmount_AddsAllPossibleItems()
        {
            var maxAmount = this.random.Next(1, 20);
            var slot = this.slotFactory.EmptySlot(maxAmount);

            var randomSize = this.random.Next(maxAmount + 1, 20);
            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.TryAdd(ref addingItems);

            Assert.That(slot.StackAmount, Is.EqualTo(maxAmount));
        }

        [Test]
        public void TryAdd_EmptySlot_WithMoreItemsThanMaxAmount_RemovesAllPossibleItemsFromParams()
        {
            var randomSize = this.random.Next(1, 20);
            var slot = this.slotFactory.EmptySlot(randomSize);

            var addingItemSize = randomSize * 2;
            var addingItems = this.itemFactory.CreateManyRandom(addingItemSize);
            slot.TryAdd(ref addingItems);

            Assert.That(addingItems, Has.Length.EqualTo(addingItemSize - randomSize));
        }

        [Test]
        public void TryAdd_EmptySlot_WithMoreItemsThanMaxAmount_ReturnsFalse()
        {
            var maxAmount = this.random.Next(1, 20);
            var slot = this.slotFactory.EmptySlot(maxAmount);

            var addingItems = this.itemFactory.CreateManyRandom(maxAmount + 1);
            var result = slot.TryAdd(ref addingItems);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TryAdd_FullSlot_WithAnyAmountOfItems_DoNotAdd()
        {
            var randomSize = this.random.Next(1, 20);
            var items = this.itemFactory.CreateManyRandom(randomSize);
            var slot = this.slotFactory.FullSlot(items);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.TryAdd(ref addingItems);

            Assert.That(slot.Content, Is.EqualTo(items));
        }

        [Test]
        public void TryAdd_FullSlot_WithAnyAmountOfItems_DoNotChangesItemsParam()
        {
            var randomSize = this.random.Next(1, 20);
            var items = this.itemFactory.CreateManyRandom(randomSize);
            var slot = this.slotFactory.FullSlot(items);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.TryAdd(ref addingItems);

            Assert.That(addingItems, Has.Length.EqualTo(randomSize));
        }

        [Test]
        public void TryAdd_FullSlot_WithAnyAmountOfItems_ReturnsFalse()
        {
            var randomSize = this.random.Next(1, 20);
            var items = this.itemFactory.CreateManyRandom(randomSize);
            var slot = this.slotFactory.FullSlot(items);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            var result = slot.TryAdd(ref addingItems);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TryAdd_AddingDifferentItems_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot(20);

            var randomSize = this.random.Next(1, 20);
            var addingItems = this.itemFactory
                .CreateManyRandom(randomSize)
                .Append(this.itemFactory.CreateRandom())
                .ToArray();

            Assert.That(slot.TryAdd(ref addingItems), Is.False);
        }

        [Test]
        public void TryAdd_DifferentItemsFromSlot_ReturnsFalse()
        {
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault());

            var randomSize = this.random.Next(1, 10);
            var addingItems = this.itemFactory.CreateManyRandom(randomSize);

            Assert.That(slot.TryAdd(ref addingItems), Is.False);
        }

        [Test]
        public void TryAdd_OneItemDifferentFromSlot_ReturnsFalse()
        {
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault());

            var randomSize = this.random.Next(1, 10);
            var addingItems = this.itemFactory.CreateMany(randomSize)
                .Append(this.itemFactory.CreateRandom())
                .ToArray();

            Assert.That(slot.TryAdd(ref addingItems), Is.False);
        }

        [Test]
        public void TryAdd_AddingNoItems_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();

            var addingItems = Array.Empty<T>();

            Assert.That(slot.TryAdd(ref addingItems), Is.False);
        }
    }
}
