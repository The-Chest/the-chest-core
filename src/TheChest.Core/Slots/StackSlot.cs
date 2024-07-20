using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Slot with with <see cref="IStackSlot{T}"/> implementation with a collection of items
    /// </summary>
    /// <typeparam name="T">The item collection inside the slot accepts</typeparam>
    public class StackSlot<T> : IStackSlot<T>
    {
        private const string ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT = "The item amount property cannot bigger than maxAmount";
        private const string MAXAMOUNT_SMALLER_THAN_ZERO = "The max amount property cannot be smaller than zero";
        private const string AMOUNT_BIGGER_THAN_MAXAMOUNT = "The amount property cannot be bigger than maxAmount";

        protected ICollection<T> content;
        public virtual ICollection<T> Content
        {
            get
            {
                return content;
            }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                if (value.Count > maxStackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT);

                content = value;
            }
        }

        public virtual int StackAmount => Content.Count;

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

        public virtual bool IsFull => content.Count == maxStackAmount;

        public virtual bool IsEmpty => content.Count == 0;

        protected StackSlot(T[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            maxStackAmount = items.Length;
            content = items;
        }

        protected StackSlot(T[] items, int maxStackAmount)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (items.Length > maxStackAmount)
                throw new ArgumentOutOfRangeException(nameof(items), ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT);

            this.maxStackAmount = maxStackAmount;
            content = items;
        }
    }
}
