# Volleyball Scoreboard Editor for Broadcast

> A program to keep track of players, scores, and stats for broadcast purposes.

---

## What I Built (Overview)

**Problem this solves:**  
Programs akin to this are used in broadcast all the time. The technical director cannot handle data by themselves with only the broadcast program. There needs to be external tools that help with certain scenes and data.

**Core features:**  
- Add many players
- Remove players
- Add players to teams
- Remove / substitute players from teams
- Supports a full team of 6 on the court
- Supports players full name  and short name
- Supports substitutions mid game
- Dynamically sized queue for stats
- Cute GUI
- Provides a list of example players

## How to Run

**Requirements:**  
dotnet 9.0.305
Windows 10/11

**Build:**

```bash
git clone <your-repo-url>
cd <your-folder>
dotnet build
```

**Run:**  
```bash
dotnet run
```

**Sample data (if applicable):**  

In the main menu type 14.
Sample Data is hard coded.

## Using the App (Quick Start)

**Typical workflow:**  

1. Add Players to player list
2. Add players to teams
3. Start Game
4. Edit Game Scoreboard

**Input tips:**  
Required fields should force user to input something.

## Data Structures (Brief Summary)

> Full rationale goes in **DESIGN.md**. Here, list only what you used and the feature it powers.

**Data structures used:**  

- `Hashset<Player>` → Player list (contains function)
- `List<Player>` → Team list (for easy add and remove and index)
- `Queue<Player>` → For displaying stats queue (Enqueue and Dequeue)

---

## Manual Testing Summary

> No unit tests required. Show how you verified correctness with 3–5 test scenarios.

**Test scenarios:**  

**Scenario 1: [Name]**

- Steps: 
  - Add wilfredo leon to team 1
  - Add wilfredo leon to team 2
- Expected result: error saying that leon is already in team 1
- Actual result: added leon to both teams
- **FIXED**

**Scenario 2: [Name]**

- Steps:
  - add Player to team 1
  - select display teams
- Expected result: Jersey number shows next to short name
- Actual result: Jersey number was always set to 0
- **FIXED**

**Scenario 3: [Name]**

- Steps: 
  - start game
  - load into scoreboard
  - set team1 to 25 points
- Expected result: team1 wins and scoreboard exits
- Actual result: game kept going on
- **FIXED**

---

## Known Limitations

**Limitations and edge cases:**  
_Describe any edge cases not handled, performance caveats, or known issues._

- Scoring in the game scoreboard does not updatae player stats

## Comparers & String Handling

**Keys comparer:**  
_Describe what string comparer you used (e.g., StringComparer.OrdinalIgnoreCase) and why._

**Your Answer:**

**Normalization:**  
I used ordinalignorecase to make sure that it is case insensitive.
i also used trim to make sure that strings are trimmed.

## Credits & AI Disclosure

**Resources:**  
none applicable

- **AI usage (if any):**  
  Asked Gemini for help creating the main menu switch case and main menu loop.
  Asked gemini for help overloading the equals function of Player.

## Challenges and Solutions

**Biggest challenge faced:**  
the most difficult part of this project was deciding how i should organize the project files into each own file. 

**How you solved it:**  
I took a lot of inspiration from the previous assignments structure. Program was the main entry point of the program while there was a system class of sort where many things happened.

**Most confusing concept:**  
overloading the Player class's equals so that it could be used for Hashset.Contains. 

## Code Quality

**What you're most proud of in your implementation:**  
I'm most proud of the scoreboard. I think it looks quite nice. I'm proud of how it looks and functions. the scoreboard could be similar to a scene that would be used in a broadcast.

**What you would improve if you had more time:**  
I'd have to rewrite the whole game logic but if I had lots more time I would create it so that the game updates the stats of the user in the hashset. for example if player 1 scores, then their total pionts goes up.

## Real-World Applications

**How this relates to real-world systems:**  
This type of program that holds a small data structure of the players in the event and the players on the scoreboard is akin to the programs that are used in the broadcast world. 

**What you learned about data structures and algorithms:**  
I gained the insight that choosing your data structure is actually such an insanely big deal becuse if you decide to use the wrong one early on then implmenetation and program speed could be so different from the early vision of the program.

## Submission Checklist

- [x] Public GitHub repository link submitted
- [x] README.md completed (this file)
- [x] DESIGN.md completed
- [x] Source code included and builds successfully
- [ ] (Optional) Slide deck or 5–10 minute demo video link (unlisted)
