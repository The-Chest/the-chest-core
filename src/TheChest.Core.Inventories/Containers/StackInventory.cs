using TheChest.Core.Containers;
using TheChest.Core.Inventories.Containers.Interfaces;
using TheChest.Core.Inventories.Slots.Interfaces;

namespace TheChest.Core.Inventories.Containers
{
    public class StackInventory<T> : StackContainer<T>, IStackInventory<T>
    {
        protected readonly IInventoryStackSlot<T>[] slots;

        public override IInventoryStackSlot<T> this[int index] => this.slots[index];

        public override IInventoryStackSlot<T>[] Slots => this.slots.ToArray();

        public StackInventory(IInventoryStackSlot<T>[] slots) : base(slots) 
        {
            this.slots = slots;
        }

        public virtual void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            for (var i = 0; i < this.Size; i++)
            {
                if (this.slots[i].CanAdd(item))
                {
                    this.slots[i].Add(ref item);
                    break; 
                }
            }
        }

        public virtual T[] AddAt(T item, int index, bool replace = true)
        {
            if (index > this.Size || index <= 0)
                throw new IndexOutOfRangeException();
            
            var slot = this.Slots[index];

            if (slot.CanAdd(item))
                slot.Add(ref item);

            if (slot.CanReplace(item) && replace)
                return slot.Replace(ref item);

            return Array.Empty<T>();
        }

        public virtual T[] Add(T[] items)
        {
            for (var i = 0; i < this.Size; i++)
            {
                var slot = this.slots[i];
                if (slot.CanAdd(items))
                {
                    slot.Add(ref items);
                    if(items.Length == 0)
                        break;
                }
            }

            return items;
        }

        public virtual T[] AddAt(T[] items, int index, bool replace = true)
        {
            if (index > this.Size || index <= 0)
                throw new IndexOutOfRangeException();

            var slot = this.slots[index];

            if (slot.CanAdd(items))
                slot.Add(ref items);

            if (slot.CanReplace(items) && replace)
                return slot.Replace(ref items);

            return items;
        }

        public virtual T[] Clear()
        {
            var items = new List<T>();

            for (int i = 0; i < this.Size; i++)
            {
                items.AddRange(this.slots[i].GetAll());
            }

            return items.ToArray();
        }

        public virtual T[] GetAll(int index)
        {
            if (index > this.Size || index <= 0)
                throw new IndexOutOfRangeException();

            return this.slots[index].GetAll();
        }

        public virtual T[] GetAll(T item)
        {
            var items = new List<T>();

            for (int i = 0; i < this.Size; i++)
            {
                if (this.slots[i].Contains(item))
                {
                    items.AddRange(this.slots[i].GetAll());
                }
            }

            return items.ToArray();
        }

        public virtual T? Get(int index)
        {
            if (index > this.Size || index <= 0)
                throw new IndexOutOfRangeException();
            
            return this.slots[index].Get();
        }

        public virtual T? Get(T item)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this.slots[i].Contains(item))
                {
                    return this.slots[i].Get();
                }
            }
            return default;
        }

        public virtual T[] Get(T item, int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            var items = new List<T>();
            var remainingAmount = amount;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.slots[i].Contains(item))
                {
                    var slotItems = this.slots[i].Get(remainingAmount);
                    items.AddRange(slotItems);
                    remainingAmount -= slotItems.Length;
                    if (remainingAmount <= 0)
                    {
                        break;
                    }
                }

            }

            return items.ToArray();
        }

        public virtual T[] Get(int index, int amount)
        {
            if (index > this.Size || index <= 0)
                throw new IndexOutOfRangeException();

            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            return this.slots[index].Get(amount);
        }

        public virtual int GetCount(T item)
        {
            var amount = 0;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.slots[i].Contains(item))
                {
                    amount += this.slots[i].StackAmount;
                }
            }
            return amount;
        }

        public virtual void Move(int origin, int target)
        {
            if (origin < 0 || origin >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(origin));
            }
            if (target < 0 || target >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(target));
            }

            var items = this.slots[origin].GetAll();
            var oldItems = this.slots[target].Replace(ref items);
            this.slots[origin].Replace(ref oldItems);
        }
    }
}
