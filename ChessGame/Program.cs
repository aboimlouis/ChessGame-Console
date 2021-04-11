using System;
using ChessGame.BoardLayer;
using ChessGame.ChessGame;
namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board chessBoard = new Board(8,8);

            ChessInGame inGame = new ChessInGame();

            Display.PrintBoard(inGame.GetBoard());
        }
    }
}
