namespace TheChest.Core.Tests.Slots.Factories.Interfaces
{
    public interface ISlotItemFactory<T>
    {
        T CreateItem();
        T[] CreateItems(int amount);
    }
}
