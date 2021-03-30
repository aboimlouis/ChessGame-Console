using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
