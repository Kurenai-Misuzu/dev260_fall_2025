## Part A
### Tic-Tac-Toe
* Board Size: 3x3
### How to play
* Players take turns writing where on the board they want to put their symbol.
* To write place a symbol, write the name of the column and the row together. (Example: A1, B2, C3)
* A player wins if three of their symbols are in a row. Either vertically, diagonally, or horizontally.
* The game comes to a draw if the board is full and no player has achieved three symbols in a row.

## Part B
### Quick Sort
* Recursive quick sort was implimented as the sorting algorithm of choice.
* Pivot strategy used is middle.
* It used to be an end pivot strategy but I think this works as an effectively middle pivot strategy? I'm not so sure. Hopefully.
### 2D index
* 2 27x27 2D arrays hold the range in the normalized list for the locations of books. 
* This is 27x27 instead of 26x26 is becuase index 26 is used for books that start with numbers instead of letters.
* the start range Array holds the first index of the 2 letter pair in the sorted normalized array.
* the end range Array holds the last index + 1 of the 2 letter pair in the sorted normalized array.
* Instead of having to binary search through the hold normalized array for the list of books, it only needs to search the range given by the 2D index arrays. It is much faster.

### Lookup
* If the query that the user entered is not found at all then the algorithm looks for the next available slice.
* It goes through the 2d array and finds the next available slice with suggestions in the array.
* It will then take the starting range from the next available slice and spit out the next 5 suggestions in the sorted book array.
* This probably isnt' optimal but is the solution I came up with for suggestions.
* Ideally this algorithm gets faster whent there are more books.
* if the query entered has a valid slice, then a binary search will be executed for the exact string.
* if the exact string could not be found then every book in that valid slice are suggested to the user.

### Big-O
* Recursive Quicksort
    * On average O(n * log n)
    * This is because each partition pass is O(n)
    * Each partition pass splits the next partitions in 2 which causes O(log n)

    * On worst case it's O(n^2)
    * this happens if the partitions aren't split evenly due to the array already being mostly sorted or if the pivot is close to the ends. This leads to the partitions being huge and requiring a lot of pass throughs.

* Lookup
    * if the query found a valid slice (first 2 letters match) then finding the small subsection of valid books is only O(1)
    * A binary search is then done on that small group instead of the whole book array. it's O(log k) with a very small dataset.

    * if the query doesn't find a valid slice then the algorithm tries to find the next valid slice. At worst this is O(n^2). becuase of the way it's iterating through every slice to find one that's valid. However ideally with more books this should take less time. 
