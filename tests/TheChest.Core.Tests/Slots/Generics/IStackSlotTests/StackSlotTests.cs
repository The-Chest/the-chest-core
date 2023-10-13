using TheChest.Core.Tests.Slots.Factories.Interfaces;

namespace TheChest.Tests.Slots.Generics
{
    public abstract partial class StackSlotTests<T>
        where T : new() //TODO: remove new
    {
        protected readonly IStackSlotFactory<T> slotFactory;
        protected Random random;

        protected StackSlotTests(IStackSlotFactory<T> slotFactory)
        {
            this.slotFactory = slotFactory;
        }

        [SetUp]
        public void Setup()
        {
            random = new Random();
        }
    }
}
