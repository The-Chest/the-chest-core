namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void Contains_EmptySlot_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();

            var item = this.itemFactory.CreateDefault();
            Assert.That(slot.Contains(item), Is.False);
        }

        [Test]
        public void Contains_ItemDifferentFromSlot_ReturnsFalse()
        {
            var slotItem = this.itemFactory.CreateRandom();
            var slot = this.slotFactory.WithItem(slotItem);

            var item = this.itemFactory.CreateDefault();
            Assert.That(slot.Contains(item), Is.False);
        }

        [Test]
        public void Contains_ItemEqualFromSlot_ReturnsFalse()
        {
            var slotItem = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.WithItem(slotItem);

            var item = this.itemFactory.CreateDefault();
            Assert.That(slot.Contains(item), Is.True);
        }
    }
}
