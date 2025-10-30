# Assignment 5: Browser Navigation System - Implementation Notes

**Name:** Dylan Verallo

## Dual-Stack Pattern Understanding

**How the dual-stack pattern works for browser navigation:**
basically there is a current page. the stack stores the previous pages. backstack stores the pages that the user previously went to. and the forward stack stores pages that the user was on before the user pressed on the back button on their browser. if a user presses on the back button backstack will be popped while frontstack is pushed. if the user presses forward button then frontstack is popped while backstack is pushed. if another website pressed then backstack will be pushed while the frontstack is cleared.

## Challenges and Solutions

**Biggest challenge faced:**
biggest challenge faced was the first implementing next page button.

**How you solved it:**
I then solved it by thihking about why backstack needed to be pushed. I then remembered that i had to push to backstack so i can still go back to the previous page if needed. 

**Most confusing concept:**
why I needed two stacks in the first place. I honeslty forgot taht you can go to next page in your browser.

## Code Quality

**What you're most proud of in your implementation:**
I think the best thing I implemented was adding guard clasuses in the methods to hopefully protect against user error.

**What you would improve if you had more time:**
probably even more guard clasuses.

## Testing Approach

**How you tested your implementation:**
i ran the program multiple times making sure i tried unexpected input from the user. 

**Issues you discovered during testing:**
the first bugs i fixed were related to the forward stack not working. i tried to copy from my back stack code and I realize i forgot to reverse the way the code workd.

## Stretch Features

none implemented

## Time Spent

**Total time:** [2.1 hours]

**Breakdown:**

- Understanding the assignment: [.25 hours]
- Implementing the 6 methods: [1.5 hours]
- Testing and debugging: [.25 hours]
- Writing these notes: [.1 hours]

**Most time-consuming part:** [implementing the code]
