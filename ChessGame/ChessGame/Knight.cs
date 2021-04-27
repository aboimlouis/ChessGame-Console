using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
        {

        }

        public override bool[,] AllowedMovement()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "N";
        }
    }
}
