namespace TheChest.Core.Tests.Slots.Factories.Interfaces
{
    public interface ISlotIemFactory<T>
    {
        T CreateItem();
        T[] CreateItems(int amount);
    }
}
