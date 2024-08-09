﻿using TheChest.Core.Inventories.Slots.Interfaces;
using TheChest.Core.Slots;

namespace TheChest.Core.Inventories.Slots
{
    public class InventorySlot<T> : Slot<T>, IInventorySlot<T>
    {
        public InventorySlot(T? currentItem = default) : base(currentItem) { }

        public bool Add(T item)
        {
            if (this.IsFull)
            {
                return false;
            }

            this.Content = item;
            return true;
        }

        public T? GetOne()
        {
            var content = this.Content;
            this.Content = default;
            return content;    
        }

        public T? Replace(T item)
        {
            var content = this.Content;
            this.Content = item;
            return content;
        }
    }
}