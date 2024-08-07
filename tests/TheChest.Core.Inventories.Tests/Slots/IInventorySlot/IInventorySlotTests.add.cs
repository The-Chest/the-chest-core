using TheChest.Core.Inventories.Slots;

namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventorySlotTests<T>
    {
        [Test]
        public void Add_EmptySlot_ReturnsTrue()
        {
            var item = this.itemFactory.CreateItem();
            var slot = new InventorySlot<T>();
            var result = slot.Add(item);
            Assert.That(result, Is.True);
        }
        [Test]
        public void Add_EmptySlot_ChangesItem()
        {
            var item = this.itemFactory.CreateItem();
            var slot = new InventorySlot<T>();
            slot.Add(item);
            Assert.That(slot.Content, Is.EqualTo(item));
        }
        [Test]
        public void Add_FullSlot_ReturnsFalse()
        {
            var item = this.itemFactory.CreateItem();
            var slot = new InventorySlot<T>(item);
            var result = slot.Add(item);
            Assert.That(result, Is.False);
        }
        [Test]
        public void Add_FullSlot_DoesNotChangeItem()
        {
            var item = this.itemFactory.CreateItem();
            var slot = new InventorySlot<T>(item);
            var newItem = this.itemFactory.CreateItem();
            slot.Add(newItem);
            Assert.That(slot.Content, Is.Not.EqualTo(newItem));
        }
    }
}
