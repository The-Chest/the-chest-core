using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots.Base
{
    /// <summary>
    /// Slot with with <see cref="IStackSlot{T}"/> implementation with a collection of items
    /// </summary>
    /// <typeparam name="T">The item collection inside the slot accepts</typeparam>
    public abstract class BaseStackSlot<T> : IStackSlot<T>
    {
        private const string ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT = "The item amount property cannot bigger than maxAmount";
        private const string MAXAMOUNT_SMALLER_THAN_ZERO = "The max amount property cannot be smaller than zero";
        private const string AMOUNT_BIGGER_THAN_MAXAMOUNT = "The amount property cannot be bigger than maxAmount";

        protected IReadOnlyCollection<T> content;
        public virtual ICollection<T> Content
        {
            get
            {
                return this.content.ToArray();
            }
            protected set
            {
                if(value == null)
                    throw new ArgumentNullException(nameof(value));

                if (value.Count > maxStackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT);

                this.content = value.ToArray();
            }
        }

        public virtual int StackAmount => this.Content.Count;

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

        public virtual bool IsFull => this.content.Count == this.maxStackAmount;

        public virtual bool IsEmpty => this.content.Count == 0;

        public virtual int Count => this.content.Count;

        protected BaseStackSlot(T[] items)
        {
            this.maxStackAmount = items.Length;
            this.Content = items;
        }

        protected BaseStackSlot(T[] items, int maxStackAmount)
        {           
            this.maxStackAmount = maxStackAmount;
            this.Content = items;
        }
    }
}
