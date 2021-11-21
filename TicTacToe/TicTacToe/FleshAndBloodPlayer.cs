using System;

namespace TicTacToe
{
    public class FleshAndBloodPlayer : IPlayer
    {
        public string GamePiece { get; set; }

        public (int, int) Move(string[,] currentMoves)
        {
            int x, y;

            while (true)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter your X coordinate (x: 2, y: 0 = bottom left on a 3x3):");
                        x = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter your Y coordinate (x: 2, y: 0 = bottom left on a 3x3):");
                        y = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                try
                {
                    if (currentMoves[x, y] != string.Empty)
                    {
                        throw new Exception("Position is already taken.");
                    }

                    return (x, y);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
