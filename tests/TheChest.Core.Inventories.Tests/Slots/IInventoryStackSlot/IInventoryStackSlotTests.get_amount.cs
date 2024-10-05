namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void GetAmount_InvalidAmount_ThrowsArgumentExceptions(int amount)
        {
            var items = this.itemFactory.CreateMany(20);
            var slot = this.slotFactory.FullSlot(items);

            Assert.That(() => slot.GetAmount(amount), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void GetAmount_SlotWithEnoughItems_ReturnsWithAmount()
        {
            var items = this.itemFactory.CreateMany(20);
            var slot = this.slotFactory.FullSlot(items);

            var result = slot.GetAmount(10);

            Assert.That(result, Is.EquivalentTo(items[0..10]));
        }

        [Test]
        public void GetAmount_SlotWithNotEnoughItems_ReturnsItemsFromSlot()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items, 20);

            var result = slot.GetAmount(10);

            Assert.That(result, Is.EquivalentTo(items));
        }

        [Test]
        public void GetAmount_AmoutBiggerThanSlotMaxAmount_ReturnsAllItemsFromSlot()
        {
            var items = this.itemFactory.CreateMany(20);
            var slot = this.slotFactory.WithItems(items, 20);

            var result = slot.GetAmount(30);

            Assert.That(result, Is.EquivalentTo(items));
        }

        [Test]
        public void GetAmount_EmptySlot_ReturnsEmptyArray()
        {
            var slot = this.slotFactory.EmptySlot(20);

            var result = slot.GetAmount(10);

            Assert.That(result, Is.EquivalentTo(Array.Empty<T>()));
        }
    }
}
