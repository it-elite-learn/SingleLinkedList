using List.Core;
using List.Core.EventArgs;

namespace List.Test.Unit
{
    public class ListTests
    {

        [Test]
        public void TestOneValuesHasLengthOne()
        {
            // Arrange
            var list = new SingleLinkedList<int>();

            // Act
            list.Add(1);

            // Assert
            Assert.IsTrue(list.Length == 1);
        }

        [Test]
        public void TestListInitialization()
        {
            // Arrange / Act
            SingleLinkedList<int> list = [10, 20, 30];

            // Assert
            Assert.IsTrue(list.Length == 3);
            Assert.That(list[0], Is.EqualTo(30));
            Assert.That(list[1], Is.EqualTo(20));
            Assert.That(list[2], Is.EqualTo(10));
        }

        [Test]
        public void TestNullCanBeInserted()
        {
            // Arrange
            var list = new SingleLinkedList<object>();

            // Act
            list.Add(null);

            // Assert
            Assert.IsTrue(list.Length == 1);
            Assert.AreEqual(list[0], null);
        }

        [Test]
        public void IndexerThrowsIndexOutOfRangeExceptionOnNegativIndex()
        {
            // Arrange
            var list = new SingleLinkedList<int>();

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => { _ = list[-1]; });
        }


        [Test]
        public void IndexerThrowsIndexOutOfRangeExceptionOnIndexToHigh()
        {
            // Arrange
            var list = new SingleLinkedList<int>();

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => { _ = list[0]; });
        }

        [Test]
        public void NewItemAddedEventGetsTriggered()
        {
            var list = new SingleLinkedList<int>();
            SingleLinkedList<int>? sendingList = default(SingleLinkedList<int>);
            ItemAddedEventArgs<int>? eventArgs = default(ItemAddedEventArgs<int>);
            list.OnItemAdded += (sender, args) =>
            {
                sendingList = sender as SingleLinkedList<int>;
                eventArgs = args;
            };

            list.Add(100);

            Assert.That(sendingList, Is.EqualTo(list));
            Assert.That(eventArgs?.Value, Is.EqualTo(100));
        }
    }
}