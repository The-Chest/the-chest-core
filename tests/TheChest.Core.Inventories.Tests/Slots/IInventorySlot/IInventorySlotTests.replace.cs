namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventorySlotTests<T>
    {
        [Test]
        public void Replace_ReplacingItemOnEmptySlot_AddsItem()
        {
            var slot = this.slotFactory.EmptySlot();
            var newItem = this.itemFactory.CreateDefault(); 

            slot.Replace(newItem);

            Assert.That(slot.Content, Is.Not.Null.And.EqualTo(newItem));
        }
        [Test]
        public void Replace_ReplacingItemOnEmptySlot_ReturnsNull()
        {
            var slot = this.slotFactory.EmptySlot();
            var newItem = this.itemFactory.CreateDefault();

            var result = slot.Replace(newItem);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Replace_ReplacingItemOnFullSlot_AddsItem()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var newItem = this.itemFactory.CreateDefault();
            slot.Replace(newItem);

            Assert.That(slot.Content, Is.Not.Null.And.EqualTo(newItem));
        }
        [Test]
        public void Replace_ReplacingItemOnFullSlot_ReturnsItem()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var newItem = this.itemFactory.CreateDefault();
            var result = slot.Replace(newItem);

            Assert.That(result, Is.Not.Null.And.EqualTo(item));
        }
    }
}
