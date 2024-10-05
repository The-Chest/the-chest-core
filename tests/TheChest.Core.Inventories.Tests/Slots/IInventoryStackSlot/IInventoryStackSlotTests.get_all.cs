namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void GetAll_RemovesContentFromSlot()
        {
            var items = this.itemFactory.CreateMany(20);
            var slot = this.slotFactory.FullSlot(items);

            slot.GetAll();

            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        public void GetAll_FullSlot_ReturnsAllItemFromFullSlot()
        {
            var items = this.itemFactory.CreateMany(20);
            var slot = this.slotFactory.FullSlot(items);

            var result = slot.GetAll();
        
            Assert.That(result, Is.EquivalentTo(items));
        }

        [Test]
        public void GetAll_SlotWithItems_ReturnsAllItemFromSlot()
        {
            var items = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.WithItems(items,20);

            var result = slot.GetAll();

            Assert.That(result, Is.EquivalentTo(items));
        }

        [Test]
        public void GetAll_EmptySlot_ReturnsEmptyArray()
        {
            var slot = this.slotFactory.EmptySlot(20);

            var result = slot.GetAll();

            Assert.That(result, Is.EquivalentTo(Array.Empty<T>()));
        }
    }
}
