using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinMaxHeap.Tests
{
    [TestClass]
    public class MaxHeapDefaultDictTest
    {
        [TestMethod]
        public void OrderIsCorrect()
        {
            var collection = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(3, 3),
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(9, 9),
                new KeyValuePair<int, int>(15, 15),
                new KeyValuePair<int, int>(2, 2)
            };

            var heap = new MaxHeap<int, int>(
                collection);

            Assert.AreEqual(5, heap.Count);

            Assert.AreEqual(15, heap.ExtractMax().Value);
            Assert.AreEqual(9, heap.ExtractMax().Value);
            Assert.AreEqual(3, heap.ExtractMax().Value);
            Assert.AreEqual(2, heap.ExtractMax().Value);
            Assert.AreEqual(1, heap.ExtractMax().Value);
        }        
    }
}
