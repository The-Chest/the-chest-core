namespace TheChest.Core.Tests.Slots.Factories.Generics.IContainerTests
{
    public abstract partial class IContainerTests<T>
    {
        [Test]
        public void Size_NoInitialValue_SetsSizeToTwenty()
        {
            var container = this.containerFaker.EmptyContainer();

            Assert.That(container.Size, Is.EqualTo(20));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Size_InitialValueInvalid_Throws(int size)
        {
            Assert.That(
                () => this.containerFaker.EmptyContainer(size),
                Throws.Exception.With.TypeOf(typeof(ArgumentOutOfRangeException))
                .And.Message.StartsWith($"Invalid Container Size : {size}")
            );
        }

        [Test]
        public void Size_ReturnsSlotsLength()
        {
            var container = this.containerFaker.EmptyContainer();

            Assert.That(container.Size, Is.EqualTo(container.Slots.Length));
        }

        [Test]
        public void Size_NullSlots_ReturnsZero()
        {
            var container = this.containerFaker.EmptyContainer();

            Assert.That(container.Size, Is.EqualTo(0));
        }
    }
}
