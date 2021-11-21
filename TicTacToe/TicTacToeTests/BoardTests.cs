using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    public class BoardTests
    {
        [Test]
        public void SizeTest()
        {
            Board board = new Board(size: 0);
            Assert.AreEqual(expected: 0, actual: board.Size);
            Assert.AreEqual(expected: 0, actual: board.Moves.GetLength(0));

            board = new Board(size: 1);
            Assert.AreEqual(expected: 1, actual: board.Size);
            Assert.AreEqual(expected: 1, actual: board.Moves.GetLength(0));

            board = new Board(size: 2);
            Assert.AreEqual(expected: 2, actual: board.Size);
            Assert.AreEqual(expected: 2, actual: board.Moves.GetLength(0));
        }

        [Test]
        public void PositionTest()
        {
            Board board = new Board(size: 3);
            board.Move((2, 0), "x"); // Bottom left.
            board.DrawBoard();
            Assert.AreNotEqual(expected: string.Empty, actual: board.Moves[2, 0]);
            Assert.AreEqual(expected: "x", actual: board.Moves[2, 0]);
        }

        [Test]
        public void DiagonalWinnerTest()
        {
            Board primary = new Board(size: 3);
            primary.Move((0, 0), "x"); // Top left
            Assert.AreEqual(expected: false, actual: primary.IsGameComplete());
            primary.Move((1, 1), "x"); // Center
            Assert.AreEqual(expected: false, actual: primary.IsGameComplete());
            primary.Move((2, 2), "x"); // Bottom right
            Assert.AreEqual(expected: true, actual: primary.IsGameComplete());
            primary.DrawBoard();

            Board secondary = new Board(size: 3);
            secondary.Move((2, 0), "x"); // Bottom left
            Assert.AreEqual(expected: false, actual: secondary.IsGameComplete());
            secondary.Move((1, 1), "x"); // Center
            Assert.AreEqual(expected: false, actual: secondary.IsGameComplete());
            secondary.Move((0, 2), "x"); // Top right
            Assert.AreEqual(expected: true, actual: secondary.IsGameComplete());
            secondary.DrawBoard();
        }

        [Test]
        public void HorizontalWinnerTest()
        {
            Board board = new Board(size: 3);
            board.Move((0, 0), "x");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((0, 1), "x");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((0, 2), "x");
            Assert.AreEqual(expected: true, actual: board.IsGameComplete());
            board.DrawBoard();
        }

        [Test]
        public void VerticalWinnerTest()
        {
            Board board = new Board(size: 3);
            board.Move((0, 0), "x");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((1, 0), "x");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((2, 0), "x");
            Assert.AreEqual(expected: true, actual: board.IsGameComplete());
            board.DrawBoard();
        }

        [Test]
        public void IsDrawTest()
        {
            Board board = new Board(size: 3);
            board.Move((0, 0), "x");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((0, 1), "o");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((0, 2), "x");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((1, 0), "x");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((1, 1), "o");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((1, 2), "o");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((2, 0), "o");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((2, 1), "x");
            Assert.AreEqual(expected: false, actual: board.IsGameComplete());
            board.Move((2, 2), "x");
            Assert.AreEqual(expected: true, actual: board.IsGameComplete());
            board.DrawBoard();
        }
    }
}