using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots.Base
{
    /// <summary>
    /// Generic Slot with with <see cref="ILazyStackSlot{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public abstract class BaseLazyStackSlot<T> : BaseSlot<T>, ILazyStackSlot<T>
    {
        private const string AMOUNT_SMALLER_THAN_ZERO = "The amount property cannot be smaller than zero";
        private const string MAXAMOUNT_SMALLER_THAN_ZERO = "The max amount property cannot be smaller than zero";
        private const string AMOUNT_BIGGER_THAN_MAXAMOUNT = "The amount property cannot be bigger than maxAmount";

        protected int stackAmount;
        public virtual int StackAmount
        {
            get
            {
                return stackAmount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_SMALLER_THAN_ZERO);

                if (value > MaxStackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_BIGGER_THAN_MAXAMOUNT);

                stackAmount = value;
            }
        }

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

                if (value < stackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_BIGGER_THAN_MAXAMOUNT);

                maxStackAmount = value;
            }
        }

        public override bool IsFull => StackAmount == MaxStackAmount && !IsEmpty;

        public override bool IsEmpty => Item == null || StackAmount == 0;

        /// <summary>
        /// Creates a basic Stack Slot with an amount and max amount
        /// </summary>
        /// <param name="currentItem">The current item to be added</param>
        /// <param name="amount">The amount of <paramref name="currentItem"/> to be added</param>
        /// <param name="maxStackAmount">The maximum permited amount of <paramref name="currentItem"/> to be added</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected BaseLazyStackSlot(T currentItem = default, int amount = 1, int maxStackAmount = 1) : base(currentItem)
        {
            if (currentItem == null)
            {
                amount = 0;
            }

            MaxStackAmount = maxStackAmount;
            StackAmount = amount;
        }

        /// <summary>
        /// Creates a basic Stack Slot based on a item array
        /// </summary>
        /// <param name="items">The items used to be added to</param>
        /// <param name="maxStack">The maximum permited amount of <paramref name="items"/> to be added</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected BaseLazyStackSlot(T[] items, int maxStack) : base(items.FirstOrDefault())
        {
            MaxStackAmount = maxStack;
            StackAmount = items?.Length ?? 0;
        }
    }
}
