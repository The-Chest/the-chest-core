namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void Add_EmptySlot_WithLessItemsThanMaxAmount_AddsAllItems()
        {
            var randomSize = this.random.Next(1,20);
            var slot = this.slotFactory.EmptySlot(randomSize);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.Add(ref addingItems);

            Assert.That(slot.StackAmount, Is.EqualTo(randomSize));
        }

        [Test]
        public void Add_EmptySlot_WithLessItemsThanMaxAmount_RemovesAllItemsFromParams()
        {
            var randomSize = this.random.Next(1,20);
            var slot = this.slotFactory.EmptySlot(randomSize);

            var addingItems = this.itemFactory.CreateManyRandom(randomSize);
            slot.Add(ref addingItems);

            Assert.That(addingItems, Is.Empty);
        }

        [Test]
        public void Add_EmptySlot_WithMoreItemsThanMaxAmount_AddsAllItems()
        {
            var randomSize = this.random.Next(1, 20);
            var slot = this.slotFactory.EmptySlot(randomSize);

        }

        [Test]
        public void Add_EmptySlot_WithMoreItemsThanMaxAmount_RemovesAllItemsFromParams()
        {
            var slot = this.slotFactory.EmptySlot();

        }

        [Test]
        public void Add_FullSlot_WithAnyAmountOfItems_DoNotAdd()
        {
            var items = this.itemFactory.CreateManyRandom(10);
            var slot = this.slotFactory.FullSlot(items);

        }

        [Test]
        public void Add_FullSlot_WithAnyAmountOfItems_ChangesItemsParam()
        {
            var items = this.itemFactory.CreateManyRandom(10);
            var slot = this.slotFactory.FullSlot(items);
        }

        [Test]
        public void Add_AddingDifferentItems_ThrowsArgumentException()
        {

        }

        [Test]
        public void Add_AddingOneItemDifferent_ThrowsArgumentException()
        {

        }

        [Test]
        public void Add_DifferentItemsFromSlot_ThrowsArgumentException()
        {

        }

        [Test]
        public void Add_OneItemDifferentFromSlot_ThrowsArgumentException()
        {

        }

        [Test]
        public void Add_AddingNoItems_ThrowsArgumentException()
        {
            var slot = this.slotFactory.EmptySlot();

        }
    }
}
