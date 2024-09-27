using TheChest.Core.Inventories.Slots.Interfaces;
using TheChest.Core.Slots;

namespace TheChest.Core.Inventories.Slots
{
    public class InventoryStackSlot<T> : StackSlot<T>, IInventoryStackSlot<T>
    {
        public InventoryStackSlot(T[] items) : base(items) { }

        public InventoryStackSlot(T[] items, int maxStackAmount) : base(items, maxStackAmount) { }

        public bool TryAdd(T[] items)
        {
            if (items.Length == 0)
            {
                throw new ArgumentException("Cannot add empty list of items", nameof(items));
            }

            var notAddedItems = new List<T>();
            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                if (!items[0]!.Equals(item))
                {
                    notAddedItems.Add(item);
                    continue;
                }

                if (this.CanAdd(item))
                {
                    notAddedItems.Add(item);
                    continue;
                }

                this.Content.Add(item);
            }

            items = notAddedItems.ToArray();
            return notAddedItems.Count == 0;
        }

        public void Add(T[] items)
        {
            //TODO: improve this method
            if (items.Length == 0)
            {
                throw new ArgumentException("Cannot add empty list of items", nameof(items));
            }

            for (int i = 1; i < items.Length; i++)
            {
                if (!items[0]!.Equals(items[i]))
                {
                    throw new ArgumentException($"Param \"items\" have items that are not equal ({i})", nameof(items));
                }

                if (!this.IsEmpty && !this.Content.First()!.Equals(items[i]))//TODO: use Contains
                {
                    throw new ArgumentException($"Param \"items\" must have every item equal to the Current item on the Slot ({i})", nameof(items));
                }
            }           

            var availableAmount = this.MaxStackAmount - this.StackAmount;

            T[] itemsToAdd;
            if (items.Length > availableAmount)
            {
                itemsToAdd = items[0..(availableAmount-1)];
                items = items[availableAmount..];
            }
            else
            {
                itemsToAdd = items;
                items = Array.Empty<T>();
            }

            foreach (var item in itemsToAdd)
            {
                this.Content.Add(item);
            }
        }

        public bool CanAdd(T item)
        {
            if (item == null)
                return false;

            if (this.IsFull)
                return false;

            if (!this.IsEmpty)
                return this.Content.First()!.Equals(item);//TODO: Use Contains

            return true;
        }

        public bool CanAdd(T[] items)
        {
            if (items.Length == 0)
                return false;

            if (this.IsFull)
                return false;

            var firstItem = items[0]!;
            for (int i = 0; i < items.Length; i++)
            {
                if (!this.CanAdd(items[i]))
                    return false;

                if(!firstItem.Equals(items[i])) 
                    return false;
            }

            return true;
        }

        public T[] GetAll()
        {
            throw new NotImplementedException();
        }

        public T[] GetAmount(int amount)
        {
            throw new NotImplementedException();
        }

        public T[] Replace(T[] items)
        {
            throw new NotImplementedException();
        }
    }
}
