using System.Collections;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots.Base
{
    public class BaseStackSlot<T> : IStackSlot<T>
    {
        private const string ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT = "The item amount property cannot bigger than maxAmount";
        private const string MAXAMOUNT_SMALLER_THAN_ZERO = "The max amount property cannot be smaller than zero";
        private const string AMOUNT_BIGGER_THAN_MAXAMOUNT = "The amount property cannot be bigger than maxAmount";

        protected IReadOnlyCollection<T> item;
        public IReadOnlyCollection<T> Content
        {
            get
            {
                return this.item;
            }
            protected set
            {
                if(value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value.Count > maxStackAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), MAXAMOUNT_SMALLER_THAN_ZERO);
                }

                this.item = value;
            }
        }

        public int StackAmount => this.Content.Count;

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

        public bool IsFull => throw new NotImplementedException();

        public bool IsEmpty => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public BaseStackSlot(T[] items, int maxStackAmount = 1)
        {
            this.maxStackAmount = maxStackAmount;
            if(this.Content.Count > maxStackAmount)
            {
                throw new ArgumentOutOfRangeException(nameof(value), MAXAMOUNT_SMALLER_THAN_ZERO);
            }
            this.Content = Array.AsReadOnly(items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this.Content;
        }
    }
}
