using NUnit.Framework;
using TheChest.Core.Tests.Slots.Factories.Interfaces;

namespace TheChest.Tests.Slots.Generics
{
    public abstract partial class ISlotTests<T>
        where T: new() //TODO: remove new
    {
        protected readonly ISlotFactory<T> slotFactory;

        protected ISlotTests(ISlotFactory<T> slotFactory)
        {
            this.slotFactory = slotFactory;
        }

        [SetUp]
        public void Setup()
        {
        }
    }
}
