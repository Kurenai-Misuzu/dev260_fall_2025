using System;

namespace Week3ArraysSorting
{
    /// <summary>
    /// Board Game implementation for Assignment 2 Part A
    /// Demonstrates multi-dimensional arrays with interactive gameplay
    /// 
    /// Learning Focus: 
    /// - Multi-dimensional array manipulation (char[,])
    /// - Console rendering and user input
    /// - Game state management and win detection
    /// 
    /// Choose ONE game to implement:
    /// - Tic-Tac-Toe (3x3 grid)
    /// - Connect Four (6x7 grid with gravity)
    /// - Or something else creative using a 2D array! (I need to be able to understand the rules from your instructions)
    /// </summary>
    public class BoardGame
    {
        // TODO: Choose your game and declare the appropriate board
        // Option 1: Tic-Tac-Toe
        private char[,] board = new char[3, 3];

        // Option 2: Connect Four  
        // private char[,] board = new char[6, 7]; // 6 rows, 7 columns
        
        // Option 3: Your own game
        // private char[,] board = new char[ROWS, COLUMNS]; // Define your own size
        
        // TODO: Add fields for game state
        private char currentPlayer = 'X';
        private bool gameOver = false;
        private string winner = "";

        /// <summary>
        /// Constructor - Initialize the board game
        /// TODO: Set up your chosen game
        /// </summary>
        public BoardGame()
        {
            // TODO: Initialize your board array
            // For Tic-Tac-Toe or Connect Four, fill with empty spaces or dots
            // ❌ ⭕ -> use for Tic-Tac-Toe if you'd like for each square/player and the white box from array example

            /// Console.WriteLine("BoardGame constructor - TODO: Initialize your chosen game");
            
            /// initialize the board game
            char[,] board = new char[3,3];

            /// put empty characters in the board game
            for (int i = 0; i < 3; i++){
                for (int j = 0; j < 3; j++){
                    board[i, j] = '.';
                }
            }
        }
        
        /// <summary>
        /// Main game loop - handles the complete game session
        /// TODO: Implement the full game experience
        /// </summary>
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("=== BOARD GAME (Part A) ===");
            Console.WriteLine();
            
            // TODO: Display game instructions
            DisplayInstructions();
            
            // TODO: Implement main game loop
            bool playAgain = true;
            
            while (playAgain)
            {
                // TODO: Reset game state for new game
                InitializeNewGame();
                
                // TODO: Play one complete game
                PlayOneGame();
                
                // TODO: Ask if player wants to play again
                playAgain = AskPlayAgain();
            }
            
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Display game instructions and controls
        /// TODO: Customize for your chosen game
        /// </summary>
        private void DisplayInstructions()
        {
            // Console.WriteLine("TODO: Add instructions for your chosen game");
            Console.WriteLine();
            
            // Example for Tic-Tac-Toe:
            // Console.WriteLine("TIC-TAC-TOE RULES:");
            // Console.WriteLine("- Players take turns placing X and O");
            // Console.WriteLine("- Enter row and column (0-2) when prompted");
            // Console.WriteLine("- First to get 3 in a row wins!");

            /// instructions for tic-tac-toe
            Console.WriteLine("----------------TIC-TAC-TOE----------------");
            Console.WriteLine("- One player is X while the other is O");
            Console.WriteLine("- Players take turns placing down their");
            Console.WriteLine("symbol.");
            Console.WriteLine("Input your space by typing Row and then");
            Console.WriteLine("the column. (A1, B2, C3)");
            Console.WriteLine("- A player win when they get three in");
            Console.WriteLine("a row. (vertical, horizontal, diagonal)");
            
            // Example for Connect Four:
            // Console.WriteLine("CONNECT FOUR RULES:");
            // Console.WriteLine("- Players take turns dropping tokens");
            // Console.WriteLine("- Enter column number (0-6) when prompted");
            // Console.WriteLine("- First to get 4 in a row wins!");
            
            Console.WriteLine();
        }
        
        /// <summary>
        /// Initialize/reset the game for a new round
        /// TODO: Reset board and game state
        /// </summary>
        private void InitializeNewGame()
        {
            // TODO: Clear the board array
            // TODO: Reset current player to 'X'
            // TODO: Reset game over flag
            // TODO: Clear winner
            
            //Console.WriteLine("TODO: Initialize new game state");

            /// clear the board
            for (int i = 0; i < 3; i++){
                for (int j = 0; j < 3; j++){
                    board[i,j] = '.';
                }
            }

            /// switch the current player to X
            currentPlayer = 'X';

            /// reset game over flag
            gameOver = false;

            /// clear winner
            winner = "";
        }
        
        /// <summary>
        /// Play one complete game until win/draw/quit
        /// TODO: Implement the core game loop
        /// </summary>
        private void PlayOneGame()
        {
            // TODO: Game loop structure:
            while (!gameOver)
            {
                RenderBoard();
                GetPlayerMove();
                //UpdateBoard();
                CheckWinCondition();
                SwitchPlayer();
            }
            Console.WriteLine("Winner: " + winner);

            // Console.WriteLine("TODO: Implement main game loop");
            // Console.WriteLine("This should include:");
            // Console.WriteLine("1. Render board to console");
            // Console.WriteLine("2. Get and validate player input");
            // Console.WriteLine("3. Update board with move");
            // Console.WriteLine("4. Check for win/draw conditions");
            // Console.WriteLine("5. Switch to next player");
        }
        
        /// <summary>
        /// Render the current board state to console
        /// TODO: Create clear, readable board display
        /// </summary>
        private void RenderBoard()
        {
            // TODO: Display your multi-dimensional array as a visual board
            // Requirements:
            // - Clear, human-readable format
            // - Show current board state
            // - Include row/column labels for easy reference
            Console.WriteLine("   A   B   C");
            for (int i = 0; i < 3; i++){
                Console.Write((i + 1) + " ");
                for (int j = 0; j < 3; j++){
                    Console.Write("[" + board[i, j] + "] ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            //Console.WriteLine("TODO: Render board array to console");
        }
        
        /// <summary>
        /// Get and validate player move input
        /// TODO: Handle user input with validation
        /// </summary>
        private void GetPlayerMove()
        {
            // TODO: Prompt current player for their move
            // TODO: Validate input (in bounds, empty cell, etc.)
            // TODO: Keep asking until valid move is entered
            
            //Console.WriteLine("TODO: Get and validate player move");
            
            // Example input validation structure:
            // bool validMove = false;
            // while (!validMove)
            // {
            //     Console.Write($"Player {currentPlayer}, enter your move: ");
            //     string input = Console.ReadLine();
            //     
            //     // Parse and validate input
            //     // Set validMove = true when valid move found
            // }
            int rowInt = 0;
            int colInt = 0;

            bool validMove = false;
            while (!validMove){

                Console.WriteLine($"Player {currentPlayer}, enter your move row + column. (Ex. A3, B1, C2): ");
                string? input = Console.ReadLine();
                if (input == null || input == "")
                {
                    Console.WriteLine("Please input a move!");
                    continue;
                }
                char rowChar = input[0];
                char colChar = input[1];


                // convert char to number
                rowInt = 0;
                rowChar = Char.ToUpper(rowChar);
                if (rowChar == 'A' || rowChar == 'B' || rowChar == 'C'){
                    switch(rowChar){
                        case 'B':
                            rowInt = 1;
                            break;
                        case 'C':
                            rowInt = 2;
                            break;
                        default:
                            break;
                    }
                } else {
                    Console.WriteLine("Not a valid row! Please try again.");
                    continue;
                }
                // row is validated
                colInt = colChar - 49;
                if (!(colInt == 0 || colInt == 1 || colInt == 2)){
                    Console.WriteLine("Not a valid column! Please try again.");
                    continue;
                }
                // column is validated
                if (board[colInt, rowInt] == '.'){
                    validMove = true;
                } else {
                    Console.WriteLine("Space is occupied! Please try again.");
                }
            }

            // update the board
            board[colInt, rowInt] = currentPlayer;

        }
        
        /// <summary>
        /// Check if current board state has a winner or draw
        /// TODO: Implement win detection logic
        /// </summary>
        private void CheckWinCondition()
        {
            // TODO: Check for win conditions specific to your game
            
            // For Tic-Tac-Toe:
            // - Check all rows, columns, and diagonals for 3 in a row
            // - Check for draw (board full, no winner)
            
            // For Connect Four:
            // - Check horizontal, vertical, and diagonal lines for 4 in a row
            // - Check for draw (top row full, no winner)

            // check row
            for (int i = 0; i < 3; i++){
                if ((board[i,0] == board[i,1] && board[i,1] == board[i,2]) && (board[i,0] != '.')){
                    winner = board[i, 0].ToString();
                    gameOver = true;
                }
            }
            // check column
            for (int i = 0; i < 3; i++){
                if ((board[0,i] == board[1,i] && board[1,i] == board[2,i]) && (board[0,i] != '.')){
                    winner = board[0, i].ToString();
                    gameOver = true;
                }
            }
            // check diagonal
            if ((board[0,0] == board[1,1] && board[1,1] == board[2,2]) && (board[0,0] != '.')){
                winner = board[0, 0].ToString();
                gameOver = true;
            }
            if ((board[0,2] == board[1,1] && board[1,1] == board[2,0]) && (board[0,2] != '.')){
                winner = board[0, 2].ToString();
                gameOver = true;
            }

            // check draw
            int empty = 0;
            for (int i = 0; i < 3; i++){
                for (int j = 0; j < 3; j++){
                    if (board[i, j] == '.'){
                        empty++;
                    }
                }
            }
            if (empty == 0){
                gameOver = true;
                winner = "Draw";
            }
            
            //Console.WriteLine("TODO: Implement win/draw detection");
        }
        
        /// <summary>
        /// Ask player if they want to play another game
        /// TODO: Simple yes/no prompt with validation
        /// </summary>
        private bool AskPlayAgain()
        {
            // TODO: Ask user if they want to play again
            // TODO: Validate input (y/n, yes/no, etc.)
            // TODO: Return true for play again, false to return to main menu
            
            // Console.WriteLine("TODO: Ask if player wants to play again");
            bool validInput = false;
            while (!validInput){
                Console.WriteLine("Play again? y/n");
                string? input = Console.ReadLine();
                if (input == null || input == "" || input.Length > 1){
                    Console.WriteLine("Please input a valid response.");
                    continue;
                } else if (Char.ToUpper(input[0]) == 'Y'){
                    return true;
                } else if (Char.ToUpper(input[0]) == 'N'){
                    return false;
                } else {
                    Console.WriteLine("Please input a valid response.");
                    continue;
                }
            }
            

            
            // Placeholder - always return false for now
            return false;
        }
        
        /// <summary>
        /// Switch to the next player's turn
        /// TODO: Toggle between X and O
        /// </summary>
        private void SwitchPlayer()
        {
            // TODO: Switch currentPlayer between 'X' and 'O'            
            //Console.WriteLine("TODO: Switch to next player");
            if (currentPlayer == 'X'){
                currentPlayer = 'O';
            } else {
                currentPlayer = 'X';
            }
        }
        
        // TODO: Add helper methods as needed
        // Examples:
        // - IsValidMove(int row, int col)
        // - IsBoardFull()
        // - CheckRow(int row, char player)
        // - CheckColumn(int col, char player)
        // - CheckDiagonals(char player)
        // - DropToken(int column, char player) // For Connect Four
    }
}