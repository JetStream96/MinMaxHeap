using System.Collections.Generic;

namespace MinMaxHeap
{
    public class MaxHeap<T>
    {
        MinHeap<T> minHeap;

        public MaxHeap(IEnumerable<T> items, IComparer<T> comparer)
        {
            var negatedComparer = Comparer<T>.Create(
                (x, y) => comparer.Compare(y, x));

            minHeap = new MinHeap<T>(items, negatedComparer);
        }

        public MaxHeap(IEnumerable<T> items)
            : this(items, Comparer<T>.Default)
        { }

        public MaxHeap(IComparer<T> comparer)
            : this(new T[0], comparer)
        { }

        public MaxHeap() : this(Comparer<T>.Default)
        { }

        public int Count
        {
            get
            {
                return minHeap.Count;
            }
        }

        public T Max
        {
            get
            {
                return minHeap.Min;
            }
        }

        /// <summary>
        /// Extract the largest element.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public T ExtractMax()
        {
            return minHeap.ExtractMin();
        }

        /// <summary>
        /// Insert the value.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Add(T item)
        {
            minHeap.Add(item);
        }
    }
}
