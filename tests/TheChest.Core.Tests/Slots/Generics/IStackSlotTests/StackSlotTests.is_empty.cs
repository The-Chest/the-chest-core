namespace TheChest.Tests.Slots.Generics
{
    public abstract partial class StackSlotTests<T>
    {
        [Test]
        public void IsEmpty_StackAmountZero_ReturnsTrue()
        {
            var container = this.slotFactory.WithItem(this.itemFactory.CreateItem(), 0);
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_CurrentItemNull_ReturnsTrue()
        {
            var container = this.slotFactory.EmptySlot();
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_CurrentItemNotNull_ReturnsFalse()
        {
            var container = this.slotFactory.WithItem(this.itemFactory.CreateItem());
            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
