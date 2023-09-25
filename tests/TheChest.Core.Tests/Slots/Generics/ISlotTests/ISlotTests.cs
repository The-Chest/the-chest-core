using NUnit.Framework;
using TheChest.Core.Tests.Slots.Factories.Interfaces;

namespace TheChest.Tests.Slots.Generics
{
    public abstract partial class ISlotTests<T>
        where T: new() //TODO: remove new
    {
        private ISlotFactory<T> slotFactory;

        [SetUp]
        public void Setup()
        {
        }
    }
}
