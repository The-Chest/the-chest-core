namespace TheChest.Tests.Slots
{
    public abstract partial class IStackSlotTests<T>
    {
        [Test]
        public void IsFull_CurentItemNull_ReturnsFalse()
        {
            var container = this.slotFactory.WithItem(default, 1);

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_CurentItemInHalfMaxStack_ReturnsFalse()
        {
            var maxStack = random.Next(5,20);

            var container = this.slotFactory.WithItem(this.itemFactory.CreateItem(), maxStack / 2, maxStack);

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var container = this.slotFactory.EmptySlot();

            Assert.That(container.IsFull, Is.False);
            Assert.That(container.IsFull, Is.Not.EqualTo(container.IsEmpty));
        }

        [Test]
        public void IsFull_CurentItemInMaxStack_ReturnsTrue()
        {
            var maxStack = random.Next(5, 20);

            var container = this.slotFactory.WithItem(this.itemFactory.CreateItem(), maxStack, maxStack);

            Assert.That(container.IsFull, Is.True);
        }
    }
}
