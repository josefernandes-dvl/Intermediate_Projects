using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool play = true;

            while (play)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tic Tac Toe Game! (by José Fernandes)");
                Console.WriteLine("---------------------------------------------------");
                Console.Write("Enter the username of the player one: ");
                string p1 = Console.ReadLine();
                Console.Write("\nEnter the username of the player two: ");
                string p2 = Console.ReadLine();
                Console.WriteLine("");

                string[,] tictactoe = new string[4, 4]
                {
                    { "", "1", "2", "3" },
                    { "A", "0", "0", "0" },
                    { "B", "0", "0", "0" },
                    { "C", "0", "0", "0" }
                };

                GameExib(tictactoe);
                bool cont = true;

                while (cont)
                {
                    cont = PlayerMove(p1, "1", tictactoe);
                    if (!cont) break;

                    cont = PlayerMove(p2, "2", tictactoe);
                }

                Console.WriteLine("\nWould you like to:");
                Console.WriteLine("a) Reset the game");
                Console.WriteLine("b) Quit the game");
                string choice = Console.ReadLine().ToLower();

                if (choice != "a")
                {
                    play = false;
                }
            }
        }

        static void GameExib(string[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
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

                if (IsValidMove(response, board))
                {
                    MarkPosition(response, playerSymbol, board);
                    Console.Clear();
                    GameExib(board);

                    if (CheckWin(board, playerSymbol))
                    {
                        Console.WriteLine("\nCongratulations, " + playerName + ", YOU WIN!");
                        return false;
                    }

                    if (IsDraw(board))
                    {
                        Console.WriteLine("\nThe game ended in a draw!");
                        return false;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move or position already marked. Please try again.");
                }
            }
            return true;
        }

        static bool IsValidMove(string move, string[,] board)
        {
            int row = 0, col = 0;

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

        static void MarkPosition(string move, string playerSymbol, string[,] board)
        {
            int row = 0, col = 0;

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

        static bool IsDraw(string[,] board)
        {
            foreach (string cell in board)
            {
                if (cell == "0") return false;
            }
            return true;
        }

        static bool CheckWin(string[,] board, string player)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (board[i, 1] == player && board[i, 2] == player && board[i, 3] == player) return true;
                if (board[1, i] == player && board[2, i] == player && board[3, i] == player) return true;
            }

            if (board[1, 1] == player && board[2, 2] == player && board[3, 3] == player) return true;
            if (board[1, 3] == player && board[2, 2] == player && board[3, 1] == player) return true;

            return false;
        }
    }
}