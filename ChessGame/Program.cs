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
            chessBoard.InsertPiece(new Rook(Color.Black, chessBoard), new Position(0, 0));
            chessBoard.InsertPiece(new Rook(Color.Black, chessBoard), new Position(1, 3));
            chessBoard.InsertPiece(new King(Color.Black, chessBoard), new Position(2, 4));

            Display.PrintBoard(chessBoard);
        }
    }
}
