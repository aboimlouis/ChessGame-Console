using System;
using ChessGame.BoardLayer;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board chessBoard = new Board(8,8);
            Display.PrintBoard(chessBoard);
        }
    }
}
