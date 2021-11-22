using System;
using System.Linq;

namespace TicTacToe
{
    public class SimpleComputerPlayer : IPlayer
    {
        public string GamePiece { get; set; }

        public (int, int) Move(string[,] currentMoves)
        {
            // Try to win diagonally.
            var coordinates = FindDiagonalWin(currentMoves);
            if (coordinates != null) { return ((int, int))coordinates; };

            // Try to win horizontally.
            coordinates = FindHorizontalWin(currentMoves);
            if (coordinates != null) { return ((int, int))coordinates; };

            // Try to win vertically.
            coordinates = FindVerticalWin(currentMoves);
            if (coordinates != null) { return ((int, int))coordinates; };

            // Move randomly if no wins were found.
            Random random = new Random();

            while (true)
            {
                int x = random.Next(currentMoves.GetLength(0));
                int y = random.Next(currentMoves.GetLength(1));

                if (currentMoves[x, y] == string.Empty)
                {
                    return (x, y);
                }
            }
        }

        private (int, int)? FindDiagonalWin(string[,] currentMoves)
        {
            return null;

            /*
            string[] principal = new string[Moves.GetLength(0)];
            string[] secondary = new string[Moves.GetLength(0)];

            for (int i = 0; i < Moves.GetLength(0); i++)
            {
                for (int j = 0; j < Moves.GetLength(0); j++)
                {
                    // Checking principal diagonal...
                    if (i == j)
                    {
                        principal[i] = Moves[i, j];
                    }

                    // Checking secondary diagonal...
                    if ((i + j) == (Moves.GetLength(0) - 1))
                    {
                        secondary[i] = Moves[i, j];
                    }
                }
            }

            if (principal.Where(x => x == gamePiece).ToList().Count == principal.Length)
            {
                Console.WriteLine($"{gamePiece} WINS!");
                return true;
            }

            if (secondary.Where(x => x == gamePiece).ToList().Count == secondary.Length)
            {
                Console.WriteLine($"{gamePiece} WINS!");
                return true;
            }

            return false;
            */
        }

        private (int, int)? FindHorizontalWin(string[,] currentMoves)
        {
            // for a 3x3 make sure it's 2 of players and a blank.




            for (int i = 0; i < currentMoves.GetLength(0); i++)
            {
                for (int j = 0; j < currentMoves.GetLength(0); j++)
                {
                    Console.WriteLine(currentMoves[i, j]);
                }
            }





            for (int i = 0; i < currentMoves.GetLength(1); i++)
            {
                var checkRow = Enumerable.Range(0, currentMoves.GetLength(1))
                    .Select(x => currentMoves[i, x])
                    .ToList();

                if ()

                if (checkRow.Count == currentMoves.GetLength(1))
                {
                    Console.WriteLine($"{GamePiece} WINS!");
                    //return true;
                }
            }



            /*





                        for (int i = 0; i < currentMoves.GetLength(1); i++)
            {
                Console.WriteLine(currentMoves[i]);
            }





                currentMoves


            var checkRow = Enumerable.Range(0, currentMoves.GetLength(1))
                    .Where(x => currentMoves[i, x] == GamePiece)
                    .Select(x => currentMoves[i, x])
                    .ToList();





            for (int i = 0; i < currentMoves.GetLength(1); i++)
            {
                var checkRow = Enumerable.Range(0, currentMoves.GetLength(1))
                    .Where(x => currentMoves[i, x] == GamePiece)
                    .Select(x => currentMoves[i, x])
                    .ToList();

                if (checkRow.Count == currentMoves.GetLength(1))
                {
                    Console.WriteLine($"{GamePiece} WINS!");
                    return true;
                }
            }

            return false;
            */






            return null;
            /*
            for (int i = 0; i < Moves.GetLength(1); i++)
            {
                var checkRow = Enumerable.Range(0, Moves.GetLength(1))
                    .Where(x => Moves[i, x] == gamePiece)
                    .Select(x => Moves[i, x])
                    .ToList();

                if (checkRow.Count == Moves.GetLength(1))
                {
                    Console.WriteLine($"{gamePiece} WINS!");
                    return true;
                }
            }

            return false;
            */
        }

        private (int, int)? FindVerticalWin(string[,] currentMoves)
        {
            return null;
            /*
            for (int i = 0; i < Moves.GetLength(0); i++)
            {
                var checkRow = Enumerable.Range(0, Moves.GetLength(0))
                    .Where(x => Moves[x, i] == gamePiece)
                    .Select(x => Moves[x, i])
                    .ToList();

                if (checkRow.Count == Moves.GetLength(0))
                {
                    Console.WriteLine($"{gamePiece} WINS!");
                    return true;
                }
            }

            return false;
            */
        }
    }
}
