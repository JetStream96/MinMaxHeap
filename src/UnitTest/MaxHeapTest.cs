using System.Collections.Generic;
using MinMaxHeap;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class MaxHeapTest
    {
        [Test]
        public void OrderIsCorrect()
        {
            var heap = new MaxHeap<int>(new[] { 3, 1, 9, 15, 2 });

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(15, heap.ExtractMax());
            Assert.AreEqual(9, heap.ExtractMax());
            Assert.AreEqual(3, heap.ExtractMax());
            Assert.AreEqual(2, heap.ExtractMax());
            Assert.AreEqual(1, heap.ExtractMax());
        }

        [Test]
        public void EnumeratorTest()
        {
            int[] collection = { 3, 1, 9, 15, 2 };
            var heap = new MaxHeap<int>(collection);

            heap.Add(5);
            heap.ExtractMax();

            Assert.IsTrue(new HashSet<int>(heap).SetEquals(new[] { 1, 2, 3, 5, 9 }));
        }
    }
}
