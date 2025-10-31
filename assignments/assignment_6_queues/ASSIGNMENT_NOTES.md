# Assignment 6: Game Matchmaking System - Implementation Notes

**Name:** Dylan Verallo

## Multi-Queue Pattern Understanding

**How the multi-queue pattern works for game matchmaking:**
the three different queues work together because each player will want a different experience when playing the game. When a player picks ranked, they want to play with someone close to their skill level. When a player picks casual, they don't care they just want to play. Quick play should be a decent mix between both of those experiences.

## Challenges and Solutions

**Biggest challenge faced:**
I think the biggest challenge of this assignment was the skill based matchmaking.

**How you solved it:**
the hardest part for me was understanding how to search through the queue and get players without sorting the queue. I learned that I could make a temp list and use that as player 1 and have the queue be player 2. That way i can easily compare without having to have 2 indexes in the queue or sorting the queue.

**Most confusing concept:**
I think the most confusing concept was understanding quickplay because it involved both raw matching and skill based matchmaking.

## Code Quality

**What you're most proud of in your implementation:**
I'm most proud about implementing skill based matchmaking

**What you would improve if you had more time:**
I'd like to have a bit of a more elegant solution when implementing skill based matchmaking. the method I used seems kind of like a hack.

## Testing Approach

**How you tested your implementation:**
I made sure to pair up players of different skill levels and then players against players again when their skill levels changed after wins and losses.

**Test scenarios you used:**
- putting skill 1 and skill 3 in casual (matches)
- putting skill 10 and skill 1 in casual (matches)
- putting skill 10 and skill 8 in ranked (matches)
- putting skill 10 and skill 1 in ranked (no match)
- putting skill 10 and skill 1 in quickplay with 5 players in queue (match)

**Issues you discovered during testing:**
initially when i requeued a player they were still in queue because I forgot to use leavequeue so I had to slot that in somewhere

## Game Mode Understanding

**Casual Mode matching strategy:**
I just take the first 2 players in the Queue and set those as player 1 and player 2

**Ranked Mode matching strategy:**
i made a copy of the queue and turned it into a list. i would then make the list be player 1 then compare the skill rating of p1 to whoever is next in the queue that has a valid skill rating. Then whoever was valid would be p2. then they are both removed from the queue and placed into a match.

**QuickPlay Mode matching strategy:**
if less than 4 players in the queue, then i take the implementation from ranked mode and copy it over. if there are more than 4 players i take the implementation from casual mode and use that.

## Real-World Applications

**How this relates to actual game matchmaking:**
you need skill based matchmaking in ranked modes in video games and in quick play you still want some sort of sbmm  but prioritize speed. in casual modes no one cares about skill level.

**What you learned about game industry patterns:**
it's very important or your players can get frustrated.

## Stretch Features

none implemented

## Time Spent

**Total time:** 4 hours

**Breakdown:**

- Understanding the assignment and queue concepts: 1.5 hrs
- Implementing the 6 core methods: 2 hrs
- Testing different game modes and scenarios: .25 hrs
- Debugging and fixing issues: .25 hrs
- Writing these notes: .05 hrs

**Most time-consuming part:** implenting sbmm and reading through all the classes to find out about each class's variables and methods

## Key Learning Outcomes

**Queue concepts learned:**
managing multiple queues takes a lot of effort. I'd imagine in a big game studio it would take up a lot of resources

**Algorithm design insights:**
designing something similar but with slightly different requirements still takes a lot of time

**Software engineering practices:**
I have much to learn
