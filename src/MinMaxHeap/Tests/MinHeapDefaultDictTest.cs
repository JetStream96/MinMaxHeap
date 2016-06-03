using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinMaxHeap.Tests
{
    [TestClass]
    public class MinHeapDefaultDictTest
    {
        [TestMethod]
        public void AddCollectionCorrectly()
        {
            var collection = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(3, 3),
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(9, 9),
                new KeyValuePair<int, int>(15, 15),
                new KeyValuePair<int, int>(2, 2)
            };

            var heap = new MinHeap<int, int>(
                collection);

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(1, heap.ExtractMin().Value);
            Assert.AreEqual(2, heap.ExtractMin().Value);
            Assert.AreEqual(3, heap.ExtractMin().Value);
            Assert.AreEqual(9, heap.ExtractMin().Value);
            Assert.AreEqual(15, heap.ExtractMin().Value);
        }

        [TestMethod]
        public void AddCollectionAndCustomComparerCorrectOrdering()
        {
            var collection = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(3, 3),
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(9, 9),
                new KeyValuePair<int, int>(15, 15),
                new KeyValuePair<int, int>(2, 2)
            };

            var heap = new MinHeap<int, int>(
                collection,
                Comparer<int>.Create((x, y) => -x.CompareTo(y)));

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(15, heap.ExtractMin().Value);
            Assert.AreEqual(9, heap.ExtractMin().Value);
            Assert.AreEqual(3, heap.ExtractMin().Value);
            Assert.AreEqual(2, heap.ExtractMin().Value);
            Assert.AreEqual(1, heap.ExtractMin().Value);
        }

        [TestMethod]
        public void CustomComparerCorrectOrdering()
        {
            var heap = new MinHeap<int, int>(
                Comparer<int>.Create((x, y) => -x.CompareTo(y)));

            heap.Add(3, 3);
            heap.Add(1, 1);
            heap.Add(9, 9);
            heap.Add(15, 15);
            heap.Add(2, 2);

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(15, heap.ExtractMin().Value);
            Assert.AreEqual(9, heap.ExtractMin().Value);
            Assert.AreEqual(3, heap.ExtractMin().Value);
            Assert.AreEqual(2, heap.ExtractMin().Value);
            Assert.AreEqual(1, heap.ExtractMin().Value);
        }

        [TestMethod]
        public void CountTest()
        {
            var heap = new MinHeap<int, int>(
                Comparer<int>.Create((x, y) => -x.CompareTo(y)));

            Assert.AreEqual(0, heap.Count);

            heap.Add(3, 3);
            heap.Add(1, 1);

            Assert.AreEqual(2, heap.Count);

            heap.ExtractMin();

            Assert.AreEqual(1, heap.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSameKeyThrowException()
        {
            var heap = new MinHeap<string, double>();

            heap.Add("item1", 3.0);
            heap.Add("item1", 4.0);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ChangeValueKeyDoesNotExist()
        {
            var heap = new MinHeap<string, int>();

            heap.ChangeValue("item1", 20);
        }

        [TestMethod]
        public void ChangeValueTest()
        {
            var heap = new MinHeap<string, int>();

            heap.Add("item1", 3);
            heap.Add("item2", 4);
            heap.Add("item3", 8);
            heap.Add("item4", 10);
            heap.Add("item5", 1);
            heap.Add("item6", 2);

            heap.ChangeValue("item2", 20);
            heap.ChangeValue("item6", 0);

            Assert.AreEqual(0, heap.ExtractMin().Value);
            Assert.AreEqual(1, heap.ExtractMin().Value);
            Assert.AreEqual(3, heap.ExtractMin().Value);
            Assert.AreEqual(8, heap.ExtractMin().Value);
            Assert.AreEqual(10, heap.ExtractMin().Value);
            Assert.AreEqual(20, heap.ExtractMin().Value);
        }
    }
}
