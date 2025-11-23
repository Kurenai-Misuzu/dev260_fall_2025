# Assignment 9: BST File System Navigator - Implementation Notes

**Name:** Dylan Verallo

## Binary Search Tree Pattern Understanding

**How BST operations work for file system navigation:**
[Explain your understanding of how O(log n) searches, automatic sorting through in-order traversal, and hierarchical file organization work together for efficient file management]

Answer: The BST allows quick finding of stuff becuse as the amount of data increases only a few steps are needed to get to that data. It also is convenient because the way a BST is storing things is based on it's order so it's easy to find things as well.

## Challenges and Solutions

**Biggest challenge faced:**
[Describe the most difficult part of the assignment - was it recursive tree algorithms, custom file/directory comparison logic, or complex BST deletion?]

Answer: the hardest part easily was figuring out the deletion of nodes in the BST.

**How you solved it:**
[Explain your solution approach and what helped you figure it out - research, debugging, testing strategies, etc.]

Answer: I spent a lot of time testing different situations deleting nodes that had stuff to their left or right and if their parents were to the left or right and even if they had all three cases of children. I also had to take a paper and draw out the BST steps to get this down correctly.

**Most confusing concept:**
[What was hardest to understand about BST operations, recursive thinking, or file system hierarchies?]

Answer: deletion

## Code Quality

**What you're most proud of in your implementation:**
[Highlight the best aspect of your code - maybe your recursive algorithms, custom comparison logic, or efficient tree traversal]

Answer: I think the most proud i am of in the assignment is the collect and traverse. The filter function delegate is really cool.

**What you would improve if you had more time:**
[Identify areas for potential improvement - perhaps better error handling, more efficient algorithms, or additional features]

Answer: the deletion algorithm. there is no way I did that the way that was intended. It works (i think...... i spent a lot of time testing) but it feels like a hack.

## Real-World Applications

**How this relates to actual file systems:**
[Describe how your implementation connects to tools like Windows File Explorer, macOS Finder, database indexing, etc.]

Answer: I'm guessing this is just how files are stored on your computer. I'm not so sure but that's what it seems like it.

**What you learned about tree algorithms:**
[What insights did you gain about recursive thinking, tree traversal, and hierarchical data organization?]

Answer: I think i got better about thinking in recursion in this project. I like tree traversal it's kinda cool


## Stretch Features

[If you implemented any extra credit features like file pattern matching or directory size analysis, describe them here. If not, write "None implemented"]

Answer: none implemented

## Time Spent

**Total time:** 7hrs

**Breakdown:**

- Understanding BST concepts and assignment requirements: 2hrs
- Implementing the 8 core TODO methods: 3hrs (2hrs on delete)
- Testing with different file scenarios: 30min
- Debugging recursive algorithms and BST operations: 1hr 15min
- Writing these notes: 15min

**Most time-consuming part:** deletion. i just found it difficult