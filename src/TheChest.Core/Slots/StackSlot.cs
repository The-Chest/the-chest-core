﻿using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Slot with with <see cref="IStackSlot{T}"/> implementation with a collection of items
    /// </summary>
    /// <typeparam name="T">The item collection inside the slot accepts</typeparam>
    public class StackSlot<T> : IStackSlot<T>
    {
        private const string ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT = "The item amount cannot be bigger than max amount";
        private const string MAXAMOUNT_SMALLER_THAN_ZERO = "The max amount property cannot be smaller than zero";
        private const string AMOUNT_BIGGER_THAN_MAXAMOUNT = "The item amount cannot be bigger than max amount";

        protected ICollection<T> content;
        public virtual T[] Content
        {
            get
            {
                return content.ToArray();
            }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                if (value.Length > maxStackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT);

                content = value;
            }
        }

        public virtual int StackAmount => Content.Count(x => x is not null);

        protected int maxStackAmount;
        public virtual int MaxStackAmount
        {
            get
            {
                return maxStackAmount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), MAXAMOUNT_SMALLER_THAN_ZERO);

                if (value < StackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_BIGGER_THAN_MAXAMOUNT);

                maxStackAmount = value;
            }
        }

        public virtual bool IsFull => this.StackAmount == maxStackAmount;

        public virtual bool IsEmpty => this.StackAmount == 0;

        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with the max size defined by the array
        /// </summary>
        /// <param name="items">The amount of items to be added to the created slot and also sets the <see cref="IStackSlot{T}.MaxStackAmount"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StackSlot(T[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            this.maxStackAmount = items.Length;
            this.content = items;
        }

        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with items and a max size defined by param the <paramref name="maxStackAmount"/>
        /// </summary>
        /// <param name="items">The amount of items to be inside the created slot</param>
        /// <param name="maxStackAmount">Sets the max amount permitted to the slot (cannot be smaller than <paramref name="items"/> size)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public StackSlot(T[] items, int maxStackAmount)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (items.Length > maxStackAmount)
                throw new ArgumentOutOfRangeException(nameof(items), ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT);

            Array.Resize(ref items, maxStackAmount);
            this.content = items;
            this.maxStackAmount = maxStackAmount;
        }
    }
}
