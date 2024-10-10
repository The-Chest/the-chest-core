namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void Get_NoItem_ReturnsNull()
        {
            var slot = this.slotFactory.EmptySlot();

            var result = slot.Get();

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Get_FullSlot_ReturnsItem()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var result = slot.Get();

            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void Get_FullSlot_RemovesItemFromSlot()
        {
            var items = this.itemFactory.CreateMany(20);
            var slot = this.slotFactory.FullSlot(items);

            slot.Get();

            Assert.That(slot.Content, Has.Length.EqualTo(19));
        }
    }
}
