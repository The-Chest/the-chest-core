﻿using TheChest.Core.Inventories.Slots;

namespace TheChest.Core.Inventories.Tests.Slots
{
    public partial class IInventorySlotTests<T>
    {
        [Test]
        public void Replace_ReplacingItemOnEmptySlot_AddsItem()
        {
            var slot = new InventorySlot<T>();
            var newItem = this.itemFactory.CreateItem();

            slot.Replace(newItem);

            Assert.That(slot.Content, Is.Not.Null.And.EqualTo(newItem));
        }
        [Test]
        public void Replace_ReplacingItemOnEmptySlot_ReturnsNull()
        {
            var slot = new InventorySlot<T>();
            var newItem = this.itemFactory.CreateItem();

            var result = slot.Replace(newItem);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Replace_ReplacingItemOnFullSlot_AddsItem()
        {
            var item = this.itemFactory.CreateItem();
            var slot = new InventorySlot<T>(item);
            var newItem = this.itemFactory.CreateItem();

            slot.Replace(newItem);
            Assert.That(slot.Content, Is.Not.Null.And.EqualTo(newItem));
        }
        [Test]
        public void Replace_ReplacingItemOnFullSlot_ReturnsItem()
        {
            var item = this.itemFactory.CreateItem();
            var slot = new InventorySlot<T>(item);
            var newItem = this.itemFactory.CreateItem();

            var result = slot.Replace(newItem);

            Assert.That(result, Is.Not.Null.And.EqualTo(item));
        }
    }
}