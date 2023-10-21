﻿namespace TheChest.Core.Tests.Slots.Factories.Generics.IContainerTests
{
    public abstract partial class IContainerTests<T>
    {
        [Test]
        public void IsFull_EmptySlots_ReturnsFalse() 
        {
            var container = this.containerFaker.EmptyContainer();

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_OneEmptySlot_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFaker.ShuffleItemsContainer(
                randomSize, 
                this.itemFactory.CreateItems(randomSize - 1)
           );

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_OneFullSlot_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFaker.ShuffleItemsContainer(
                randomSize,
                this.itemFactory.CreateItem()
            );

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_AllSlotsFull_ReturnsTrue()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFaker.FullContainer(
                randomSize,
                this.itemFactory.CreateItem()
            );

            Assert.That(container.IsFull, Is.True);
        }
    }
}
