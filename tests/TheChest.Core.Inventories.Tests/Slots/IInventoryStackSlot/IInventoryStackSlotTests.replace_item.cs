namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void ReplaceItem_NullItem_ThrowsArgumentNullException()
        {
            var slotItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(slotItems);

            var item = default(T);
            Assert.That(() => slot.Replace(ref item), Throws.ArgumentNullException);
        }

        [Test]
        public void ReplaceItem_EmptySlot_AddsItem()
        {
            var slot = this.slotFactory.EmptySlot();

            var item = this.itemFactory.CreateDefault();
            var expectedContent = new T[1] { item };
            slot.Replace(ref item);

            Assert.That(slot.Content, Is.EquivalentTo(expectedContent));
        }

        [Test]
        public void ReplaceItem_EmptySlot_ReturnsEmptyArray()
        {
            var slot = this.slotFactory.EmptySlot();

            var item = this.itemFactory.CreateDefault();
            var result = slot.Replace(ref item);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ReplaceItem_ItemsDifferentFromSlot_ReturnsItemsFromSlot()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items);

            var replacingItem = this.itemFactory.CreateRandom();
            var result = slot.Replace(ref replacingItem);

            Assert.That(result, Is.EqualTo(items));
        }

        [Test]
        public void ReplaceItem_ItemsDifferentFromSlot_AddsItemsToSlot()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items);

            var replacingItem = this.itemFactory.CreateRandom();
            var expectedContent = new T[1] { replacingItem };

            slot.Replace(ref replacingItem);

            Assert.That(slot.Content, Is.EqualTo(expectedContent));
        }

        [Test]
        public void ReplaceItem_ItemsEqualToSlot_ReturnsItemsFromSlot()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items);

            var replacingItem = this.itemFactory.CreateDefault();
            var result = slot.Replace(ref replacingItem);

            Assert.That(result, Is.EqualTo(items));
        }

        [Test]
        public void ReplaceItem_ItemsEqualToSlot_AddsItemsToSlot()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items);

            var replacingItem = this.itemFactory.CreateDefault();
            var expectedContent = new T[1] { replacingItem };

            slot.Replace(ref replacingItem);

            Assert.That(slot.Content, Is.EqualTo(expectedContent));
        }
    }
}
