using System;

namespace finalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            MatchSystem matchSystem = new MatchSystem();
            while (isRunning)
            {
                DisplayMenu();

                var counts = matchSystem.getCounts();
                Console.WriteLine($"Players in player list: {counts.playerListCount}");
                Console.WriteLine($"Playes in team 1: {counts.team1Count} / 6");
                Console.WriteLine($"Playes in team 2: {counts.team2Count} / 6");
                Console.WriteLine($"Playes in stats queue: {counts.statsQueueCount}");
                Console.WriteLine($"Game in progress: {matchSystem.getGameState}");

                Console.WriteLine("------------------------------------------");
                Console.Write("Enter your choice (1-11): ");

                // Read user input
                string? input = Console.ReadLine();

                // Attempt to parse the input as an integer
                if (int.TryParse(input, out int choice))
                {
                    // Process the user's choice
                    switch (choice)
                    {
                        case 0:
                            matchSystem.printInstructions();
                            break;
                        case 1:
                            matchSystem.AddPlayer();
                            break;
                        case 2:
                            matchSystem.RemovePlayer();
                            break;
                        case 3:
                            matchSystem.DisplayPlayerList();
                            break;
                        case 4:
                            matchSystem.FillTeam1();
                            break;
                        case 5:
                            matchSystem.FillTeam2();
                            break;
                        case 6:
                            matchSystem.removeFromTeam1();
                            break;
                        case 7:
                            matchSystem.removeFromTeam2();
                            break;
                        case 8:
                            matchSystem.printTeams();
                            break;
                        case 9:
                            matchSystem.resetTeams();
                            break;
                        case 10:
                            matchSystem.addToStatsQueue();
                            break;
                        case 11:
                            matchSystem.displayStats();
                            break;
                        case 12:
                            matchSystem.startGame();
                            break;
                        case 13:
                            matchSystem.launchScoreboard();
                            break;
                        case 14:
                            matchSystem.fillExample();
                            break;
                        case 15:
                            //ExitApplication(ref isRunning);
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("\n Invalid option. Please enter a number between 1 and 9.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n Invalid input. Please enter a numerical option.");
                }

                // Pause before showing the menu again, unless exiting
                if (isRunning)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" **Tournament Management System Menu** ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("0. Display instructions");
            Console.WriteLine("1. Add player to player list");
            Console.WriteLine("2. Remove player from list");
            Console.WriteLine("3. View player list");
            Console.WriteLine("4. Fill team 1");
            Console.WriteLine("5. Fill team 2");
            Console.WriteLine("6. Remove from team 1");
            Console.WriteLine("7. Remove from team 2");
            Console.WriteLine("8. Display Teams");
            Console.WriteLine("9. Reset Teams");
            Console.WriteLine("10. Add to stats queue");
            Console.WriteLine("11. Display player stats");
            Console.WriteLine("12. Start Game");
            Console.WriteLine("13. Game Scoreboard");
            Console.WriteLine("14. Fill player list with examples");
            Console.WriteLine("15. Exit");
            Console.WriteLine("------------------------------------------");
        }
    }
}