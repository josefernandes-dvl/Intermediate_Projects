using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool play = true;

            while (play) // Main cycle of the program, where the game is run.
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tic Tac Toe Game! (by José Fernandes)");
                Console.WriteLine("---------------------------------------------------");
                Console.Write("Enter the username of the player one: ");
                string p1 = Console.ReadLine();
                Console.Write("\nEnter the username of the player two: ");
                string p2 = Console.ReadLine();
                Console.WriteLine("");

                string[,] tictactoe = new string[4, 4] // Creation of the game space.
                {
                    { "", "1", "2", "3" },
                    { "A", "0", "0", "0" },
                    { "B", "0", "0", "0" },
                    { "C", "0", "0", "0" }
                };

                GameExib(tictactoe); // Function that run the game exhibition.
                bool cont = true;

                while (cont) // System of plays and switching between players.
                {
                    cont = PlayerMove(p1, "1", tictactoe);
                    if (!cont) break; // If someone wins or the game is a draw, the cycle ends.

                    cont = PlayerMove(p2, "2", tictactoe);
                }

                Console.WriteLine("\nWould you like to:");
                Console.WriteLine("a) Reset the game");
                Console.WriteLine("b) Quit the game");
                string choice = Console.ReadLine().ToLower();

                if (choice != "a")
                {
                    play = false; //Close the program.
                }
            }
        }

        static void GameExib(string[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++) // For Lines
            {
                for (int j = 0; j < a.GetLength(1); j++) // For Columns
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        static bool PlayerMove(string playerName, string playerSymbol, string[,] board)
        {
            while (true)
            {
                Console.Write(playerName + " , which position would you like to mark? (letter-number) R: ");
                string response = Console.ReadLine().ToLower();

                if (IsValidMove(response, board)) //Check if the answer is valid.
                {
                    MarkPosition(response, playerSymbol, board); // Mark where the player wants.
                    Console.Clear();
                    GameExib(board);

                    if (CheckWin(board, playerSymbol)) //Check if some player wins.
                    {
                        Console.WriteLine("\nCongratulations, " + playerName + ", YOU WIN!");
                        return false;
                    }

                    if (IsDraw(board)) //Check if the game ended in a draw.
                    {
                        Console.WriteLine("\nThe game ended in a draw!");
                        return false;
                    }

                    break; //Stop the cycle and pass to the other player.
                }
                else
                {
                    Console.WriteLine("Invalid move or position already marked. Please try again."); 
                }
            }
            return true; // Repeat the cycle if the command is invalid.
        }

        static bool IsValidMove(string move, string[,] board) // Check the matrix cells.
        {
            int row = 0, col = 0; // The game coordinates.

            switch (move)
            {
                case "a-1": row = 1; col = 1; break;
                case "a-2": row = 1; col = 2; break;
                case "a-3": row = 1; col = 3; break;
                case "b-1": row = 2; col = 1; break;
                case "b-2": row = 2; col = 2; break;
                case "b-3": row = 2; col = 3; break;
                case "c-1": row = 3; col = 1; break;
                case "c-2": row = 3; col = 2; break;
                case "c-3": row = 3; col = 3; break;
                default: return false; // Invalid input
            }

            return board[row, col] == "0"; // Return true if the cell is not marked
        }

        static void MarkPosition(string move, string playerSymbol, string[,] board) //Defines the game alternatives.
        {
            int row = 0, col = 0; // The game coordinates.

            switch (move)
            {
                case "a-1": row = 1; col = 1; break;
                case "a-2": row = 1; col = 2; break;
                case "a-3": row = 1; col = 3; break;
                case "b-1": row = 2; col = 1; break;
                case "b-2": row = 2; col = 2; break;
                case "b-3": row = 2; col = 3; break;
                case "c-1": row = 3; col = 1; break;
                case "c-2": row = 3; col = 2; break;
                case "c-3": row = 3; col = 3; break;
            }

            board[row, col] = playerSymbol;
        }

        static bool IsDraw(string[,] board) // Check if have a draw.
        {
            foreach (string cell in board)
            {
                if (cell == "0") return false;
            }
            return true;
        }

        static bool CheckWin(string[,] board, string player) // Check if have a victory.
        {
            for (int i = 1; i <= 3; i++)
            {
                if (board[i, 1] == player && board[i, 2] == player && board[i, 3] == player) return true; // Check the line sequence win.
                if (board[1, i] == player && board[2, i] == player && board[3, i] == player) return true; // Check the column sequence win.
            }

            if (board[1, 1] == player && board[2, 2] == player && board[3, 3] == player) return true; // Check the diagonal sequence win.
            if (board[1, 3] == player && board[2, 2] == player && board[3, 1] == player) return true; // Check the other diagonal sequence win.

            return false; // If there is no victory, continue the game.
        }
    }
}