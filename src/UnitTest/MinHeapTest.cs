using MinMaxHeap;
using NUnit.Framework;
using System.Collections.Generic;
using static UnitTest.Common;

namespace UnitTest
{
    [TestFixture]
    public class MinHeapTest
    {
        [Test]
        public void AddCollectionCorrectly()
        {
            var collection = new List<int>()
            {
                3, 1, 9, 15, 2
            };

            var heap = new MinHeap<int>(collection);

            Assert.AreEqual(5, heap.Count);
            VerifyHeapProperty(heap);
        }

        [Test]
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
            VerifyHeapProperty(heap);
        }

        [Test]
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
            VerifyHeapProperty(heap);
        }

        [Test]
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

        [Test]
        public void ExtractMinTest()
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

        private void VerifyHeapProperty<T>(
            MinHeap<T> heap)
        {
            var list = GetField<List<T>>(heap, "values");
            var comparer = GetField<IComparer<T>>(heap, "comparer");

            for (int i = 1; i <= list.Count / 2; i++)
            {
                if (i * 2 < list.Count)
                {
                    Assert.IsTrue(
                        comparer.Compare(list[i], list[i * 2]) <= 0);
                }

                if (i * 2 + 1 < list.Count)
                {
                    Assert.IsTrue(
                        comparer.Compare(list[i], list[i * 2 + 1]) <= 0);
                }
            }
        }
    }
}
