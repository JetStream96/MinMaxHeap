using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MinMaxHeap.Tests
{
    [TestClass]
    public class MinHeapTest
    {
        [TestMethod]
        public void AddCollectionCorrectly()
        {
            var collection = new List<int>()
            {
                3, 1, 9, 15, 2
            };

            var heap = new MinHeap<int>(collection);

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(1, heap.ExtractMin());
            Assert.AreEqual(2, heap.ExtractMin());
            Assert.AreEqual(3, heap.ExtractMin());
            Assert.AreEqual(9, heap.ExtractMin());
            Assert.AreEqual(15, heap.ExtractMin());
        }

        [TestMethod]
        public void AddCollectionAndCustomComparerCorrectOrdering()
        {
            var collection = new List<int>()
            {
                3, 1, 9, 15, 2
            };

            var heap = new MinHeap<int>(
                collection,
                Comparer<int>.Create((x, y) => -x.CompareTo(y)));

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(15, heap.ExtractMin());
            Assert.AreEqual(9, heap.ExtractMin());
            Assert.AreEqual(3, heap.ExtractMin());
            Assert.AreEqual(2, heap.ExtractMin());
            Assert.AreEqual(1, heap.ExtractMin());
        }

        [TestMethod]
        public void CustomComparerCorrectOrdering()
        {
            var heap = new MinHeap<int>(
                Comparer<int>.Create((x, y) => -x.CompareTo(y)));

            heap.Add(3);
            heap.Add(1);
            heap.Add(9);
            heap.Add(15);
            heap.Add(2);

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(15, heap.ExtractMin());
            Assert.AreEqual(9, heap.ExtractMin());
            Assert.AreEqual(3, heap.ExtractMin());
            Assert.AreEqual(2, heap.ExtractMin());
            Assert.AreEqual(1, heap.ExtractMin());
        }

        [TestMethod]
        public void CountTest()
        {
            var heap = new MinHeap<int>(
                Comparer<int>.Create((x, y) => -x.CompareTo(y)));

            Assert.AreEqual(0, heap.Count);

            heap.Add(3);
            heap.Add(1);

            Assert.AreEqual(2, heap.Count);

            heap.ExtractMin();

            Assert.AreEqual(1, heap.Count);
        }        
    }
}
