using NUnit.Framework;
using TheChest.Core.Tests.Slots.Factories;

namespace TheChest.Tests.Slots.Generics
{
    public abstract partial class ISlotTests<T>
        where T: new()
    {
        private SlotFactory<T> slotFactory;

        [SetUp]
        public void Setup()
        {
        }
    }
}
