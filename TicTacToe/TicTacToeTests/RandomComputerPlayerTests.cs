using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace TicTacToeTests
{
    public class RandomComputerPlayerTests
    {
        [Test]
        public void MoveTest()
        {
            // Init board and computer.
            Board board = new Board(size: 3);
            IPlayer computerPlayer = new RandomComputerPlayer();
            computerPlayer.GamePiece = "x";

            // Fill the board exept one move.
            board.Move((0, 0), "x");
            board.Move((0, 1), "o");
            board.Move((0, 2), "x");
            board.Move((1, 0), "x");
            board.Move((1, 1), "o");
            board.Move((1, 2), "o");
            board.Move((2, 0), "o");
            board.Move((2, 1), "x");
            //board.Move((2, 2), "x"); // This one should be the ONLY one chosen by the computer.

            board.DrawBoard();

            var coordinates = computerPlayer.Move(currentMoves: board.Moves);
            Assert.AreEqual(expected: (2, 2), actual: coordinates);
            board.Move(coordinates, computerPlayer.GamePiece);
            board.DrawBoard();
            Assert.AreEqual(expected: true, actual: board.IsGameComplete());
        }
    }
}
