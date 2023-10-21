using TheChest.Core.Tests.Containers.Factories.Interfaces;
using TheChest.Core.Tests.Slots.Factories.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories.Generics.IContainerTests
{
    public abstract partial class IContainerTests<T>
    {
        protected Random random;
        protected readonly IContainerFactory<T> containerFaker;
        protected readonly ISlotIemFactory<T> itemFactory;

        protected const int MIN_SIZE_TEST = 10;
        protected const int MAX_SIZE_TEST = 20;

        protected IContainerTests(IContainerFactory<T> containerFaker, ISlotIemFactory<T> itemFactory)
        {
            this.containerFaker = containerFaker;
            this.itemFactory = itemFactory;
        }

        [SetUp]
        public void Setup()
        {
            this.random = new Random();
        }
    }
}
