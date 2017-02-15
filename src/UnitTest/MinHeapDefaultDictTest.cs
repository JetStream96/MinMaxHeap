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
            var collection = new[]
            {
                new KeyValuePair<int, int>(3, 3),
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(9, 9),
                new KeyValuePair<int, int>(15, 15),
                new KeyValuePair<int, int>(2, 2)
            };

            var heap = new MinHeap<int, int>(collection);

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(1, heap.ExtractMin().Value);
            Assert.AreEqual(2, heap.ExtractMin().Value);
            Assert.AreEqual(3, heap.ExtractMin().Value);
            Assert.AreEqual(9, heap.ExtractMin().Value);
            Assert.AreEqual(15, heap.ExtractMin().Value);
        }        
    }
}
