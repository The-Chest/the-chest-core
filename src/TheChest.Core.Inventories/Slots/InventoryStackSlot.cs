using TheChest.Core.Inventories.Slots.Interfaces;
using TheChest.Core.Slots;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Slots
{
    /// <summary>
    /// Slot with with <see cref="IInventoryStackSlot{T}"/> implementation with a collection of items
    /// <para>
    /// This slot has behaviors of <seealso cref="StackSlot{T}"/>
    /// </para>
    /// </summary>
    /// <typeparam name="T">The item collection inside the slot accepts</typeparam>
    public class InventoryStackSlot<T> : StackSlot<T>, IInventoryStackSlot<T>
    {
        /// <summary>
        /// Creates an Inventory Slot with default items stacked
        /// </summary>
        /// <param name="items">>The amount of items to be added to the created slot and also sets the <see cref="IStackSlot{T}.MaxStackAmount"/></param>
        public InventoryStackSlot(T[] items) : base(items) { }
        /// <summary>
        /// Creates an Inventory Slot with default items stacked
        /// </summary>
        /// <param name="items">The amount of items to be added to the created slot</param>
        /// <param name="maxStackAmount">Sets the max amount permitted to the slot (cannot be smaller than <paramref name="items"/> size)</param>
        public InventoryStackSlot(T[] items, int maxStackAmount) : base(items, maxStackAmount) { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <para>
        /// The items must be the same in it and in the slot or it'll not add and return false
        /// </para>
        /// <param name="items"></param>
        /// <returns>false if has different items inside it or has any that is not equal to the items inside.</returns>
        /// <exception cref="ArgumentException">When the item array is empty</exception>
        public bool TryAdd(ref T[] items)
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

        /// <summary>
        /// <inheritdoc/>
        /// <para>
        /// The items must be the same in it and in the slot (if is not empty) or it'll throw an <see cref="ArgumentException"/>. 
        /// </para>
        /// <para>
        /// Use <see cref="IInventoryStackSlot{T}.TryAdd(ref T[])"/> if you don't want to handle these exceptions or after <see cref="IInventoryStackSlot{T}.CanAdd(T[])"/> 
        /// </para>
        /// </summary>
        /// <param name="items"><inheritdoc/></param>
        /// <exception cref="ArgumentException">When the item array is empty or has different items inside it or has any that is not equal to the items inside <see cref="ISlot{T}.Content"/></exception>
        public void Add(ref T[] items)
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="item"><inheritdoc/></param>
        /// <returns>Returns false if is Full or Contains item of a different type than <paramref name="item"/></returns>
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

        /// <summary>
        /// <inheritdoc/>.
        /// Uses <see cref="IInventoryStackSlot{T}.CanAdd(T)"/> validation for each one.
        /// </summary>
        /// <param name="items"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
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

        /// <summary>
        /// Gets and removes all items from <see cref="ISlot{T}.Content"/>
        /// </summary>
        /// <returns>All items from <see cref="ISlot{T}.Content"/></returns>
        public T[] GetAll()
        {
            var result = this.Content?.ToArray() ?? Array.Empty<T>();
            this.Content?.Clear();
            return result;
        }

        /// <summary>
        /// Gets an removes amount of items from <see cref="ISlot{T}.Content"/>.
        /// If is bigger than <see cref="IStackSlot{T}.StackAmount"/> it returns the maximum amount possible.
        /// </summary>
        /// <param name="amount">Amount of items to get from <see cref="ISlot{T}.Content"/></param>
        /// <returns>An array with the max amount possible from <see cref="ISlot{T}.Content"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="amount"/> is zero or smaller</exception>
        public T[] GetAmount(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (amount >= this.StackAmount)
            {
                return this.GetAll();
            }

            var result = this.Content.Take(amount).ToArray();

            this.Content = this.Content
                ?.Skip(amount)
                ?.ToArray()
                ?? Array.Empty<T>();
            return result;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="items"><inheritdoc/></param>
        /// <returns>The current items from <see cref="ISlot{T}.Content"/> or <paramref name="items"/> if is not possible to replace</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public T[] Replace(ref T[] items)
        {
            if(items.Length == 0 || items.Length > this.MaxStackAmount)
            {
                throw new ArgumentOutOfRangeException(nameof(items));
            }

            var firstItem = items[0]!;
            for (int i = 1; i < items.Length; i++)
            {
                if (!firstItem.Equals(items[i]))//TODO: use Contains
                {
                    throw new ArgumentException($"Param \"items\" have items that are not equal ({i})", nameof(items));
                }
            }

            var result = this.GetAll();
            if (this.TryAdd(ref items))
            {
                return result; 
            }

            this.Add(ref result);
            return items;
        }
    }
}
