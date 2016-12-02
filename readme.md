# MinMaxHeap
C# implementation of min-heap and max-heap.

### Classes
* MinHeap&lt;T&gt;
* MinHeap&lt;TKey, TValue&gt;
* MinHeap&lt;TKey, TValue, TDictionary&gt;
* MaxHeap&lt;T&gt;
* MaxHeap&lt;TKey, TValue&gt;
* MaxHeap&lt;TKey, TValue, TDictionary&gt;

### Usage
```c#
    var heap = new MinHeap<int>();
    heap.Add(3);
    heap.Add(9);
    
    int x = heap.ExtractMin();  // Returns 3.
    int num = heap.Count;	    // Returns 1.
    int y = heap.ExtractMin();  // Returns 9.
```

```c#
    var heap = new MinHeap<string, int>();

    heap.Add("item1", 3);
    heap.Add("item2", 4);
    heap.Add("item3", 5);
    heap.ChangeValue("item2", 1);   // Now value of "item2" is 1.
    int x = heap.ExtractMin();      // Returns 1.
```

### Tests
All tests can be run with NUnit 3.

### License
Public domain.
