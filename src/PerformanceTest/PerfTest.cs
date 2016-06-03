using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinMaxHeap;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PerformanceTest
{
    [TestClass]
    public class PerfTest
    {
        [TestMethod]
        public void AddTest()
        {
            var heap = new MinHeap<int, int, Dictionary<int, int>>();

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 10000000; i++)
            {
                heap.Add(i, i);
            }

            sw.Stop();

            Console.WriteLine("Add elements took {0} ms.",
                sw.ElapsedMilliseconds);
        }

        [TestMethod]
        public void ExtractMinTest()
        {
            var col = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < 1000000; i++)
            {
                col.Add(new KeyValuePair<int, int>(i, i));
            }

            var heap = new MinHeap<int, int, Dictionary<int, int>>(col);

            var sw = new Stopwatch();
            sw.Start();

            int result = 0;

            for (int i = 0; i < 1000000; i++)
            {
                result += heap.ExtractMin().Value;
            }

            sw.Stop();
            
            Console.WriteLine("ExtractMin took {0} ms.",
                sw.ElapsedMilliseconds);
        }
    }
}
