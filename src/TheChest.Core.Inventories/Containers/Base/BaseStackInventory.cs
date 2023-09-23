using TheChest.Core.Inventories.Containers.Interfaces;
using TheChest.Core.Inventories.Slots.Base;

namespace TheChest.Core.Inventories.Containers.Base
{
    /// <summary>
    /// Generic Inventory with <see cref="IStackInventory{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public abstract class BaseStackInventory<T> : BaseInventory<T>, IStackInventory<T>
    {
        private IInventoryStackSlot<T>[] slots => Slots as IInventoryStackSlot<T>[];

        protected BaseStackInventory(int count) : base(count)
        {
        }

        protected BaseStackInventory(IInventoryStackSlot<T>[] slots) : base(slots)
        {
        }

        public override bool MoveItem(int origin, int target)
        {
            var oldItems = GetAll(origin);
            var res = AddItemAt(oldItems, target);
            AddItemAt(res, origin);
            return true;
        }

        public override T[] AddItem(T item, int amount)
        {
            if (amount < 1)
                return new T[0];

            var itemArr = Enumerable.Repeat(item, amount).ToArray();

            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].IsEmpty || !Slots[i].IsFull && Slots[i].CurrentItem.Equals(item))
                {
                    var result = slots[i].Add(item, amount);
                    amount = result;
                    itemArr = Enumerable.Repeat(item, result).ToArray();
                }

                if (itemArr.Length == 0)
                    break;
            }

            return itemArr;
        }

        public override T[] AddItem(T[] items)
        {
            if (items == null)
                return new T[0];

            var itemArr = items.Clone() as T[];
            var item = items[0];

            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].IsEmpty || !Slots[i].IsFull && Slots[i].CurrentItem.Equals(item))
                {
                    var result = slots[i].Add(itemArr);
                    itemArr = Enumerable.Repeat(item, result).ToArray();
                }

                if (itemArr.Length == 0)
                    break;
            }

            return itemArr;
        }

        public virtual T[] AddItemAt(T item, int index, int amount, bool replace = true)
        {
            if (amount < 1)
                return new T[0];

            if (index < 0 || index >= Slots.Length)
                return Enumerable.Repeat(item, amount).ToArray();

            if (Slots[index].IsEmpty || !Slots[index].IsFull && Slots[index].CurrentItem.Equals(item))
            {
                var result = slots[index].Add(item, amount);
                return Enumerable.Repeat(item, result).ToArray();
            }
            else if (replace)
            {
                return slots[index].Replace(item, amount);
            }

            return Enumerable.Repeat(item, amount).ToArray();
        }

        public virtual T[] AddItemAt(T[] items, int index, bool replace = true)
        {
            if (index < 0 || index >= Slots.Length)
                return items;

            if (items == null)
                return new T[0];

            var item = items.FirstOrDefault();
            var eq = Slots[index].CurrentItem?.Equals(item) ?? false;

            if (Slots[index].IsEmpty || !Slots[index].IsFull && eq)
            {
                var res = slots[index].Add(items);
                return Enumerable.Repeat(item, res).ToArray();
            }
            else if (replace)
            {
                return slots[index].Replace(items);
            }
            return items;
        }

        public virtual T[] GetAll(int index)
        {
            if (index < 0 || index >= Slots.Length)
                return new T[0];

            return slots[index].GetAll();
        }

        public virtual T[] GetItemAmount(int index, int amount)
        {
            if (index < 0 || index >= Slots.Length)
                return new T[0];

            return slots[index].GetAmount(amount);
        }
    }
}
