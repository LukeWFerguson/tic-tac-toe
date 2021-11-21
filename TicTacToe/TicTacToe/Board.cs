using Spectre.Console;
using System;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        public string[,] Moves { get; private set; }
        public int Size { get; set; }

        public Board(int size)
        {
            Size = size;
            Init();
        }

        private void Init()
        {
            string[,] array = new string[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    array[i, j] = string.Empty;
                }
            }

            Moves = array;
        }

        public void DrawBoard()
        {
            // Creating table.
            var table = new Table()
                .Border(TableBorder.Rounded)
                .AddColumn(new TableColumn(string.Empty));

            // Adding columns.
            for (int i = 0; i < Moves.GetLength(0); i++)
            {
                table.AddColumn(new TableColumn($"{i}"));
            }

            // Adding rows.
            for (int i = 0; i < Moves.GetLength(0); i++)
            {
                // Getting single row.
                var row = Enumerable.Range(0, Moves.GetLength(1))
                    .Select(x => Moves[i, x])
                    .ToList();

                // Adding row header and row itself.
                table.AddRow(row.Prepend($"{i}").ToArray());
            }

            AnsiConsole.Write(table);
        }

        public void Move((int, int) move, string gamePiece)
        {
            Moves[move.Item1, move.Item2] = gamePiece;
        }

        public bool IsGameComplete()
        {
            // Is Winner?
            if (DiagonalWinner("x") == true) { return true; };
            if (DiagonalWinner("o") == true) { return true; };

            if (HorizontalWinner("x") == true) { return true; };
            if (HorizontalWinner("o") == true) { return true; };

            if (VerticalWinner("x") == true) { return true; };
            if (VerticalWinner("o") == true) { return true; };

            // Is Draw?
            if (IsDraw() == true) { return true; };

            // Play on!
            return false;
        }

        private bool DiagonalWinner(string gamePiece)
        {
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
        }

        private bool HorizontalWinner(string gamePiece)
        {
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
        }

        private bool VerticalWinner(string gamePiece)
        {
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
        }

        private bool IsDraw()
        {
            // Are any moves available?
            var query = from string move in Moves
                        where move == string.Empty
                        select move;

            if (!query.Any())
            {
                Console.WriteLine("Draw!");
                return true;
            }

            return false;
        }
    }
}
