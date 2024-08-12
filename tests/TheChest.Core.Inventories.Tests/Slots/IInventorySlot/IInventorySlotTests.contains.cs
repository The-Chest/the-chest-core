using TheChest.Core.Inventories.Slots;

namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventorySlotTests<T>
    {
        [Test]
        public void Contains_EmptySlot_ReturnsFalse()
        {
            var slot = new InventorySlot<T>();
            var item = this.itemFactory.CreateItem();
            var result = slot.Contains(item);
            Assert.That(result, Is.False);
        }
        [Test]
        public void Contains_SameItemSlot_ReturnsTrue()
        {
            var item = this.itemFactory.CreateItem();
            var slot = new InventorySlot<T>(item);
            var result = slot.Contains(item);
            Assert.That(result, Is.True);
        }
        [Test]
        public void Contains_DifferentItemSlot_ReturnsFalse()
        {
            var item = this.itemFactory.CreateItem();
            var slot = new InventorySlot<T>(item);
            var secondItem = this.itemFactory.CreateItem();
            var result = slot.Contains(secondItem);
            Assert.That(result, Is.False);
        }
    }
}
