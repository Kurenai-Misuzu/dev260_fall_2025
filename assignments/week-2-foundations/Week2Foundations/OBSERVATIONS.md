# Observations
## Times (n = 250000)
* List.Contains(N-1): 0.556 ms
* Hashset.Contains(N-1): 0.408 ms
* Dictionary.ContainsKey(N-1): 0.012 ms
* List.Contains(-1): 0.040 ms
* Hashset.Contains(-1): 0.011 ms
* Dictionary.ContainsKey(N-1): 0.009 ms
## Thoughts
I'm not surprised that the list took the longest because It has to go through every node in the list to check where the item is. 

Though, I am surprised to see that List.Contains(-1) is super fast. There might be some optimizations happening because this should've taken around the same time as List.Contains(n-1).

I'm also surprised hashset took a long time becuase I read online that searching a hashset should be an average of O(1). Maybe there were lots of hash collisions.

I'm not surprised that dictionaries ended up being the fastest. I think that having a key similar to an index helps the speed of a dictionary a lot.

I think if I had to store a lot of data and had a key I would probably heavily consider using a dictionary because of this test. Though, if I didn't have a key that I could use for the dictionary, then I might go ahead and use a hashset. It still feels a little faster than a list.