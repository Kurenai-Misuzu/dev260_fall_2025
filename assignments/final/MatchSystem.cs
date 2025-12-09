using System;

namespace finalProject
{
    public class MatchSystem
    {
        private HashSet<Player> playerList;
        private List<Player> team1;
        private List<Player> team2;
        private Queue<Player> statsQueue;
        private bool gameStarted = false;
        private int team1Score = 0;
        private int team2Score = 0;
        private bool scoreboardRunning = false;

        public MatchSystem()
        {
            playerList = new HashSet<Player>();
            team1 = new List<Player>();
            team2 = new List<Player>();
            statsQueue = new Queue<Player>();
        }

        // methods used by Program.cs
        public void printInstructions()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("             **INSTRUCTIONS**             ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1. Add any players to the player list");
            Console.WriteLine("2. Add players from the list to a team");
            Console.WriteLine("3. Make sure that each team has 6 Players (no more/no less)");
            Console.WriteLine("4. Start Game");
            Console.WriteLine("5. Enter scoreboard");
            Console.WriteLine("6. Edit the score as the match goes on");
            Console.WriteLine("7. You can do a substitution by exiting the scoreboard");
            Console.WriteLine("   Then removing someone then adding a new team mate");
            Console.WriteLine("8. Match ends when match end is selected or first to 25 win by 2");
            Console.WriteLine("9. You can add players to stats queue");
            Console.WriteLine("10. Click on display stats queue to show the stats of every player");
            Console.WriteLine("11. Load examples loads 21 players into the list");
        }
        public void AddPlayer()
        {

            Player playerToAdd = new Player(
                ReadNonEmptyString("Please input the player's Short (Last) name"),
                ReadNonEmptyString("Please input the player's full name"),
                ReadValidInteger("Please input the player's jersey number"),
                ReadValidInteger("Please input the amount of receives"),
                ReadValidInteger("Please input the number of total points"),
                ReadValidInteger("Please input the number of blocks")
            );

            
            if (findPlayer(playerToAdd.getLongName))
            {
                Console.WriteLine("Error!: Player is already in list");
                return;
            }

            playerList.Add(playerToAdd);
            Console.Clear();
            Console.WriteLine($"{playerToAdd.getShortName} successfully added!");
            playerToAdd.printPlayer();
        }

        public void RemovePlayer()
        {
            if (playerList.Count <= 0)
            {
                Console.WriteLine("Player list is empty!");
                return;
            }

            string input = string.Empty;
            input = ReadNonEmptyString("Please type the full name of the player to remove");

            if (findPlayer(input) == false)
            {
                Console.WriteLine("Player not found!");
                return;
            }

            Player? dummy = getPlayer(input);

            if (dummy != null)
            {
                playerList.Remove(dummy);
                Console.Clear();
                Console.WriteLine($"Player found! Successfully removed {dummy.getShortName}");
            } 
        }

        public void DisplayPlayerList()
        {
            Console.Clear();
            Console.WriteLine("Player List:");
            Console.WriteLine("====================================================");

            if (playerList.Count <= 0)
            {
                Console.WriteLine("Player list is empty!");
                return;
            }

            foreach (Player i in playerList)
            {
                Console.WriteLine($"{i.getJerseyNumber}: {i.getLongName}");
            }
        }

        public void FillTeam1()
        {
            if (team1.Count >= 6)
            {
                Console.WriteLine("Team is full!");
                return;
            }

            string input = ReadNonEmptyString("Please input the player's full Name");

            if (team1.Any(p => StringComparer.OrdinalIgnoreCase.Equals(p.getLongName.Trim(), input.Trim())) || team2.Any(p => StringComparer.OrdinalIgnoreCase.Equals(p.getLongName.Trim(), input.Trim())))
            {
                Console.WriteLine("Error!: Player is already in a team");
                return;
            }

            if (findPlayer(input) == false)
            {
                Console.WriteLine("Error!: Player not found!");
                return;
            }

            // add player
            Player? playerToAdd = getPlayer(input);
            if (playerToAdd == null)
            {
                Console.WriteLine("Error!: Player not found!");
                return;
            }
            team1.Add(playerToAdd);

            Console.Clear();
            Console.WriteLine($"Successfully added {playerToAdd.getShortName} to the list!");

            // print List
            // print team 1
            Console.WriteLine("TEAM 1");
            Console.WriteLine("-------------------------------------");
            if (team1.Count <= 0)
            {
                Console.WriteLine("Empty!");
            }
            else
            {
                foreach (Player i in team1)
                {
                    Console.WriteLine($"{i.getJerseyNumber}: {i.getLongName}");
                }
            }
            Console.WriteLine("-------------------------------------");
        }

        public void FillTeam2()
        {
            if (team2.Count >= 6)
            {
                Console.WriteLine("Team is full!");
                return;
            }

            string input = ReadNonEmptyString("Please input the player's full Name");

            if (team2.Any(p => StringComparer.OrdinalIgnoreCase.Equals(p.getLongName.Trim(), input.Trim())) || team1.Any(p => StringComparer.OrdinalIgnoreCase.Equals(p.getLongName.Trim(), input.Trim())))
            {
                Console.WriteLine("Error!: Player is already in a team");
                return;
            }

            if (findPlayer(input) == false)
            {
                Console.WriteLine("Error!: Player not found!");
                return;
            }

            // add player
            Player? playerToAdd = getPlayer(input);
            if (playerToAdd == null)
            {
                Console.WriteLine("Error!: Player not found!");
                return;
            }
            team2.Add(playerToAdd);

            Console.Clear();
            Console.WriteLine($"Successfully added {playerToAdd.getShortName} to the list!");

            // print List
            // print team 1
            Console.WriteLine("TEAM 2");
            Console.WriteLine("-------------------------------------");
            if (team2.Count <= 0)
            {
                Console.WriteLine("Empty!");
            }
            else
            {
                foreach (Player i in team2)
                {
                    Console.WriteLine($"{i.getJerseyNumber}: {i.getLongName}");
                }
            }
            Console.WriteLine("-------------------------------------");
        }

        public void removeFromTeam1()
        {
            if (team1.Count <= 0)
            {
                Console.WriteLine("Team 1 is already empty!");
                return;
            }

            string input = ReadNonEmptyString("Please input the player's full Name");

            Player? playerToDelete = null;
            foreach(Player i in team1)
            {
                if (input.Equals(i.getLongName, StringComparison.InvariantCultureIgnoreCase))
                {
                    playerToDelete = i;
                }
            }

            // if player not in list
            if (playerToDelete == null)
            {
                Console.WriteLine("Error!: Player not found in Team 1!");
                return;
            }

            // delete
            team1.Remove(playerToDelete);
            
            Console.Clear();
            Console.WriteLine($"Successfully removed {playerToDelete.getShortName} from Team 1");

            // print team 1
            Console.WriteLine("TEAM 1");
            Console.WriteLine("-------------------------------------");
            if (team1.Count <= 0)
            {
                Console.WriteLine("Empty!");
            }
            else
            {
                foreach (Player i in team1)
                {
                    Console.WriteLine($"{i.getJerseyNumber}: {i.getLongName}");
                }
            }
            Console.WriteLine("-------------------------------------");
        }

        public void removeFromTeam2()
        {
            if (team2.Count <= 0)
            {
                Console.WriteLine("Team 2 is already empty!");
                return;
            }

            string input = ReadNonEmptyString("Please input the player's full Name");

            Player? playerToDelete = null;
            foreach(Player i in team2)
            {
                if (input.Equals(i.getLongName, StringComparison.InvariantCultureIgnoreCase))
                {
                    playerToDelete = i;
                }
            }

            // if player not in list
            if (playerToDelete == null)
            {
                Console.WriteLine("Error!: Player not found in Team 2!");
                return;
            }

            // delete
            team2.Remove(playerToDelete);

            Console.Clear();
            Console.WriteLine($"Successfully removed {playerToDelete.getShortName} from Team 2");

            // print team 2
            Console.WriteLine("TEAM 2");
            Console.WriteLine("-------------------------------------");
            if (team2.Count <= 0)
            {
                Console.WriteLine("Empty!");
            }
            else
            {
                foreach (Player i in team2)
                {
                    Console.WriteLine($"{i.getJerseyNumber}: {i.getLongName}");
                }
            }
            Console.WriteLine("-------------------------------------");
        }

        public void printTeams()
        {
            Console.Clear();
            // print team 1
            Console.WriteLine("TEAM 1");
            Console.WriteLine("-------------------------------------");
            if (team1.Count <= 0)
            {
                Console.WriteLine("Empty!");
            }
            else
            {
                foreach (Player i in team1)
                {
                    Console.WriteLine($"{i.getJerseyNumber}: {i.getLongName}");
                }
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            // print team 2
            Console.WriteLine("TEAM 2");
            Console.WriteLine("-------------------------------------");
            if (team2.Count <= 0)
            {
                Console.WriteLine("Empty!");
            }
            else
            {
                foreach (Player i in team2)
                {
                    Console.WriteLine($"{i.getJerseyNumber}: {i.getLongName}");
                }
            }
            Console.WriteLine("-------------------------------------");
        }

        public void resetTeams()
        {
            if (gameStarted == true)
            {
                Console.WriteLine("Cannot clear teams while game is in progress!");
                return;
            }
            
            team1.Clear();
            team2.Clear();

            Console.Clear();
            Console.WriteLine("Reset both teams to empty!");
        }

        public void addToStatsQueue()
        {
            string input = ReadNonEmptyString("Please input the player's full Name");

            if (statsQueue.Any(p => p.getLongName == input))
            {
                Console.WriteLine("Error!: Player is already in the stats queue!");
                return;
            }

            if (findPlayer(input) == false)
            {
                Console.WriteLine("Error!: Player not found!");
                return;
            }

            Player? playerToAdd = getPlayer(input);
            if (playerToAdd == null)
            {
                Console.WriteLine("Error!: Player not found!");
                return;
            }
            statsQueue.Enqueue(playerToAdd);

            Console.Clear();
            Console.WriteLine($"Successfully added {playerToAdd.getShortName} to the stats queue!");

            // print team 1
            Console.WriteLine("STATS QUEUE");
            Console.WriteLine("-------------------------------------");
            if (statsQueue.Count <= 0)
            {
                Console.WriteLine("Empty!");
            }
            else
            {
                foreach (Player i in statsQueue)
                {
                    Console.WriteLine($"{i.getJerseyNumber}: {i.getLongName}");
                }
            }
            Console.WriteLine("-------------------------------------");
        }

        public void displayStats()
        {
            if (statsQueue.Count <= 0)
            {
                Console.WriteLine("Stats queue is empty!");
                return;
            }
            
            Player? currentPlayer = null;
            while (statsQueue.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("PLAYER STATS");

                currentPlayer = statsQueue.Dequeue();
                if (currentPlayer != null)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine($"{currentPlayer.getJerseyNumber}: {currentPlayer.getShortName.ToUpper()}");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine($"Full Name: {currentPlayer.getLongName}");
                    Console.WriteLine($"Receives: {currentPlayer.getReceives}");
                    Console.WriteLine($"Blocks: {currentPlayer.getBlocks}");
                    Console.WriteLine();
                    Console.WriteLine($"Total Points: {currentPlayer.getPoints}");
                    Console.WriteLine("------------------------------------------");
                }

                Console.WriteLine("Press any key to go continue");
                Console.ReadLine();
            }
        }

        public void startGame()
        {
            if (gameStarted == true)
            {
                Console.WriteLine("Error!: Game already in progress!");
                return;
            }

            if (team1.Count != 6 || team2.Count != 6)
            {
                Console.WriteLine("Error!: Both teams need to be full to start a game!");
                return;
            }

            Console.WriteLine("Game started!");
            team1Score = 0;
            team2Score = 0;
            gameStarted = true;
        }

        public void launchScoreboard()
        {
            if (gameStarted != true)
            {
                Console.WriteLine("Error!: No game in progress!");
                return;
            }

            if (team1.Count != 6 || team2.Count != 6)
            {
                Console.WriteLine("Error!: Both teams need to be full to continue the game!");
                return;
            }

            scoreboardRunning = true;

            while (scoreboardRunning == true)
            {
                // print gui
                Console.Clear();
                Console.WriteLine("SCORES");
                Console.WriteLine($"---------------------++---------------------");
                Console.WriteLine($"|{PadBoth(team1Score.ToString("00"), 20)}||{PadBoth(team2Score.ToString("00"), 20)}|");
                Console.WriteLine($"---------------------++---------------------");
                Console.WriteLine();
                Console.WriteLine($"-TEAM 1--------------++-TEAM 2--------------");
                string tempString1 = "";
                string tempString2 = "";
                for (int i = 0; i < 6; i++)
                {
                    tempString1 = team1[i].getJerseyNumber.ToString() + ": " + team1[i].getShortName;
                    tempString2 = team2[i].getJerseyNumber.ToString() + ": " + team2[i].getShortName;
                    Console.WriteLine($"|{PadBoth(tempString1, 20)}||{PadBoth(tempString2, 20)}|");
                }
                Console.WriteLine($"---------------------++---------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("                 **COMMANDS**             ");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Add Point (Team 1)");
                Console.WriteLine("2. Add Point (Team 2)");
                Console.WriteLine("3. Remove Point (Team 1)");
                Console.WriteLine("4. Remove Point (Team 2)");
                Console.WriteLine("5. Exit Scoreboard");
                Console.WriteLine("6. End Game");

                // get commands
                int input = ReadValidInteger("Enter your choice (1-6)");
                switch (input)
                {
                    case 1:
                        team1Score++;
                        break;
                    case 2:
                        team2Score++;
                        break;
                    case 3:
                        team1Score--;
                        break;
                    case 4:
                        team2Score--;
                        break;
                    case 5:
                        scoreboardRunning = false;
                        break;
                    case 6:
                        scoreboardRunning = false;
                        gameStarted = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please choose from 1-6");
                        break;
                }

                // if SCORE EXCEEDS 25 AND WIN BY 2 THEN GAME IS OVER
                int lead = Math.Abs(team1Score - team2Score);
                bool over25 = team1Score >= 25 || team2Score >= 25;
                if (lead >= 2 && over25 == true)
                {
                    gameStarted = false;
                    scoreboardRunning = false;
                }

                // if game ends then print which team had a higher score
                if (gameStarted == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("------------------------------------------");
                    if (team1Score > team2Score)
                    {
                        Console.WriteLine("TEAM 1 WINS!");
                    }
                    else
                    {
                        Console.WriteLine("TEAM 2 WINS!");
                    }
                    Console.WriteLine($"Final Score: {team1Score} - {team2Score}");
                    Console.WriteLine("------------------------------------------");
                }
                
            }
            
        }

        public void fillExample()
        {
            playerList.Add(new Player("Michieletto", "Alessandro Michieletto", 5, 26, 167, 15));
            playerList.Add(new Player("Giannelli", "Simone Giannelli", 6, 43, 49, 16));
            playerList.Add(new Player("Balaso", "Fabio Balaso", 7, 45, 0, 0));
            playerList.Add(new Player("Romanò", "Yuri Romanò", 16, 15, 100, 6));
            playerList.Add(new Player("Galassi", "Gianluca Galassi", 14, 20, 63, 18));
            playerList.Add(new Player("Gargiulo", "Giovannimaria Gargiulo", 25, 17, 102, 27));
            playerList.Add(new Player("Porro L.", "Luca Porro", 31, 27, 89, 13));
            playerList.Add(new Player("Ishikawa", "Yuki Ishikawa", 14, 12, 53, 3));
            playerList.Add(new Player("Takahashi", "Ran Takahashi", 12, 16, 61, 4));
            playerList.Add(new Player("Miyaura", "Kento Miyaura", 4, 27, 201, 5));
            playerList.Add(new Player("Larry", "Larry Ik Evbade-Dan", 23, 7, 41, 9));
            playerList.Add(new Player("Onodera", "Taishi Onodera", 2, 8, 21, 4));
            playerList.Add(new Player("Ogawa", "Tomohiro Ogawa", 13, 72, 0, 0));
            playerList.Add(new Player("Sekita", "Masahiro Sekita", 8, 25, 9, 2));
            playerList.Add(new Player("Leon", "Wilfredo Leon", 9, 6, 87, 5));
            playerList.Add(new Player("Kochanowski", "Jakub Kochanowski", 15, 5, 55, 14));
            playerList.Add(new Player("Nowak J.", "Jakub Nowak", 73, 6, 82, 25));
            playerList.Add(new Player("Semeniuk", "Kamil Semeniuk", 16, 24, 106, 4));
            playerList.Add(new Player("Sasak", "Kewin Sasak", 35, 30, 172, 16));
            playerList.Add(new Player("Granieczny", "Maksymilian Granieczny", 18, 23, 0, 0));
            playerList.Add(new Player("Komenda", "Marcin Komenda", 4, 37, 16, 12));
            Console.WriteLine("Players Loaded Successfully");

        }

        // getter functs
        public (int playerListCount, int team1Count, int team2Count, int statsQueueCount) getCounts()
        {
            return (playerList.Count, team1.Count, team2.Count, statsQueue.Count);
        }

        public bool getGameState
        {
            get
            {
                return gameStarted;
            }
        }

        // helper functions

        // theres a warning here but string shouldn't be null because of check in method
        static string ReadNonEmptyString(string prompt)
        {
            string? input = string.Empty;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write($"Enter {prompt}: ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: This field cannot be empty. Please try again.");
                }
                else
                {
                    isValid = true;
                }
            }
            return input.Trim();
        }

        static int ReadValidInteger(string prompt)
        {
            int number = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write($"Enter {prompt}: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: This field cannot be empty. Please try again.");
                    continue; // Go back to the start of the loop
                }

                // Use int.TryParse to check if the input is a valid integer
                if (int.TryParse(input, out number))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Error: Invalid input. Please enter a whole number.");
                }
            }
            return number;
        }

        bool findPlayer(string fullName)
        {
            Player dummy = new Player("", fullName);
            if (playerList.Contains(dummy))
            {
                return true;
            }
            return false;
        }

        Player? getPlayer(string fullName)
        {
            foreach(Player i in playerList)
            {
                if (fullName.Trim().Equals(i.getLongName.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return null;
        }

        static string PadBoth(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces/2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);
        }

    }
}