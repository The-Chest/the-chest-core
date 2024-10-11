using TheChest.Core.Inventories.Dynamic.Actions;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Inventories.Dynamic.Containers
{
    public class DynamicInventory<T> : IDynamicInventory<T>
    {
        public ISlot<T> this[int index] => throw new NotImplementedException();

        public ISlot<T>[] Slots => throw new NotImplementedException();

        public int Size => throw new NotImplementedException();

        public bool IsFull => throw new NotImplementedException();

        public bool IsEmpty => throw new NotImplementedException();

        public void Execute(ISlotAction<T> action)
        {
            if(action == null) 
                throw new ArgumentNullException(nameof(action));

            if(action.CanExecute)
                action.Execute();
        }
    }
}
