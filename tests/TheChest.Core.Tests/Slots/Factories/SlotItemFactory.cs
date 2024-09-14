namespace TheChest.Core.Tests.Slots.Factories
{
    public class SlotItemFactory<T> : ISlotItemFactory<T>
    {
        public T CreateDefault()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type);
            return (T)instance;
        }

        public T CreateRandom()
        {
            throw new NotImplementedException();
        }

        public T[] CreateMany(int amount)
        {
            return Enumerable.Repeat(CreateDefault(), amount).ToArray();
        }
    }
}
