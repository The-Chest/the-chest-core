namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void CanReplaceItems_EmptyArray_ReturnsFalse() 
        {
            var startItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(startItems);

            var items = Array.Empty<T>();
            Assert.That(slot.CanReplace(items), Is.False);
        }

        [Test]
        public void CanReplaceItems_OneItemNullInArray_ReturnsFalse()
        {
            var startItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(startItems);

            var items = this.itemFactory.CreateMany(5)
                .Append(default)
                .ToArray();
            Assert.That(slot.CanReplace(items!), Is.False);
        }

        [Test]
        public void CanReplaceItems_OneItemDifferentInArray_ReturnsFalse()
        {
            var startItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(startItems);

            var items = this.itemFactory.CreateMany(5)
                .Append(default)
                .ToArray();
            Assert.That(slot.CanReplace(items!), Is.False);
        }

        [Test]
        public void CanReplaceItems_ArrayBiggerThanMaxAmount_ReturnsFalse()
        {
            var startItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(startItems);

            var items = this.itemFactory.CreateMany(11);
            Assert.That(slot.CanReplace(items), Is.False);
        }

        [Test]
        public void CanReplaceItems_ArrayEqualThanMaxAmount_ReturnsTrue()
        {
            var startItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(startItems);

            var items = this.itemFactory.CreateMany(10);
            Assert.That(slot.CanReplace(items), Is.True);
        }

        [Test]
        public void CanReplaceItems_ArraySmallerThanMaxAmount_ReturnsTrue()
        {
            var startItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(startItems);

            var items = this.itemFactory.CreateMany(9);
            Assert.That(slot.CanReplace(items), Is.True);
        }

        [Test]
        public void CanReplaceItems_SameItemsThanSlot_ReturnsTrue()
        {
            var startItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(startItems);

            Assert.That(slot.CanReplace(startItems), Is.True);
        }

        [Test]
        public void CanReplaceItems_DifferentItemThanSlot_ReturnsTrue()
        {
            var startItems = this.itemFactory.CreateMany(10);
            var slot = this.slotFactory.FullSlot(startItems);

            var items = this.itemFactory.CreateManyRandom(10);
            Assert.That(slot.CanReplace(items), Is.True);
        }
    }
}
 