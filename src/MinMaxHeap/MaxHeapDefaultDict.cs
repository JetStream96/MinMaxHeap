using System.Collections.Generic;

namespace MinMaxHeap
{
    // A wrapper of MaxHeap<TKey, TValue, TDictionary>.
    // Uses Dictionary<TKey, int> as TDictionary.
    //
    public class MaxHeap<TKey, TValue>
    {
        private MaxHeap<TKey, TValue, Dictionary<TKey, int>> heap;

        public MaxHeap(IEnumerable<KeyValuePair<TKey, TValue>> items,
            IComparer<TValue> comparer)
        {
            heap = new MaxHeap<TKey, TValue, Dictionary<TKey, int>>(
                items, comparer);
        }

        public MaxHeap(IEnumerable<KeyValuePair<TKey, TValue>> items)
            : this(items, Comparer<TValue>.Default)
        { }

        public MaxHeap(IComparer<TValue> comparer)
            : this(new KeyValuePair<TKey, TValue>[0], comparer)
        { }

        public MaxHeap() : this(Comparer<TValue>.Default)
        { }

        public int Count
        {
            get
            {
                return heap.Count;
            }
        }

        public KeyValuePair<TKey, TValue> Max
        {
            get
            {
                return heap.Max;
            }
        }

        /// <summary>
        /// Extract the largest element.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public KeyValuePair<TKey, TValue> ExtractMax()
        {
            return heap.ExtractMax();
        }

        /// <summary>
        /// Insert the key and value.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Add(TKey key, TValue val)
        {
            heap.Add(key, val);
        }

        /// <summary>
        /// Modify the value corresponding to the given key.
        /// </summary>
        /// <exception cref="ArgumentNullException">Key is null.</exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public void ChangeValue(TKey key, TValue newValue)
        {
            heap.ChangeValue(key, newValue);
        }
    }
}
