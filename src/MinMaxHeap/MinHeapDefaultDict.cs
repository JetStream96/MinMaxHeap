using System.Collections.Generic;

namespace MinMaxHeap
{
    // A wrapper of MinHeap<TKey, TValue, TDictionary>.
    // Uses Dictionary<TKey, int> as TDictionary.
    //
    public class MinHeap<T, TValue>
    {
        private MinHeap<T, TValue, Dictionary<T, int>> heap;

        public MinHeap(IEnumerable<KeyValuePair<T, TValue>> items,
            IComparer<TValue> comparer)
        {
            heap = new MinHeap<T, TValue, Dictionary<T, int>>(
                items, comparer);
        }

        public MinHeap(IEnumerable<KeyValuePair<T, TValue>> items)
            : this(items, Comparer<TValue>.Default)
        { }

        public MinHeap(IComparer<TValue> comparer)
            : this(new KeyValuePair<T, TValue>[0], comparer)
        { }

        public MinHeap() : this(Comparer<TValue>.Default)
        { }

        public int Count
        {
            get
            {
                return heap.Count;
            }
        }

        public KeyValuePair<T, TValue> Min
        {
            get
            {
                return heap.Min;
            }
        }

        /// <summary>
        /// Extract the smallest element.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public KeyValuePair<T, TValue> ExtractMin()
        {
            return heap.ExtractMin();
        }

        /// <summary>
        /// Insert the key and value.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Add(T key, TValue val)
        {
            heap.Add(key, val);
        }

        /// <summary>
        /// Modify the value corresponding to the given key.
        /// </summary>
        /// <exception cref="ArgumentNullException">Key is null.</exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public void ChangeValue(T key, TValue newValue)
        {
            heap.ChangeValue(key, newValue);
        }
    }
}
