using System;
using ChessGame.BoardLayer;
using ChessGame.ChessGame;
namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessInGame inGame = new ChessInGame();

            while (!inGame.End)
            {
                Console.Clear();
                Display.PrintBoard(inGame.ChessBoard);

                Console.WriteLine();
                Console.WriteLine("Turn: " + inGame.Turn);
                Console.WriteLine("Waiting for play: " + inGame.ColorTurn.ToString());
                Console.Write("Origin: ");
                Position origin = Display.ReadChessPosition().ToPosition();

                bool[,] possiblePosition = inGame.ChessBoard.GetPiece(origin).AllowedMovement();
                

                Console.Clear();
                Display.PrintMovement(inGame.ChessBoard, possiblePosition);
                Console.WriteLine();

                Console.Write("Destination: ");
                Position destination = Display.ReadChessPosition().ToPosition();

                inGame.ExecutePlay(origin, destination);
            }
        }
    }
}
