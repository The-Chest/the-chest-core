namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void Replace_EmptyItemReplace_ThrowsArgumentException()
        {
            var slotItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(slotItems);

            var items = Array.Empty<T>();

            Assert.That(() => slot.Replace(ref items), Throws.ArgumentException);
        }

        [Test]
        public void Replace_EmptySlot_AddsItem()
        {
            var slot = this.slotFactory.EmptySlot();

            var items = this.itemFactory.CreateMany(10);
            var expectedResult = (T[])items.Clone();
            slot.Replace(ref items);

            Assert.That(slot.Content, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void Replace_EmptySlot_ReturnsEmptyArray()
        {
            var slot = this.slotFactory.EmptySlot();

            var items = this.itemFactory.CreateMany(10);
            var result = slot.Replace(ref items);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Replace_ItemsBiggerThanMaxAmount_ThrowsArgumentOutOfRangeException()
        {
            var slot = this.slotFactory.EmptySlot(10);

            var items = this.itemFactory.CreateMany(11);

            Assert.That(() => slot.Replace(ref items), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Replace_ItemsDifferentFromSlot_ReturnsItemsFromSlot()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items);

            var replacingItems = this.itemFactory.CreateManyRandom(5);
            var result = slot.Replace(ref replacingItems);

            Assert.That(result, Is.EqualTo(items));
        }

        [Test]
        public void Replace_ItemsDifferentFromSlot_AddsItemsToSlot()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items);

            var replacingItems = this.itemFactory.CreateManyRandom(5);
            var expectedResult = (T[])replacingItems.Clone();

            slot.Replace(ref replacingItems);

            Assert.That(slot.Content, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Replace_ItemsEqualToSlot_ReturnsItemsFromSlot()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items);

            var replacingItems = this.itemFactory.CreateMany(5);
            var result = slot.Replace(ref replacingItems);

            Assert.That(result, Is.EqualTo(items));
        }

        [Test]
        public void Replace_ItemsEqualToSlot_AddsItemsToSlot()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items);

            var replacingItems = this.itemFactory.CreateMany(5);
            var expectedResult = (T[])replacingItems.Clone();

            slot.Replace(ref replacingItems);

            Assert.That(slot.Content, Is.EqualTo(expectedResult));
        }
    }
}
