# Project Design & Rationale

**Instructions:** Replace prompts with your content. Be specific and concise. If something doesn't apply, write "N/A" and explain briefly.

---

## Data Model & Entities

**Core entities:**  
_List your main entities with key fields, identifiers, and relationships (1–2 lines each)._

**Your Answer:**

**Entity A:**

- Name: Player
- Key fields:
    - Short name
    - Long name
    - jersey number
- Identifiers: Long name (KEY)
- Relationships: N/A

**Identifiers (keys) and why they're chosen:**  
Long Name (full name) is the key in this program becuase 2 players might have the same jersey number or last name (short name). Long name was the closest thing I could have to a unique KEY for the user.

---

## Data Structures — Choices & Justification
### Structure #1

**Chosen Data Structure:**  
HashSet<Player> playerList;

**Purpose / Role in App:**  
This stores the available players and their stats. This is the main data structure of the program.

**Why it fits:**  
it fits because we want automatic uniqueness with each element in the data structure. It is also O(1) to check if a player is in the data structure.

**Alternatives considered:**  
List<Player>. I didn't choose it becuase I think it could be a little slower than a hashset and I think I have better use for List<Player> later. 
BinarySearchTree<Player>. I didn't choose it becuase implementation would've taken more time. 

---

### Structure #2

**Chosen Data Structure:**  
List<Player> team1;

**Purpose / Role in App:**  
Holds the players in a team.

**Why it fits:**  
It fits because I know there would've been a small amount of data and it would be easy to remove and delete data.

**Alternatives considered:**  
Stack<Player>. I think having index access is nice so I didn't choose stack.
Player[]. I didn't choose an array because I wanted to be able to remove data easily.

---

### Structure #3

**Chosen Data Structure:**  
Queue<Player> statsQueue;

**Purpose / Role in App:**  
This is a queue of players so that their stats can be displayed on the stats screen of the broadcast.

**Why it fits:**  
A queue fits because of it being FIFO. It's easy for data entry to add players in the order of display that they want.

**Alternatives considered:**  
None

---

## Comparers & String Handling

**Comparer choices:**  
StringComparer.IgnoreOrdinalCase was the main way strings were compared

I used long name (full name) as a key because some players might have the same jersey number or short name (last name)

**Normalization rules:**  
Trim whitespace then compare using IgnoreOrdinalCase

**Bad key examples avoided:**  
- Short name - Multiple players with the same last name might be playing.
- Jersey number - Multiple players might have the same jersey number.

---

## Performance Considerations

**Expected data scale:**  
Probably maybe less than 10000 would be my max

**Performance bottlenecks identified:**  
None Applicable

**Big-O analysis of core operations:**  

- Add Player: O(1)
- Remove Player: O(1) fastest, O(N) average
- Display: O(N)
- Add to team: O(N) average 
- Remove from team: O(N) average
- Print Team: O(N)
- add to stats: O(1)
- display stats: O(N)

---

## Design Tradeoffs & Decisions

**Key design decisions:**  
I had to create findplayer that used contains and get player that used a foreach. because i didn't know how to return an element in O(1) time.

**Tradeoffs made:**  
None


**What you would do differently with more time:**  
Make it so that stats would update with scoreboard changes.
