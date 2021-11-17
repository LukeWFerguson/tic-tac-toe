using Spectre.Console;
using System;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        private static string[,] _moves;

        static void Main()
        {
            int boardSize = GetBoardSize();
            _moves = InitBoard(boardSize);
            Console.WriteLine($"Your board size is: {boardSize}");
            AnsiConsole.Write(DrawBoard(_moves));

            while (true)
            {
                Move("x");
                AnsiConsole.Write(DrawBoard(_moves));
                IsGameComplete();

                Console.WriteLine("Computer's turn...");
                ComputerTurn(); // TODO: Eventually make a smart player.
                AnsiConsole.Write(DrawBoard(_moves));
                IsGameComplete();
            }
        }

        // Bug in the board size, I was able to get an 11x11 created.
        private static int GetBoardSize(int boardSize = 3)
        {
            while (true)
            {
                Console.WriteLine("Enter the board size from 1 to 9 (for 3x3, enter 3):");
                var size = Console.ReadLine();

                if (string.IsNullOrEmpty(size))
                {
                    return boardSize;
                }
                else
                {
                    try
                    {
                        boardSize = Convert.ToInt32(size);

                        if (boardSize < 1)
                        {
                            throw new Exception("Integer needs to be greater than 1.");
                        }

                        if (boardSize > 9)
                        {
                            throw new Exception("Integer needs to be less than 9.");
                        }

                        return boardSize;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unable to continue, please enter a single number from 1 to 9.");
                    }
                }
            }
        }

        private static string[,] InitBoard(int boardSize)
        {
            string[,] array = new string[boardSize, boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    array[i, j] = string.Empty;
                }
            }

            return array;
        }

        private static Table DrawBoard(string[,] _moves)
        {
            // Creating table.
            var table = new Table()
                .Border(TableBorder.Rounded)
                .AddColumn(new TableColumn(string.Empty));

            // Adding columns.
            for (int i = 0; i < _moves.GetLength(0); i++)
            {
                table.AddColumn(new TableColumn($"{i}"));
            }

            // Adding rows.
            for (int i = 0; i < _moves.GetLength(0); i++)
            {
                // Getting single row.
                var row = Enumerable.Range(0, _moves.GetLength(1))
                    .Select(x => _moves[i, x])
                    .ToList();

                // Adding row header and row itself.
                table.AddRow(row.Prepend($"{i}").ToArray());
            }

            return table;
        }

        private static void Move(string piece)
        {
            while (true)
            {
                Console.WriteLine("Enter your move (for 1, 1 enter 11):");
                var move = Console.ReadLine().Select(c => c - '0').ToArray();

                if (move.Any())
                {
                    try
                    {
                        int x = Convert.ToInt32(move[1]);
                        int y = Convert.ToInt32(move[0]);

                        if (_moves[x, y] != string.Empty)
                        {
                            throw new Exception("Position is already taken.");
                        }

                        _moves[x, y] = piece;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        // TODO: Probably should combine this with the user move function.
        private static void ComputerTurn()
        {
            Random random = new Random();

            // TODO: We should change this by first getting ONLY the possible moves. For now, loop until there is an empty string.
            while (true)
            {
                int x = random.Next(_moves.GetLength(0));
                int y = random.Next(_moves.GetLength(1));

                if (_moves[x, y] == string.Empty)
                {
                    _moves[x, y] = "o";
                    break;
                }
            }
        }

        // TODO: Implement this, need to unit test this specifically.
        // Return whether winner or draw.
        // TODO: Check for winner first (horizontal / vertical / diagonal), then any available moved.
        private static void IsGameComplete()
        {
            // Check horizontal.
            for (int i = 0; i < _moves.GetLength(1); i++)
            {
                var checkXRow = Enumerable.Range(0, _moves.GetLength(1))
                    .Where(x => _moves[i, x] == "x")
                    .Select(x => _moves[i, x])
                    .ToList();

                if (checkXRow.Count == _moves.GetLength(1))
                {
                    Console.WriteLine("x WINS!");
                    Environment.Exit(0);
                }

                var checkORow = Enumerable.Range(0, _moves.GetLength(1))
                    .Where(x => _moves[i, x] == "o")
                    .Select(x => _moves[i, x])
                    .ToList();

                if (checkORow.Count == _moves.GetLength(1))
                {
                    Console.WriteLine("o WINS!");
                    Environment.Exit(0);
                }
            }

            // Check vertical.
            for (int i = 0; i < _moves.GetLength(0); i++)
            {
                var checkXRow = Enumerable.Range(0, _moves.GetLength(0))
                    .Where(x => _moves[x, i] == "x")
                    .Select(x => _moves[x, i])
                    .ToList();

                if (checkXRow.Count == _moves.GetLength(0))
                {
                    Console.WriteLine("x WINS!");
                    Environment.Exit(0);
                }

                var checkORow = Enumerable.Range(0, _moves.GetLength(0))
                    .Where(x => _moves[x, i] == "o")
                    .Select(x => _moves[x, i])
                    .ToList();

                if (checkORow.Count == _moves.GetLength(0))
                {
                    Console.WriteLine("o WINS!");
                    Environment.Exit(0);
                }
            }

            // Check Primary and Secondary Diagonals
            string[] principal = new string[_moves.GetLength(0)];
            string[] secondary = new string[_moves.GetLength(0)];

            for (int i = 0; i < _moves.GetLength(0); i++)
            {
                for (int j = 0; j < _moves.GetLength(0); j++)
                {

                    // Condition for principal
                    // diagonal
                    if (i == j)
                    {
                        principal[i] = _moves[i, j];
                    }

                    // Condition for secondary
                    // diagonal
                    if ((i + j) == (_moves.GetLength(0) - 1))
                    {
                        secondary[i] = _moves[i, j];
                    }
                }
            }

            if (principal.Where(x => x == "x").ToList().Count == principal.Length)
            {
                Console.WriteLine("x WINS!");
                Environment.Exit(0);
            }

            if (principal.Where(x => x == "o").ToList().Count == principal.Length)
            {
                Console.WriteLine("o WINS!");
                Environment.Exit(0);
            }

            if (secondary.Where(x => x == "x").ToList().Count == secondary.Length)
            {
                Console.WriteLine("x WINS!");
                Environment.Exit(0);
            }

            if (secondary.Where(x => x == "o").ToList().Count == secondary.Length)
            {
                Console.WriteLine("o WINS!");
                Environment.Exit(0);
            }

            // Are any moves available?
            var query = from string move in _moves
                        where move == string.Empty
                        select move;

            if (!query.Any())
            {
                Console.WriteLine("Draw!");
                Environment.Exit(0);
            }
        }
    }
}
