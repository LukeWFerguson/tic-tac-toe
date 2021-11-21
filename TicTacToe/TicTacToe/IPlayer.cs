namespace TicTacToe
{
    public interface IPlayer
    {
        (int, int) Move(string[,] currentMoves);

        string GamePiece { get; set; }
    }
}
