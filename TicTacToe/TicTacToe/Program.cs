using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            // Infinite play, the fun NEVER ends!
            while (true)
            {
                Console.WriteLine(); // Creating some space.
                WelcomeMessage();
                Console.WriteLine(); // Creating some space.

                // Initializing board given the size from the user.
                int boardSize = DetermineBoardSize();
                Board board = new Board(size: boardSize);
                board.DrawBoard();

                // Initializing players.
                var gamePieceOrder = GetGamePieces();

                IPlayer fleshAndBloodPlayer = new FleshAndBloodPlayer();
                fleshAndBloodPlayer.GamePiece = gamePieceOrder.Item1;

                IPlayer computerPlayer = new SimpleComputerPlayer();
                computerPlayer.GamePiece = gamePieceOrder.Item2;

                // Determining order of play and starting.
                bool crossesTurn = false;

                if (fleshAndBloodPlayer.GamePiece == "x")
                {
                    crossesTurn = true;
                }

                while (true)
                {
                    if (crossesTurn == true)
                    {
                        var coordinates = fleshAndBloodPlayer.Move(currentMoves: board.Moves);
                        board.Move(coordinates, fleshAndBloodPlayer.GamePiece);
                        crossesTurn = false;
                    }
                    else
                    {
                        var coordinates = computerPlayer.Move(currentMoves: board.Moves);
                        board.Move(coordinates, computerPlayer.GamePiece);
                        crossesTurn = true;
                    }

                    board.DrawBoard();
                    if (board.IsGameComplete() == true) break;
                }
            }
        }

        private static (string, string) GetGamePieces()
        {
            if (new Random().Next(2) == 0)
            {
                return ("x", "o");
            }

            return ("o", "x");
        }

        private static void WelcomeMessage()
        {
            List<string> wurstJokes = new List<string> {
                "What do you call someone with mints on their feet? Tic tac toes",
                "If athletes get athlete's foot, what do candy makers get? Tic tac toe",
                "I played my Asian friend in Tic Tac Toe. It was a Thai.",
                "What you call toes that taste like mint? Tic tac toe",
                "How many birds can play tic-tac-toe? Toucan",
                "Have you heard of the Tic-Tac-Toe Beetle? It has an X-O-skeleton.",
                "What do you get when astronomers play tic-tac-toe? Exoplanets",
            };

            int index = new Random().Next(wurstJokes.Count);
            Console.WriteLine(wurstJokes[index]);
        }

        private static int DetermineBoardSize()
        {
            while (true)
            {
                Console.WriteLine("Enter the board size as a positive integer (for 3x3, enter 3):");

                try
                {
                    var line = Console.ReadLine();
                    int size = Convert.ToInt32(line);

                    if (size < 1)
                    {
                        throw new Exception("Size needs to be a positive integer.");
                    }

                    Console.WriteLine($"Your board size is: {size}");
                    return size;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to continue.");
                }
            }
        }
    }
}