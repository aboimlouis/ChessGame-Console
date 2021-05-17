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
            bool[,] validMovement = new bool[Board.Lines, Board.Columns];
            Position futurePosition = new Position(0, 0);

            futurePosition.DefinePosition(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }

            futurePosition.DefinePosition(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }

            futurePosition.DefinePosition(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }

            futurePosition.DefinePosition(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }

            futurePosition.DefinePosition(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }

            futurePosition.DefinePosition(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }

            futurePosition.DefinePosition(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
            }

            futurePosition.DefinePosition(Position.Line + 1, Position.Column - 2);
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
            return "N";
        }
    }
}
