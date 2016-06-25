using MinMaxHeap;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static UnitTest.Common;

namespace UnitTest
{
    [TestFixture]
    public class MinHeapCustomDictTest
    {
        [Test]
        public void AddCollectionCorrectly()
        {
            var collection = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(3, 3),
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(9, 9),
                new KeyValuePair<int, int>(15, 15),
                new KeyValuePair<int, int>(2, 2),
                new KeyValuePair<int, int>(12, 12),
                new KeyValuePair<int, int>(6, 6),
                new KeyValuePair<int, int>(-2, -2),
                new KeyValuePair<int, int>(0, 0),
            };

            var heap = new MinHeap<int, int, Dictionary<int, int>>(
                collection);

            Assert.AreEqual(9, heap.Count);
            VerifyHeapProperty(heap);
        }

        [Test]
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

            var heap = new MinHeap<int, int, Dictionary<int, int>>(
                collection,
                Comparer<int>.Create((x, y) => -x.CompareTo(y)));

            Assert.AreEqual(5, heap.Count);
            VerifyHeapProperty(heap);
        }

        [Test]
        public void CustomComparerCorrectOrdering()
        {
            var heap = new MinHeap<int, int, Dictionary<int, int>>(
                Comparer<int>.Create((x, y) => -x.CompareTo(y)));

            heap.Add(3, 3);
            heap.Add(1, 1);
            heap.Add(9, 9);
            heap.Add(15, 15);
            heap.Add(2, 2);

            Assert.AreEqual(5, heap.Count);
            VerifyHeapProperty(heap);
        }

        [Test]
        public void CountTest()
        {
            var heap = new MinHeap<int, int, Dictionary<int, int>>(
                Comparer<int>.Create((x, y) => -x.CompareTo(y)));

            Assert.AreEqual(0, heap.Count);

            heap.Add(3, 3);
            heap.Add(1, 1);

            Assert.AreEqual(2, heap.Count);

            heap.ExtractMin();

            Assert.AreEqual(1, heap.Count);
        }

        [Test]
        public void AddSameKeyThrowException()
        {
            var heap = new MinHeap<string, double,
                Dictionary<string, int>>();

            heap.Add("item1", 3.0);
            Assert.Throws<ArgumentException>(() =>
                heap.Add("item1", 4.0));
        }

        [Test]
        public void ExtractTest()
        {
            var collection = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(3, 3),
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(9, 9),
                new KeyValuePair<int, int>(15, 15),
                new KeyValuePair<int, int>(2, 2)
            };

            var heap = new MinHeap<int, int, Dictionary<int, int>>(
                collection);

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(1, heap.ExtractMin().Value);
            Assert.AreEqual(2, heap.ExtractMin().Value);
            Assert.AreEqual(3, heap.ExtractMin().Value);
            Assert.AreEqual(9, heap.ExtractMin().Value);
            Assert.AreEqual(15, heap.ExtractMin().Value);
        }

        [Test]
        public void ChangeValueKeyDoesNotExist()
        {
            var heap = new MinHeap<string, int,
                Dictionary<string, int>>();

            Assert.Throws<KeyNotFoundException>(() =>
                heap.ChangeValue("item1", 20));
        }

        [Test]
        public void ChangeValueTest()
        {
            var heap = new MinHeap<string, int,
                Dictionary<string, int>>();

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

        [Test]
        public void KeyRemovedAfterExtractMin()
        {
            var heap = new MinHeap<string, int,
               Dictionary<string, int>>();

            heap.Add("item1", 3);
            heap.ExtractMin();

            Assert.IsFalse(heap.ContainsKey("item1"));
        }

        [Test]
        public void ContainsKeyTest()
        {
            var heap = new MinHeap<string, int,
                Dictionary<string, int>>();

            heap.Add("item1", 3);
            heap.Add("item2", 4);
            heap.Add("item3", 8);

            Assert.IsTrue(heap.ContainsKey("item2"));
            Assert.IsFalse(heap.ContainsKey("item4"));
            Assert.Throws<ArgumentNullException>(() =>
            heap.ContainsKey(null));
        }

        [Test]
        public void IndexerTest()
        {
            var heap = new MinHeap<string, int,
                Dictionary<string, int>>();

            heap.Add("item1", 3);
            heap.Add("item2", 4);
            heap.Add("item3", 8);

            Assert.AreEqual(new KeyValuePair<string, int>("item3", 8),
                heap["item3"]);

            Assert.Throws<KeyNotFoundException>(() =>
            heap["item5"].ToString());
        }
        
        // Used for testing
        private void VerifyHeapProperty<TKey, TValue, TDictionary>(
            MinHeap<TKey, TValue, TDictionary> heap)
            where TDictionary : IDictionary<TKey, int>, new()
        {
            var list = GetField<List<KeyValuePair<TKey, TValue>>>(heap, "values");
            var comparer = GetField<IComparer<TValue>>(heap, "comparer");

            for (int i = 1; i <= list.Count / 2; i++)
            {
                if (i * 2 < list.Count)
                {
                    Assert.IsTrue(
                        comparer.Compare(list[i].Value, list[i * 2].Value) <= 0);
                }

                if (i * 2 + 1 < list.Count)
                {
                    Assert.IsTrue(
                        comparer.Compare(list[i].Value, list[i * 2 + 1].Value) <= 0);
                }
            }
        }

    }
}
