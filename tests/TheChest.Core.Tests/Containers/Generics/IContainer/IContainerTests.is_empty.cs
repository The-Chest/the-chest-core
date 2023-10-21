namespace TheChest.Core.Tests.Slots.Factories.Generics.IContainerTests
{
    public abstract partial class IContainerTests<T>
    {
        [Test]
        public void IsEmpty_EmptySlots_ReturnsTrue()
        {
            var container = this.containerFaker.EmptyContainer();
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_SomeEmptySlots_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFaker.ShuffleItemsContainer(randomSize, itemFactory.CreateItem());
            Assert.That(container.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_AllSlotsFull_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFaker.FullContainer(randomSize, itemFactory.CreateItem());
            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
