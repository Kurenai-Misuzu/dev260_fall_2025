# Assignment 8: Spell Checker & Vocabulary Explorer - Implementation Notes

**Name:** Dylan Verallo

## HashSet Pattern Understanding

**How HashSet<T> operations work for spell checking:**
The O(1) lookup is useful for fast searching of the hashset and allows for the user to loook up if a word is correctly very fast even if there are a lot of words in the dictionary. The automatic uniqueness is nice becuase that means there is only one copy of each words in the hashset.

## Challenges and Solutions

**Biggest challenge faced:**
The hardest part about this was making sure that the words in the dictionary were properly added. I feel as if it was giving me duplicate words at one point.

**How you solved it:**
I had to make sure that each character was deleting punctuation becuase sometimes a word would be duplicated if there was punctuation at the end.

**Most confusing concept:**
The confusing part was why we used contains instead of intersect.

## Code Quality

**What you're most proud of in your implementation:**
I think the thing im the most proud of in the implementation is implementing the word analysis because it was cool learning how to use the regex replace.

**What you would improve if you had more time:**
I would probably use a dictionary that had more words.

## Testing Approach

**How you tested your implementation:**
I cross referenced with tools online that checked how many unique words was in the dictionary to make sure I was getting the corrct amount of words added and unique words. I also made sure to delete files just to see what happens when they got deleted

**Test scenarios you used:**
I deleted the dictionary file and I also made sure to try analyzing a file that didn't exist.

**Issues you discovered during testing:**
Dictionary doesn't have a lot of files so that there is a lot of words are counted as not correct. 

## HashSet vs List Understanding

**When to use HashSet:**
You would use a hashset over a list when you need to find something quickly

**When to use List:**
You would use a list when you know you'll have a lot of additions and deletions and also when you need sequential access. a hashset does not sort things.

**Performance benefits observed:**
a dictionary has a ton more words so that looking through a dictionary in o(1) time is very nice. 

## Real-World Applications

**How this relates to actual spell checkers:**
Document programs have dictionaries that check your every word and let you know if something is not in the dictionary. It also gives you suggestions about what word you might have been trying to spell.

**What you learned about text processing:**
It's very finnicky especially if dealing with punctuation. and especially with other languages.

## Stretch Features

none implemented

## Time Spent

**Total time:** 3hrs

**Breakdown:**
- Understanding HashSet concepts and assignment requirements: 1hrs
- Implementing the 6 core methods: 1hrs
- Testing different text files and scenarios: 0.5hrs
- Debugging and fixing issues: 0.25hrs
- Writing these notes: 10 mins

**Most time-consuming part:** Double checkig the dictionary making sure that words were unique

## Key Learning Outcomes

**HashSet concepts learned:**
Hashsets are nice to use with it's uniqueness and o(1)

**Text processing insights:**
It's very important to normalize words or else some words mght be counted as duplicates when not intended to.

**Software engineering practices:**
It's important to handle deleted files. 