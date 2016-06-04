using System.Collections.Generic;

namespace MinMaxHeap
{
    // A wrapper of MinHeap<TKey, TValue, TDictionary>.
    // Uses Dictionary<TKey, int> as TDictionary.
    //
    public class MinHeap<TKey, TValue>
    {
        private MinHeap<TKey, TValue, Dictionary<TKey, int>> heap;

        public MinHeap(IEnumerable<KeyValuePair<TKey, TValue>> items,
            IComparer<TValue> comparer)
        {
            heap = new MinHeap<TKey, TValue, Dictionary<TKey, int>>(
                items, comparer);
        }

        public MinHeap(IEnumerable<KeyValuePair<TKey, TValue>> items)
            : this(items, Comparer<TValue>.Default)
        { }

        public MinHeap(IComparer<TValue> comparer)
            : this(new KeyValuePair<TKey, TValue>[0], comparer)
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

        public KeyValuePair<TKey, TValue> Min
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
        public KeyValuePair<TKey, TValue> ExtractMin()
        {
            return heap.ExtractMin();
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

        /// <summary>
        /// Returns whether the key exists.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public bool ContainsKey(TKey key)
        {
            return heap.ContainsKey(key);
        }

        /// <summary>
        /// Gets the KeyValuePair correspoinding to the given key.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public KeyValuePair<TKey, TValue> this[TKey key]
        {
            get
            {
                return heap[key];
            }
        }
    }
}
