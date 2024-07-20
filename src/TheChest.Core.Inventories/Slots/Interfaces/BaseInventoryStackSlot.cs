using TheChest.Core.Inventories.Slots.Base;
using TheChest.Core.Slots;

namespace TheChest.Core.Inventories.Slots.Interfaces
{
    /// <summary>
    /// Generic Slot with with <see cref="IInventoryStackSlot{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public abstract class BaseInventoryStackSlot<T> : LazyStackSlot<T>, IInventoryStackSlot<T>
    {
        public virtual T GetOne()
        {
            if (IsEmpty)
                return default;

            T item = Content;

            StackAmount--;

            if (StackAmount == 0)
                Content = default;

            return item;
        }

        public virtual bool Add(T item)
        {
            var eq = Content?.Equals(item) ?? false;

            if (IsEmpty || eq && !IsFull)
            {
                Content = item;
                StackAmount++;
                return true;
            }

            return false;
        }

        public virtual T[] GetAmount(int amount)
        {
            if (amount < 1) return new T[0];
            if (amount > StackAmount) amount = StackAmount;

            T[] items = new T[amount];

            for (int i = 0; i < amount; i++)
            {
                StackAmount--;
                items[i] = Content;
            }

            if (StackAmount == 0) Content = default;

            return items;
        }

        public virtual T[] GetAll()
        {
            return GetAmount(StackAmount);
        }

        public virtual int Add(T item, int amount)
        {
            if (amount < 1)
                return 0;

            var eq = Content?.Equals(item) ?? false;

            if (!IsEmpty && !eq || IsFull)
                return amount;

            int res = 0;

            Content = item;

            if (amount + StackAmount > MaxStackAmount)
            {
                res = StackAmount + amount - MaxStackAmount;
                StackAmount = MaxStackAmount;
            }
            else
            {
                StackAmount += amount;
            }

            return Math.Abs(res);
        }

        public virtual int Add(T[] items)
        {
            if (items == null || items.Length == 0)
                return 0;

            var eq = Content?.Equals(items[0]) ?? false;

            if (!IsEmpty && !eq || IsFull)
                return items.Length;

            int res = 0;

            Content = items[0];

            if (items.Length + StackAmount > MaxStackAmount)
            {
                res = StackAmount + items.Length - MaxStackAmount;
                StackAmount = MaxStackAmount;
            }
            else
            {
                StackAmount += items.Length;
            }

            return Math.Abs(res);
        }

        public virtual T[] Replace(T item, int amount)
        {
            T[] items = new T[0];

            if (amount < 1) return items;

            var eq = Content?.Equals(item) ?? false;

            if (eq)
            {
                int resultAmount = Add(item, amount);

                items = new T[resultAmount];

                for (int i = 0; i < resultAmount; i++)
                {
                    items[i] = Content;
                }
            }
            else
            {
                items = GetAll();

                Content = item;
                StackAmount = amount;
            }

            return items;
        }

        public virtual T[] Replace(T[] items)
        {
            if (items == null || items.Length == 0)
                return GetAll();

            T[] retItems;

            var eq = Content?.Equals(items[0]) ?? false;

            if (eq)
            {
                int resultAmount = Add(items);

                retItems = new T[resultAmount];

                for (int i = 0; i < resultAmount; i++)
                {
                    retItems[i] = Content;
                }
            }
            else
            {
                retItems = GetAll();

                Content = items[0];
                StackAmount = items.Length;
            }

            return retItems;
        }

        public T Replace(T item)
        {
            var result = Replace(item, 1);

            if (result.Length > 0)
            {
                return result[0];
            }

            return default;
        }
    }
}
