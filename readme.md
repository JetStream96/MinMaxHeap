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
    var heap = new MinHeap&lt;int&gt;();
    heap.Add(3);
    heap.Add(9);
    
    int elem = heap.ExtractMin();
    int num = heap.Count;
```

```c#
    var heap = new MinHeap&lt;string, int,
                Dictionary&lt;string, int&gt;&gt;();

    heap.Add("item1", 3);
    heap.Add("item2", 4);

    heap.ChangeValue("item2", 1);
```

### Tests
All tests can be run with NUnit 3.

### License
This is dedicated to public domain.
