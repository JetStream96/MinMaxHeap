using MinMaxHeap;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTest
{
    [TestFixture]
    public class MinHeapDefaultDictTest
    {
        [Test]
        public void OrderIsCorrect()
        {
            var heap = new MinHeap<int, int>(GetKeyValuePairs());

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(1, heap.ExtractMin().Value);
            Assert.AreEqual(2, heap.ExtractMin().Value);
            Assert.AreEqual(3, heap.ExtractMin().Value);
            Assert.AreEqual(9, heap.ExtractMin().Value);
            Assert.AreEqual(15, heap.ExtractMin().Value);
        }

        [Test]
        public void EnumeratorTest()
        {
            var items = GetKeyValuePairs();
            var heap = new MinHeap<int, int>(items);
            Assert.IsTrue(heap.SetEquals(items));
        }

        [Test]
        public void KeysTest()
        {
            var heap = new MinHeap<int, int>()
            {
                {3, 0}, {5, 10}
            };

            Assert.IsTrue(heap.Keys.SetEquals(new[] { 3, 5 }));
        }

        [Test]
        public void ValuesTest()
        {
            var heap = new MinHeap<int, int>()
            {
                {3, 0}, {5, 10}
            };

            Assert.IsTrue(heap.Values.SetEquals(new[] { 0, 10 }));
        }

        [Test]
        public void TryGetValueShouldFindKey()
        {
            var heap = new MinHeap<int, int>();
            heap.Add(3, 5);

            Assert.IsTrue(heap.TryGetValue(3, out int val));
            Assert.AreEqual(5, val);
        }

        [Test]
        public void TryGetValueShouldReturnFalse()
        {
            var heap = new MinHeap<int, int>();
            heap.Add(3, 5);

            int val;
            Assert.IsFalse(heap.TryGetValue(0, out val));
        }

        [Test]
        public void IndexerTest()
        {
            var heap = new MinHeap<int, int>();
            heap.Add(3, 5);

            Assert.AreEqual(5, heap[3]);
        }

        [Test]
        public void IndexerShouldThrow()
        {
            var heap = new MinHeap<int, int>();

            Assert.Throws<KeyNotFoundException>(() =>
            {
                var val = heap[3];
            });
        }

        [Test]
        public void ChangeValueTest()
        {
            var heap = new MinHeap<int, int>();
            heap.Add(3, 5);
            heap.ChangeValue(3, 10);
            Assert.AreEqual(10, heap[3]);
        }

        [Test]
        public void ContainsKeyTest()
        {
            var heap = new MinHeap<int, int>();
            heap.Add(42, -1);
            Assert.IsTrue(heap.ContainsKey(42));
            Assert.IsFalse(heap.ContainsKey(-1));
        }

        [Test]
        public void GetMinTest()
        {
            var heap = new MinHeap<int, int>();
            heap.Add(42, -1);
            heap.Add(5, 6);
            var Min = heap.Min;

            Assert.AreEqual(42, Min.Key);
            Assert.AreEqual(-1, Min.Value);
        }

        [Test]
        public void ChangeValueShouldThrow()
        {
            var heap = new MinHeap<int, int>();
            Assert.Throws<KeyNotFoundException>(() => heap.ChangeValue(3, 10));
        }

        private static KeyValuePair<int, int>[] GetKeyValuePairs()
        {
            return new[]
            {
                new KeyValuePair<int, int>(3, 3),
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(9, 9),
                new KeyValuePair<int, int>(15, 15),
                new KeyValuePair<int, int>(2, 2)
            };
        }
    }
}
