## Research: IReadOnlyDictionary & SortedDictionary

### 1. IReadOnlyDictionary<TKey, TValue>

From my research I understood that IReadOnlyDictionary is an interface used to represent a collection of key-value pairs that can be read but cannot be modified through this interface

It provides operations such as ContainsKey and Try GetValue so we can check whether a key exists and
retrieve its value

The main difference between Dictionary and IReadOnlyDictionary is that Dictionary allows us to add update
and remove entries while IReadOnlyDictionary does not expose these operations

For example imagine that I have a dictionary containing the prices of different courses My application
needs to allow other parts of the program to read these prices but they do not need to change them

In this case returning IReadOnlyDictionary instead of Dictionary makes more sense because the method
exposes only the operations that callers actually need

Another advantage is that the method does not force callers to depend on the concrete Dictionary implementation

However IReadOnlyDictionary does not guarantee that the underlying data can never change Another part of the program might still have a reference that allows it to modify the original dictionary

If I need stronger protection against modification I would consider returning a read-only wrapper or an immutable collection depending on the requirements

### 2. SortedDictionary<TKey, TValue>

SortedDictionary is a collection that stores key-value pairs and automatically keeps the entries sorted by their keys

The main difference between Dictionary and SortedDictionary is how they handle ordering

Dictionary is mainly designed for fast lookups using keys It does not guarantee that its entries will be enumerated in sorted key order

SortedDictionary on the other hand keeps its entries sorted by key so I can iterate through them in that order without sorting them separately

There is also a difference in performance:

- Dictionary provides O(1) average lookup time.
- SortedDictionary provides O(log n) lookup time.
- SortedDictionary maintains its ordering when entries are added or removed

This means that Dictionary is usually a better choice when I mainly need to find values quickly using their keys but SortedDictionary is more suitable when I need both key-based lookup and automatic ordering

For example if I am building a timetable where each session is stored using its start time as the key I would choose SortedDictionary because sessions must always be displayed in time order even when they are added at different times

### My conclusion

I would not choose a collection based only on its name or which one seems more advanced but I would first understand how the data will be used

If fast lookups are the main requirement ==> Dictionary is usually a good choice

If callers only need to read key-value pairs ==> I would consider IReadOnlyDictionary as the public return type

If maintaining sorted keys is important ==> I would choose SortedDictionary even though its lookups are generally slower than Dictionary lookups

## Pick the Collection

### S1 — Find a student by national ID thousands of times a day

Collection ==> Dictionary

I would use Dictionary because the national ID can be used as the key making it efficient to find a student without searching through every student one by one

### S2 — Keep course tags without storing duplicates

Collection ==> HashSet

I would use HashSet because it prevents duplicate tags from being stored and is designed for working with unique values

### S3 — Keep a student's grades in the order they were entered

Collection ==> List

I would use List because it preserves the order in which grades are added and allows the same grade to appear more than once

### S4 — Return a course price list that callers can only read

Collection ==> IReadOnlyDictionary

I would return IReadOnlyDictionary because callers need to read prices but should not receive dictionary modification operations through the returned interface

### S5 — Store timetable sessions by start time and always display them in time order

Collection ==> SortedDictionary

I would use SortedDictionary because it automatically keeps sessions ordered by their start-time keys even when new sessions are added in a different order

### S6 — Return results that the caller only loops over once and may stop reading early

Collection ==> IEnumerable

I would use IEnumerable because it allows the caller to iterate through the results without requiring a specific collection type and the caller can stop iterating whenever it has found what it needs

### My resources

1. Microsoft Learn — IReadOnlyDictionary<TKey, TValue>

URL ==> https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2

I used this documentation to understand what IReadOnlyDictionary represents which operations it provides and how it allows
callers to read key-value pairs without exposing modification methods through the interface

2. Microsoft Learn — SortedDictionary<TKey, TValue>

URL ==> https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2

I used this documentation to understand how SortedDictionary keeps entries sorted by key and how its lookup, insertion,
and removal performance compares with SortedList

3. David Guida — Comparing Lookup Performance in .NET

Author: David Guida

Published: February 14, 2024

URL ==> https://www.davidguida.net/lookup-performance

This article compares the lookup performance of Dictionary, SortedList, SortedDictionary, and HashSet and It helped me understand why Dictionary is usually
a better choice when fast lookups are the main requirement while sorted collections are useful when ordering matters

4. Stack Overflow — SortedList, SortedDictionary and Dictionary

URL ==> https://stackoverflow.com/questions/1427147/sortedlist-sorteddictionary-and-dictionary

I used this discussion to compare the practical differences between Dictionary and sorted collections, especially how
ordering affects the choice of collection
