using System.Collections.Generic;

namespace MinMaxHeap
{
    /// <typeparam name="TDictionary">
    /// Maps a key to the index of the corresponding KeyValuePair 
    /// in the list.</typeparam>
    public class MaxHeap<TKey, TValue, TDictionary>
        where TDictionary : IDictionary<TKey, int>, new()
    {
        MinHeap<TKey, TValue, TDictionary> minHeap;

        public MaxHeap(IEnumerable<KeyValuePair<TKey, TValue>> items,
            IComparer<TValue> comparer)
        {
            var negatedComparer = Comparer<TValue>.Create(
                (x, y) => comparer.Compare(y, x));

            minHeap = new MinHeap<TKey, TValue, TDictionary>(
                items, negatedComparer);
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
                return minHeap.Count;
            }
        }

        public KeyValuePair<TKey, TValue> Max
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
        public KeyValuePair<TKey, TValue> ExtractMax()
        {
            return minHeap.ExtractMin();
        }

        /// <summary>
        /// Insert the key and value.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Add(TKey key, TValue val)
        {
            minHeap.Add(key, val);
        }

        /// <summary>
        /// Modify the value corresponding to the given key.
        /// </summary>
        /// <exception cref="ArgumentNullException">Key is null.</exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public void ChangeValue(TKey key, TValue newValue)
        {
            minHeap.ChangeValue(key, newValue);
        }
    }
}
