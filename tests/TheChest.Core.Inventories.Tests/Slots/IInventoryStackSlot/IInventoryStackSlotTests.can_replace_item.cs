namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void CanReplaceItem_NullItem_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();

            var item = (T)default!;

            Assert.That(slot.CanReplace(item), Is.False);
        }

        [Test]
        public void CanReplaceItem_NotNullItem_ReturnsTrue()
        {
            var slot = this.slotFactory.EmptySlot();

            var item = this.itemFactory.CreateDefault();
            
            Assert.That(slot.CanReplace(item), Is.True);
        }
    }
}
