using TheChest.Core.Containers;
using TheChest.Core.Inventories.Containers.Interfaces;
using TheChest.Core.Inventories.Slots.Interfaces;

namespace TheChest.Core.Inventories.Containers
{
    public class Inventory<T> : Container<T>, IInventory<T>
    {
        protected readonly IInventorySlot<T>[] slots;
        public Inventory(IInventorySlot<T>[] slots) : base(slots) 
        {
            this.slots = slots;
        }

        public override IInventorySlot<T> this[int index] => this.slots[index];

        public override IInventorySlot<T>[] Slots => this.slots.ToArray();

        public virtual T[] AddItems(params T[] items)
        {
            var addedAmount = 0;
            for (int i = 0; i < this.Size; i++)
            {
                var added = this.slots[i].Add(items[addedAmount]);
                if (added)
                {
                    addedAmount++;
                    if(addedAmount >= items.Length)
                    {
                        break;
                    }
                }
            }

            if (addedAmount < items.Length)
            {
                return items[addedAmount..];
            }

            return Array.Empty<T>();
        }

        public virtual bool AddItem(T item)
        {
            for (int i = 0; i < this.Size ; i ++)
            {
                var added = this.slots[i].Add(item);
                if (added)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual T? AddItemAt(T item, int index, bool replace = true)
        {
            if (index < 0 || index >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            T? result = default;
            if (replace)
            {
                result = this.slots[index].Replace(item);
            }
            else
            {
                var added = this.slots[index].Add(item);
                if (!added)
                {
                    result = item;
                }
            }

            return result;
        }

        public virtual T[] Clear()
        {
            var items = new List<T>();
            for (int i = 0; i < this.Size; i++)
            {
                var item = this.slots[i].GetOne();
                if(item != null)
                {
                    items.Add(item);
                }
            }
            return items.ToArray();
        }

        public virtual T[] GetAll(T item)
        {
            var items = new List<T>();
            for (int i = 0; i < this.Size; i++)
            {
                if (this.slots[i].Contains(item))
                {
                    items.Add(this.slots[i].GetOne()!);
                }
            }
            return items.ToArray();
        }

        public virtual T? GetItem(int index)
        {
            if (index < 0 || index >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return this.slots[index].GetOne();
        }

        public virtual T? GetItem(T item)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this.slots[i].Contains(item))
                {
                    return this.slots[i].GetOne();
                }
            }
            
            return default;
        }

        public virtual T[] GetItems(T item, int amount = 1)
        {
            var items = new List<T>();
            for (int i = 0; i < this.Size; i++)
            {
                if (this.slots[i].Contains(item))
                {
                    items.Add(this.slots[i].GetOne()!);
                    if (items.Count == amount)
                    {
                        break;
                    }
                }
            }
            return items.ToArray();
        }

        public virtual int GetItemCount(T item)
        {
            var count = 0;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.slots[i].Contains(item))
                {
                    count++;
                }
            }
            return count;
        }

        public virtual void MoveItem(int origin, int target)
        {
            if (origin < 0 || origin >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(origin));
            }
            if (target < 0 || target >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(target));
            }

            var item = this.slots[origin].GetOne();

            var oldItem = this.slots[target].Replace(item);
            this.slots[origin].Replace(oldItem);
        }
    }
}
