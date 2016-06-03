# MinMaxHeap
C# implementation of min-heap and max-heap.

### Classes
* MinHeap<T>
* MinHeap<TKey, TValue>
* MinHeap<TKey, TValue, TDictionary>
* MaxHeap<T>
* MaxHeap<TKey, TValue>
* MaxHeap<TKey, TValue, TDictionary>
### Usage
```
    var heap = new MinHeap<int>();
    heap.Add(3);
    heap.Add(9);
    
    int elem = heap.ExtractMin();
    int num = heap.Count;
```

```
    var heap = new MinHeap<string, int,
                Dictionary<string, int>>();

    heap.Add("item1", 3);
    heap.Add("item2", 4);

    heap.ChangeValue("item2", 1);
```
### Tests
All tests can be run with NUnit 3.
### License
This is dedicated to public domain.
