namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventorySlotTests<T>
    {
        [Test]
        public void Contains_EmptySlot_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();

            var item = this.itemFactory.CreateDefault();
            var result = slot.Contains(item);

            Assert.That(result, Is.False);
        }
        [Test]
        public void Contains_SameItemSlot_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var result = slot.Contains(item);

            Assert.That(result, Is.True);
        }
        [Test]
        public void Contains_DifferentItemSlot_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var secondItem = this.itemFactory.CreateRandom();
            var result = slot.Contains(secondItem);

            Assert.That(result, Is.False);
        }
    }
}
