using System;
using System.Linq;

namespace TicTacToe
{
    public class RandomComputerPlayer : IPlayer
    {
        public string GamePiece { get; set; }

        public (int, int) Move(string[,] currentMoves)
        {
            Random random = new Random();

            // Not very efficient since it is trying till it gets a free position.
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
    }
}
