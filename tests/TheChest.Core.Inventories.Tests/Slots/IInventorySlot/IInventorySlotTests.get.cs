namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventorySlotTests<T>
    {
        [Test]
        public void GetOne_NoItem_ReturnsNull()
        {
            var slot = this.slotFactory.EmptySlot();

            var result = slot.Get();

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetOne_FullSlot_ReturnsItem()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var result = slot.Get();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void GetOne_FullSlot_RemovesItemFromSlot()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            slot.Get();

            Assert.That(slot.Content, Is.Null);
        }
    }
}
