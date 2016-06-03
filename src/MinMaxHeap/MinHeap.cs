using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxHeap
{
    public class MinHeap<TKey, TValue, TDictionary>
        where TDictionary : IDictionary<TKey, int>, new()
    {
        List<KeyValuePair<TKey, TValue>> values;
        TDictionary dict;
        IComparer<TValue> comparer;

        public MinHeap(IEnumerable<KeyValuePair<TKey, TValue>> items,
            IComparer<TValue> comparer)
        {
            values = new List<KeyValuePair<TKey, TValue>>();
            dict = new TDictionary();
            this.comparer = comparer;
            values.Add(new KeyValuePair<TKey, TValue>());
            values.AddRange(items);

            for (int i = values.Count / 2; i >= 1; i--)
            {
                bubbleDown(i);
            }
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
                return values.Count - 1;
            }
        }

        public KeyValuePair<TKey, TValue> Min
        {
            get
            {
                return values[1];
            }
        }

        /// <summary>
        /// Extract the smallest element.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public KeyValuePair<TKey, TValue> ExtractMin()
        {
            int count = Count;

            if (count == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            var min = Min;
            values[1] = values[count];
            values.RemoveAt(count);

            if (values.Count > 1)
            {
                dict[values[1].Key] = 1;
                bubbleDown(1);
            }

            return min;
        }

        /// <summary>
        /// Insert the key and value.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Add(TKey key, TValue val)
        {
            dict.Add(key, values.Count);
            values.Add(new KeyValuePair<TKey, TValue>(key, val));
            bubbleUp(Count);
        }

        /// <summary>
        /// Modify the value corresponding to the given key.
        /// </summary>
        /// <exception cref="ArgumentNullException">Key is null.</exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public void ChangeValue(TKey key, TValue newValue)
        {
            int index = dict[key];
            int compareVal = comparer.Compare(newValue, values[index].Value);
            values[index] = new KeyValuePair<TKey, TValue>(
                values[index].Key, newValue);

            if (compareVal > 0)
            {
                bubbleDown(index);
            }
            else if (compareVal < 0)
            {
                bubbleUp(index);
            }
        }

        private void bubbleUp(int index)
        {
            int parent = index / 2;

            while (
                index > 1 &&
                comparer.Compare(values[parent].Value, values[index].Value) > 0)
            {
                exchange(index, parent);
                index = parent;
                parent = index / 2;
            }
        }

        private void bubbleDown(int index)
        {
            int min;

            while (true)
            {
                int left = index * 2;
                int right = index * 2 + 1;

                if (left < values.Count &&
                    comparer.Compare(values[left].Value, values[index].Value) < 0)
                {
                    min = left;
                }
                else
                {
                    min = index;
                }

                if (right < values.Count &&
                    comparer.Compare(values[right].Value, values[min].Value) < 0)
                {
                    min = right;
                }

                if (min != index)
                {
                    exchange(index, min);
                }
                else
                {
                    return;
                }
            }
        }

        private void exchange(int index, int max)
        {
            var tmp = values[index];
            values[index] = values[max];
            values[max] = tmp;

            dict[values[index].Key] = index;
            dict[values[max].Key] = max;
        }
    }
}
