using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
