namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventorySlotTests<T>
    {
        [Test]
        public void Add_EmptySlot_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.EmptySlot();

            var result = slot.Add(item);

            Assert.That(result, Is.True);
        }
        [Test]
        public void Add_EmptySlot_ChangesItem()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.EmptySlot();

            slot.Add(item);

            Assert.That(slot.Content, Is.EqualTo(item));
        }
        [Test]
        public void Add_FullSlot_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var result = slot.Add(item);

            Assert.That(result, Is.False);
        }
        [Test]
        public void Add_FullSlot_DoesNotChangeItem()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var newItem = this.itemFactory.CreateRandom();
            slot.Add(newItem);

            Assert.That(slot.Content, Is.Not.EqualTo(newItem));
        }
    }
}
