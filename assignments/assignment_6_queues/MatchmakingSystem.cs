using System.Collections;
using System.Drawing;
using System.Security;
using System.Text.RegularExpressions;

namespace Assignment6
{
    /// <summary>
    /// Main matchmaking system managing queues and matches
    /// Students implement the core methods in this class
    /// </summary>
    public class MatchmakingSystem
    {
        // Data structures for managing the matchmaking system
        private Queue<Player> casualQueue = new Queue<Player>();
        private Queue<Player> rankedQueue = new Queue<Player>();
        private Queue<Player> quickPlayQueue = new Queue<Player>();
        private List<Player> allPlayers = new List<Player>();
        private List<Match> matchHistory = new List<Match>();

        // Statistics tracking
        private int totalMatches = 0;
        private DateTime systemStartTime = DateTime.Now;

        /// <summary>
        /// Create a new player and add to the system
        /// </summary>
        public Player CreatePlayer(string username, int skillRating, GameMode preferredMode = GameMode.Casual)
        {
            // Check for duplicate usernames
            if (allPlayers.Any(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Player with username '{username}' already exists");
            }

            var player = new Player(username, skillRating, preferredMode);
            allPlayers.Add(player);
            return player;
        }

        /// <summary>
        /// Get all players in the system
        /// </summary>
        public List<Player> GetAllPlayers() => allPlayers.ToList();

        /// <summary>
        /// Get match history
        /// </summary>
        public List<Match> GetMatchHistory() => matchHistory.ToList();

        /// <summary>
        /// Get system statistics
        /// </summary>
        public string GetSystemStats()
        {
            var uptime = DateTime.Now - systemStartTime;
            var avgMatchQuality = matchHistory.Count > 0 
                ? matchHistory.Average(m => m.SkillDifference) 
                : 0;

            return $"""
                🎮 Matchmaking System Statistics
                ================================
                Total Players: {allPlayers.Count}
                Total Matches: {totalMatches}
                System Uptime: {uptime.ToString("hh\\:mm\\:ss")}
                
                Queue Status:
                - Casual: {casualQueue.Count} players
                - Ranked: {rankedQueue.Count} players  
                - QuickPlay: {quickPlayQueue.Count} players
                
                Match Quality:
                - Average Skill Difference: {avgMatchQuality:F1}
                - Recent Matches: {Math.Min(5, matchHistory.Count)}
                """;
        }

        // ============================================
        // STUDENT IMPLEMENTATION METHODS (TO DO)
        // ============================================

        /// <summary>
        /// TODO: Add a player to the appropriate queue based on game mode
        /// 
        /// Requirements:
        /// - Add player to correct queue (casualQueue, rankedQueue, or quickPlayQueue)
        /// - Call player.JoinQueue() to track queue time
        /// - Handle any validation needed
        /// </summary>
        public void AddToQueue(Player player, GameMode mode)
        {
            
            // player in queue already
            if (!player.GetQueueTime().Equals("Not in queue"))
            {
                // throw error
                throw new Exception("Player already in Queue!");
            }

            // enqueue player into the right mode
            switch (mode)
            {
                case GameMode.Casual:
                    casualQueue.Enqueue(player);
                    break;
                case GameMode.Ranked:
                    rankedQueue.Enqueue(player);
                    break;
                default: // quickplay 
                    quickPlayQueue.Enqueue(player);
                    break;
            }

            // joinqueue
            player.JoinQueue();
        }

        /// <summary>
        /// TODO: Try to create a match from the specified queue
        /// 
        /// Requirements:
        /// - Return null if not enough players (need at least 2)
        /// - For Casual: Any two players can match (simple FIFO)
        /// - For Ranked: Only players within ±2 skill levels can match
        /// - For QuickPlay: Prefer skill matching, but allow any match if queue > 4 players
        /// - Remove matched players from queue and call LeaveQueue() on them
        /// - Return new Match object if successful
        /// </summary>
        public Match? TryCreateMatch(GameMode mode)
        {
            // if the mode has less than 2 players in queue return null immediately
            if (GetQueueByMode(mode).Count < 2)
            {
                return null;
            }

            // some variables used for convenicne
            Player? p1 = null;
            Player? p2 = null;

            // switch case for mode
            switch (mode)
            {
                // casual
                case GameMode.Casual:
                    p1 = casualQueue.Dequeue();
                    p2 = casualQueue.Dequeue();
                    p1.LeaveQueue();
                    p2.LeaveQueue();
                    return new Match(p1, p2, mode);

                // ranked
                case GameMode.Ranked:
                    // skill based matchmaking

                    // templist to make looking up easier
                    List<Player> tempList = rankedQueue.ToList();

                    // nested foreach lol
                    // goes thru the first list as p1 then compares it to the rank of p2 in the queue
                    foreach (Player i in tempList)
                    {
                        foreach (Player j in rankedQueue)
                        {
                            // this will run if the usernames are not equal (self match) and canmatchinranked is true
                            if (!j.Username.Equals(i.Username) && CanMatchInRanked(i, j))
                            {
                                RemoveFromAllQueues(i);
                                RemoveFromAllQueues(j);
                                return new Match(i, j, mode);
                            }
                        }
                    }
                    break;
                
                // quickplay
                default:
                    // prefer sbmm if less than 4 players
                    if (quickPlayQueue.Count < 4)
                    {
                        // same code as ranked sbmm 
                        List<Player> tempList2 = quickPlayQueue.ToList();

                        foreach (Player i in tempList2)
                        {
                            foreach (Player j in quickPlayQueue)
                            {
                                if (!j.Username.Equals(i.Username) && CanMatchInRanked(i, j))
                                {
                                    RemoveFromAllQueues(i);
                                    RemoveFromAllQueues(j);
                                    return new Match(i, j, mode);
                                }
                            }
                        }
                    }
                    // raw matching more than 4 players
                    else
                    {
                        p1 = quickPlayQueue.Dequeue();
                        p2 = quickPlayQueue.Dequeue();
                        p1.LeaveQueue();
                        p2.LeaveQueue();
                        return new Match(p1, p2, mode);
                    }

                    break;
            }

            return null;
        }

        /// <summary>
        /// TODO: Process a match by simulating outcome and updating statistics
        /// 
        /// Requirements:
        /// - Call match.SimulateOutcome() to determine winner
        /// - Add match to matchHistory
        /// - Increment totalMatches counter
        /// - Display match results to console
        /// </summary>
        public void ProcessMatch(Match match)
        {
            // simulate outcome
            match.SimulateOutcome();
            // add to matchhistory
            matchHistory.Add(match);
            // increment matches
            totalMatches++;
            // print the matches played
            Console.WriteLine($"{match.ToDetailedString()}");
            
        }

        /// <summary>
        /// TODO: Display current status of all queues with formatting
        /// 
        /// Requirements:
        /// - Show header "Current Queue Status"
        /// - For each queue (Casual, Ranked, QuickPlay):
        ///   - Show queue name and player count
        ///   - List players with position numbers and queue times
        ///   - Handle empty queues gracefully
        /// - Use proper formatting and emojis for readability
        /// </summary>
        public void DisplayQueueStatus()
        {
            // header
            Console.WriteLine("============================================================");
            Console.WriteLine("Current Queue Status");
            Console.WriteLine("============================================================");

            // used to check if queue is empty and also for index printing
            int queueCount = 0;

            // casual queue
            queueCount = casualQueue.Count;

            // guard clause
            if (queueCount < 1)
            {
                Console.WriteLine("Casual Queue is Empty!");
            }
            else
            {
                // set as index
                queueCount = 0;
                Console.WriteLine("Casual Queue:");
                foreach (Player i in casualQueue)
                {
                    // increment index
                    queueCount++;
                    // print the player in the queue
                    Console.WriteLine($"{queueCount}. {i.ToString()}");
                }
            }
            
            // comments are same for ranked and quickplay i will not be copying comments
            Console.WriteLine("------------------------------------------------------------");
            // rankd queue
            queueCount = rankedQueue.Count;
            if (queueCount < 1)
            {
                Console.WriteLine("Ranked Queue is Empty!");
            }
            else
            {
                queueCount = 0;
                Console.WriteLine("Ranked Queue:");
                foreach (Player i in rankedQueue)
                {
                    queueCount++;
                    Console.WriteLine($"{queueCount}. {i.ToString()}");
                }
            }
            Console.WriteLine("------------------------------------------------------------");
            // quickplay queue
            queueCount = quickPlayQueue.Count;
            if (queueCount < 1)
            {
                Console.WriteLine("Quick Play Queue is Empty!");
            }
            else
            {
                queueCount = 0;
                Console.WriteLine("Quick Play Queue:");
                foreach (Player i in quickPlayQueue)
                {
                    queueCount++;
                    Console.WriteLine($"{queueCount}. {i.ToString()}");
                }
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        /// <summary>
        /// TODO: Display detailed statistics for a specific player
        /// 
        /// Requirements:
        /// - Use player.ToDetailedString() for basic info
        /// - Add queue status (in queue, estimated wait time)
        /// - Show recent match history for this player (last 3 matches)
        /// - Handle case where player has no matches
        /// </summary>
        public void DisplayPlayerStats(Player player)
        {
            // print player info
            Console.WriteLine($"{player.ToDetailedString()}");
            // print if player in queue
            Console.WriteLine($"In Queue: {player.GetQueueTime()}");
            
            // match history
            Console.WriteLine("Recent Matches:");
            // total matches printed (max: 3)
            int matchesPrinted = 0;
            // make templist that is reversed match history 
            List<Match> reversedHistory = matchHistory.AsEnumerable().Reverse().ToList();
            // go thru reversed list
            foreach (Match i in reversedHistory)
            {
                // will only run if less than 3 matches have already been printed and the player has been found in the matches
                if (matchesPrinted < 3 && (player.Username.Equals(i.Player1.Username) || player.Username.Equals(i.Player2.Username)))
                {
                    Console.WriteLine($"{i.GetSummary()}");
                    matchesPrinted++;
                }
            }
        }

        /// <summary>
        /// TODO: Calculate estimated wait time for a queue
        /// 
        /// Requirements:
        /// - Return "No wait" if queue has 2+ players
        /// - Return "Short wait" if queue has 1 player
        /// - Return "Long wait" if queue is empty
        /// - For Ranked: Consider skill distribution (harder to match = longer wait)
        /// </summary>
        public string GetQueueEstimate(GameMode mode)
        {
            // get queue count of the chosen queue
            int queueCount = 0;
            Queue<Player> chosenQueue = GetQueueByMode(mode);
            queueCount = chosenQueue.Count;

            // if queue has more than 2 players
            if (queueCount >= 2)
            {
                return "No Wait";
            }
            // if has 1 player
            else if (queueCount == 1)
            {
                return "Short Wait";
            }
            // if no players
            return "Long Wait";
        }

        // ============================================
        // HELPER METHODS (PROVIDED)
        // ============================================

        /// <summary>
        /// Helper: Check if two players can match in Ranked mode (±2 skill levels)
        /// </summary>
        private bool CanMatchInRanked(Player player1, Player player2)
        {
            return Math.Abs(player1.SkillRating - player2.SkillRating) <= 2;
        }

        /// <summary>
        /// Helper: Remove player from all queues (useful for cleanup)
        /// </summary>
        private void RemoveFromAllQueues(Player player)
        {
            // Create temporary lists to avoid modifying collections during iteration
            var casualPlayers = casualQueue.ToList();
            var rankedPlayers = rankedQueue.ToList();
            var quickPlayPlayers = quickPlayQueue.ToList();

            // Clear and rebuild queues without the specified player
            casualQueue.Clear();
            foreach (var p in casualPlayers.Where(p => p != player))
                casualQueue.Enqueue(p);

            rankedQueue.Clear();
            foreach (var p in rankedPlayers.Where(p => p != player))
                rankedQueue.Enqueue(p);

            quickPlayQueue.Clear();
            foreach (var p in quickPlayPlayers.Where(p => p != player))
                quickPlayQueue.Enqueue(p);

            player.LeaveQueue();
        }

        /// <summary>
        /// Helper: Get queue by mode (useful for generic operations)
        /// </summary>
        private Queue<Player> GetQueueByMode(GameMode mode)
        {
            return mode switch
            {
                GameMode.Casual => casualQueue,
                GameMode.Ranked => rankedQueue,
                GameMode.QuickPlay => quickPlayQueue,
                _ => throw new ArgumentException($"Unknown game mode: {mode}")
            };
        }
    }
}