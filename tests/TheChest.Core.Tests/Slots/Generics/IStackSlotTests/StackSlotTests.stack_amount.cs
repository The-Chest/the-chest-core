namespace TheChest.Tests.Slots.Generics
{
    public abstract partial class StackSlotTests<T>
    {
        [Test]
        public void StackAmount_SmallerThanZero_ThrowsException()
        {
            Assert.That(
                () => this.slotFactory.WithItem(new T(), -1) ,
                Throws.Exception
                    .With.TypeOf(typeof(ArgumentOutOfRangeException))
                    .And.Message.StartsWith("The amount property cannot be smaller than zero")
            );
        }

        [Test]
        public void StackAmount_BiggerThanMaxAmount_ThrowsException()
        {
            var maxAmount = random.Next(10,20);
            Assert.That(
                () => this.slotFactory.WithItem(new T(), maxAmount, maxAmount + 1),
                Throws.Exception
                    .With.TypeOf(typeof(ArgumentOutOfRangeException))
                    .And.Message.StartsWith("The amount property cannot be bigger than maxAmount")
            );
        }
    }
}
