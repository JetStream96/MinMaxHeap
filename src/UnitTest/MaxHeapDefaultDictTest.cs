using MinMaxHeap;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestFixture]
    public class MaxHeapDefaultDictTest
    {
        [Test]
        public void OrderIsCorrect()
        {
            var heap = new MaxHeap<int, int>(GetKeyValuePairs());

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(15, heap.ExtractMax().Value);
            Assert.AreEqual(9, heap.ExtractMax().Value);
            Assert.AreEqual(3, heap.ExtractMax().Value);
            Assert.AreEqual(2, heap.ExtractMax().Value);
            Assert.AreEqual(1, heap.ExtractMax().Value);
        }

        [Test]
        public void EnumeratorTest()
        {
            var items = GetKeyValuePairs();
            var heap = new MaxHeap<int, int>(items);
            Assert.IsTrue(heap.SetEquals(items));
        }

        [Test]
        public void KeysTest()
        {
            var items = new[]
            {
                new KeyValuePair<int, int>(3, 0),
                new KeyValuePair<int, int>(5, 10)
            };

            var heap = new MaxHeap<int, int>(items);
            Assert.IsTrue(heap.Keys.SetEquals(new[] { 3, 5 }));
        }

        [Test]
        public void ValuesTest()
        {
            var items = new[]
              {
                new KeyValuePair<int, int>(3, 0),
                new KeyValuePair<int, int>(5, 10)
            };

            var heap = new MaxHeap<int, int>(items);
            Assert.IsTrue(heap.Values.SetEquals(new[] { 0, 10 }));
        }

        [Test]
        public void TryGetValueShouldFindKey()
        {
            var heap = new MaxHeap<int, int>();
            heap.Add(3, 5);

            int val;
            Assert.IsTrue(heap.TryGetValue(3, out val));
            Assert.AreEqual(5, val);
        }

        [Test]
        public void TryGetValueShouldReturnFalse()
        {
            var heap = new MaxHeap<int, int>();
            heap.Add(3, 5);

            int val;
            Assert.IsFalse(heap.TryGetValue(0, out val));
        }

        [Test]
        public void IndexerTest()
        {
            var heap = new MaxHeap<int, int>();
            heap.Add(3, 5);

            Assert.AreEqual(5, heap[3]);
        }

        [Test]
        public void IndexerShouldThrow()
        {
            var heap = new MaxHeap<int, int>();

            Assert.Throws<KeyNotFoundException>(() =>
            {
                var val = heap[3];
            });
        }

        [Test]
        public void ChangeValueTest()
        {
            var heap = new MaxHeap<int, int>();
            heap.Add(3, 5);
            heap.ChangeValue(3, 10);
            Assert.AreEqual(10, heap[3]);
        }
        
        [Test]
        public void ContainsKeyTest()
        {
            var heap = new MaxHeap<int, int>();
            heap.Add(42, -1);
            Assert.IsTrue(heap.ContainsKey(42));
            Assert.IsFalse(heap.ContainsKey(-1));
        }

        [Test]
        public void GetMaxTest()
        {
            var heap = new MaxHeap<int, int>();
            heap.Add(42, -1);
            heap.Add(5, 6);
            var max = heap.Max;

            Assert.AreEqual(5, max.Key);
            Assert.AreEqual(6, max.Value);
        }

        [Test]
        public void ChangeValueShouldThrow()
        {
            var heap = new MaxHeap<int, int>();
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
