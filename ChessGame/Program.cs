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
                Display.PrintBoard(inGame.GetBoard());

                Console.WriteLine();
                Console.Write("Origin: ");
                Position origin = Display.ReadChessPosition().ToPosition();
                Console.Write("Destination: ");
                Position destination = Display.ReadChessPosition().ToPosition();

                inGame.ExecuteMove(origin, destination);
            }
        }
    }
}
