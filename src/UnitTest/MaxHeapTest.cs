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

            Assert.IsTrue(heap.SetEquals(new[] { 1, 2, 3, 5, 9 }));
        }

        [Test]
        public void Ctor1Test()
        {
            var heap = new MaxHeap<int>();
            heap.Add(3);
            heap.Add(10);

            Assert.AreEqual(10, heap.Max);
        }

        [Test]
        public void Ctor2Test()
        {
            var heap = new MaxHeap<int>(Comparer<int>.Create((x, y) => x * x - y * y));
            heap.Add(3);
            heap.Add(-4);

            Assert.AreEqual(-4, heap.Max);
        }
    }
}
