using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {

        }

        public override bool[,] AllowedMovement()
        {
            bool[,] validMovement = new bool[Board.Lines, Board.Columns];

            Position futurePosition = new Position(0,0);

            //north
            futurePosition.DefinePosition(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }
            //northeast
            futurePosition.DefinePosition(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }
            //east
            futurePosition.DefinePosition(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }
            //southeast
            futurePosition.DefinePosition(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }
            //south
            futurePosition.DefinePosition(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }
            //southwest
            futurePosition.DefinePosition(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }
            //west
            futurePosition.DefinePosition(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }
            //northwest
            futurePosition.DefinePosition(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }

            return validMovement;
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override string ToString()
        {
            return "K";
        }


    }
}
