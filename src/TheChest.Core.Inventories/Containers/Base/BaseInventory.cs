using TheChest.Core.Containers.Base;
using TheChest.Core.Inventories.Containers.Interfaces;
using TheChest.Core.Inventories.Slots.Base;
using TheChest.Core.Slots.Base;

namespace TheChest.Core.Inventories.Containers.Base
{
    /// <summary>
    /// Generic Inventory with <see cref="IInventory{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public abstract class BaseInventory<T> : BaseContainer<T>, IInventory<T>
    {
        private IInventorySlot<T>[] slots => Slots as IInventorySlot<T>[];

        /// <summary>
        /// Creates an Inventory with slots
        /// </summary>
        /// <param name="slots">An array of slots</param>
        protected BaseInventory(IInventorySlot<T>[] slots) : base(slots)
        {
            Slots = slots;
        }

        /// <summary>
        /// Creates an Inventory with a number of slots
        /// </summary>
        /// <param name="count">Sets the amount of slots (20 if not set)</param>
        protected BaseInventory(int count) : base(count)
        {
            if (count <= 0)
            {
                count = DEFAULT_SLOT_COUNT;
            }

            Slots = new BaseSlot<T>[count];
        }

        public virtual bool MoveItem(int origin, int target)
        {
            var oldItem = GetItem(origin);
            var res = AddItemAt(oldItem, target);
            AddItemAt(res, origin);
            return true;
        }

        public virtual T[] Clear()
        {
            var list = new List<T>();

            for (int i = 0; i < Slots.Length; i++)
            {
                if (!Slots[i].IsEmpty)
                {
                    var res = slots[i].GetOne();
                    list.Add(res);
                }
            }

            return list.ToArray();
        }

        public virtual T GetItem(int index)
        {
            if (index > Slots.Length || index < 0)
                return default;

            return slots[index].GetOne();
        }

        public virtual T GetItem(T item)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (!Slots[i].IsEmpty && Slots[i].CurrentItem.Equals(item))
                {
                    return slots[i].GetOne();
                }
            }
            return default;
        }

        public virtual T[] GetItemAmount(T item, int amount = 1)
        {
            if (amount < 0)
                return new T[0];

            var itemArr = new T[amount];

            var currentAmount = amount;
            var index = 0;

            for (int i = 0; i < Slots.Length; i++)
            {
                if (currentAmount == 0)
                    break;

                if (!Slots[i].IsEmpty && Slots[i].CurrentItem.Equals(item))
                {
                    var obj = slots[i].GetOne();
                    itemArr[index] = obj;
                    index++;
                    currentAmount--;
                }
            }
            return itemArr.Take(index).ToArray();
        }

        public virtual int GetItemCount(T item)
        {
            int amount = 0;
            for (int i = 0; i < Slots.Length; i++)
            {
                if (!Slots[i].IsEmpty && Slots[i].CurrentItem.Equals(item))
                {
                    amount++;
                }
            }
            return amount;
        }

        public virtual T[] GetAll(T item)
        {
            var list = new List<T>();

            for (int i = 0; i < Slots.Length; i++)
            {
                if (!Slots[i].IsEmpty && Slots[i].CurrentItem.Equals(item))
                {
                    var res = slots[i].GetOne();
                    list.Add(res);
                }
            }

            return list.ToArray();
        }

        public virtual T AddItemAt(T item, int index, bool replace = true)
        {
            throw new NotImplementedException();
        }

        public virtual bool AddItem(T item)
        {
            if (IsFull)
                return false;

            for (int i = 0; i < Size; i++)
            {
                if (Slots[i].IsEmpty || !Slots[i].IsFull && Slots[i].CurrentItem.Equals(item))
                {
                    slots[i].Add(item);
                    return true;
                }
            }

            return false;
        }

        public virtual T[] AddItem(T item, int amount)
        {
            if (amount < 1)
                return new T[0];

            var index = 0;
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].IsEmpty || !Slots[i].IsFull && Slots[i].CurrentItem.Equals(item))
                {
                    var result = slots[i].Add(item);
                    if (result)
                        index++;
                }

                if (index == amount)
                    return new T[0];
            }

            return Enumerable.Repeat(item, amount).ToArray();
        }

        public virtual T[] AddItem(T[] items)
        {
            if (items == null || items.Length == 0)
                return new T[0];

            var index = 0;
            for (int i = 0; i < Slots.Length; i++)
            {
                var item = items[index];
                if (Slots[i].IsEmpty || !Slots[i].IsFull && Slots[i].CurrentItem.Equals(item))
                {
                    var result = slots[i].Add(item);
                    if (result)
                        index++;
                }

                if (index == items.Length - 1)
                    return new T[0];
            }

            return items[index..];
        }
    }
}
