namespace TheChest.Tests.Slots.Generics
{
    public abstract partial class ISlotTests<T>
    {
        [Test]
        public void IsFull_CurentItemNull_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        public void IsFull_CurentItemNotNull_ReturnsTrue()
        {
            var slot = this.slotFactory.FullSlot(new T());
            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();

            Assert.That(slot.IsFull, Is.False);
            Assert.That(slot.IsFull, Is.Not.EqualTo(slot.IsEmpty));
        }
    }
}
