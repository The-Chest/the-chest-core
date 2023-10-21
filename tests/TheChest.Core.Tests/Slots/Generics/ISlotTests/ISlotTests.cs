using TheChest.Core.Tests.Slots.Factories.Interfaces;

namespace TheChest.Tests.Slots.Generics
{
    public abstract partial class ISlotTests<T>
    {
        protected readonly ISlotFactory<T> slotFactory;
        protected readonly ISlotIemFactory<T> itemFactory;

        protected ISlotTests(ISlotFactory<T> slotFactory, ISlotIemFactory<T> itemFactory)
        {
            this.slotFactory = slotFactory;
            this.itemFactory = itemFactory;
        }

        [SetUp]
        public void Setup()
        {
        }
    }
}
