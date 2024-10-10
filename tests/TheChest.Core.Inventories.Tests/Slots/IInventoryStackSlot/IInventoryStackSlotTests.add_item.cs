namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventoryStackSlotTests<T>
    {
        [Test]
        public void Add_NullItem_ThrowsNullArgumentException()
        {
            var slot = this.slotFactory.EmptySlot();
            var item = (T)default!;
            Assert.That(() => slot.Add(ref item), Throws.ArgumentNullException);
        }
        [Test]
        public void Add_FullSlot_DoNotAddToContent()
        {
            var items = this.itemFactory.CreateMany(20);
            var slot = this.slotFactory.FullSlot(items);

            var item = this.itemFactory.CreateDefault();
            slot.Add(ref item);

            Assert.That(slot.Content, Is.Not.Contains(item));
        }
        [Test]
        public void Add_FullSlot_DoNotRemoveItem()
        {
            var items = this.itemFactory.CreateMany(20);
            var slot = this.slotFactory.FullSlot(items);

            var item = this.itemFactory.CreateDefault();
            slot.Add(ref item);

            Assert.That(item, Is.Not.Null);
        }

        [Test]
        public void Add_EmptySlot_AddsToContent()
        {
            var slot = this.slotFactory.EmptySlot();

            var item = this.itemFactory.CreateDefault();
            slot.Add(ref item);
        
            Assert.That(slot.Content, Contains.Value(item));
        }
        [Test]
        public void Add_EmptySlot_RemovesItem()
        {
            var slot = this.slotFactory.EmptySlot();

            var item = this.itemFactory.CreateDefault();
            slot.Add(ref item);
        
            Assert.That(item, Is.Null);
        }

        [Test]
        public void Add_SlotWithSameItem_AddsToContent()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items, 10);
        
            var item = this.itemFactory.CreateDefault();
            slot.Add(ref item);
        
            Assert.That(slot.Content, Contains.Value(item));
        }
        [Test]
        public void Add_SlotWithSameItem_RemovesItem()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items, 10);
        
            var item = this.itemFactory.CreateDefault();
            slot.Add(ref item);

            Assert.That(item, Is.Null);
        }

        [Test]
        public void Add_SlotWithDifferentItem_DoNotAddToContent()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items, 10);
        
            var item = this.itemFactory.CreateRandom();
            slot.Add(ref item);

            Assert.That(slot.Content, Is.Not.Contains(item));
        }
        [Test]
        public void Add_SlotWithDifferentItem_DoNotRemoveItem()
        {
            var items = this.itemFactory.CreateMany(5);
            var slot = this.slotFactory.WithItems(items, 10);
        
            var item = this.itemFactory.CreateRandom();
            slot.Add(ref item);
        
            Assert.That(item, Is.Not.Null);
        }
    }
}
