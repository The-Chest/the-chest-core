namespace TheChest.Core.Tests.Slots.Factories.Base
{
    public class BaseSlotItemFactory<T> : ISlotItemFactory<T>
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
