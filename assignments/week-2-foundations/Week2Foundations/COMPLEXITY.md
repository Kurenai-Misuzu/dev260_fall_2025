| Structure | Operation | Big-O (Avg) One sentence rationale
| ---------- | --------- | ----------- |
| Array | Access by Index | O(1). Arrays can be accessed instantly because arrays keep track of how many elements there are.| 
| Array | Search (Unsorted) | O(n). You have to go through n items to find what is needed. |
| List<T> | Add at end | Like an array, O(1). O(n) if list needs to be resized. |
| List<T> | Add at index | O(n) You have to shift everything past the index to the right. |
| Stack<T> | Push / Pop / Peek | O(1) because it uses an array internally. O(n) if resize needed. |
| Queue<T> | Enqueue / Dequeue / Peek | Same as stack I think. |
| Dictionary<K,V> | Add / Lookup / Remove | online it says it's o(1) on average. |
| Hashset<T> | Add / Contains / Remove | Since it uses hash table I think it's also O(1) on average.|