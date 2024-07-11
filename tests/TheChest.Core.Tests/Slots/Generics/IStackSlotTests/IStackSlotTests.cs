using TheChest.Core.Tests.Slots.Factories.Interfaces;

namespace TheChest.Tests.Slots.Generics
{
    public abstract partial class IStackSlotTests<T>
    {
        protected readonly IStackSlotFactory<T> slotFactory;
        protected readonly ISlotItemFactory<T> itemFactory;
        protected Random random;

        protected IStackSlotTests(IStackSlotFactory<T> slotFactory, ISlotItemFactory<T> itemFactory)
        {
            this.slotFactory = slotFactory;
            this.itemFactory = itemFactory;
        }

        [SetUp]
        public void Setup()
        {
            random = new Random();
        }
    }
}
