namespace TheChest.Core.Inventories.Dynamic.Actions
{
    public interface ISlotAction<T>
    {
        bool CanExecute { get; }
        void Execute();
    }
}
