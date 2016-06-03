using NUnit.Framework;
using System.Collections.Generic;

namespace MinMaxHeap.Tests
{
    [TestFixture]
    public class MaxHeapTest
    {
        [Test]
        public void OrderIsCorrect()
        {
            var collection = new List<int>()
            {
                3, 1, 9, 15, 2
            };

            var heap = new MaxHeap<int>(collection);

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(15, heap.ExtractMax());
            Assert.AreEqual(9, heap.ExtractMax());
            Assert.AreEqual(3, heap.ExtractMax());
            Assert.AreEqual(2, heap.ExtractMax());
            Assert.AreEqual(1, heap.ExtractMax());
        }        
    }
}
