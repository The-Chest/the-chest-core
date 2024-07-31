namespace TheChest.Core.Tests.Slots.Factories
{
    public class SlotItemFactory<T> : ISlotItemFactory<T>
    {
        public T CreateItem()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type);
            return (T)instance;
        }

        public T[] CreateItems(int amount)
        {
            return Enumerable.Repeat(CreateItem(), amount).ToArray();
        }
    }
}
