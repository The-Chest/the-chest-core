using TheChest.Core.Inventories.Slots.Interfaces;

namespace TheChest.Core.Inventories.Tests.Containers
{
    public partial class InventoryTests<T>
    {
        [Test]
        public void AddItem_EmptyInventory_AddsToFirstSlot()
        {
            var inventory = this.containerFactory.EmptyContainer();

            var item = this.itemFactory.CreateDefault();
            inventory.Add(item);

            Assert.Multiple(() =>
            {
                var firstSlot = inventory[0];

                Assert.That(firstSlot.IsEmpty, Is.False);
                Assert.That(firstSlot.Content, Is.EqualTo(item));
            });
        }

        [Test]
        public void AddItem_EmptyInventory_ReturnsTrue()
        {
            var inventory = this.containerFactory.EmptyContainer();

            var item = this.itemFactory.CreateDefault();
            var result = inventory.Add(item);

            Assert.That(result, Is.True);
        }

        [Test]
        public void AddItem_InventoryWithItems_AddsToFirstAvailableSlot()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateMany(size / 2);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);
            var firstAvailableSlot = inventory.Slots.First(slot => slot.IsEmpty);

            var item = this.itemFactory.CreateDefault();
            inventory.Add(item);

            Assert.Multiple(() =>
            {
                Assert.That(firstAvailableSlot.IsEmpty, Is.False);
                Assert.That(firstAvailableSlot.Content, Is.EqualTo(item));
            });
        }

        [Test]
        public void AddItem_FullInventory_DoNotAddItem()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, items);

            var item = this.itemFactory.CreateRandom();
            inventory.Add(item);

            Assert.That(inventory.Slots, Is.All.Matches<IInventorySlot<T>>(x => x.IsFull && !x.Content!.Equals(item)));
        }

        [Test]
        public void AddItem_FullInventory_ReturnsFalse()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateDefault();
            var inventory = this.containerFactory.FullContainer(size, items);

            var item = this.itemFactory.CreateDefault();

            var result = inventory.Add(item);
        
            Assert.That(result, Is.False);
        }
    }
}
