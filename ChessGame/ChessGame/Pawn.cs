using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
        }

        public override bool[,] AllowedMovement()
        {
            bool[,] validMovement = new bool[Board.Lines, Board.Columns];

            Position futurePosition = new Position(0, 0);

            if(Color == Color.White)
            {
                futurePosition.DefinePosition(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(futurePosition) && FreeToMove(futurePosition))
                {
                    validMovement[futurePosition.Line, futurePosition.Column] = true;
                }

                futurePosition.DefinePosition(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(futurePosition) && FreeToMove(futurePosition) && MovementAmount == 0)
                {
                    validMovement[futurePosition.Line, futurePosition.Column] = true;
                }

                futurePosition.DefinePosition(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(futurePosition) && EnemyInPosition(futurePosition))
                {
                    validMovement[futurePosition.Line, futurePosition.Column] = true;
                }

                futurePosition.DefinePosition(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(futurePosition) && EnemyInPosition(futurePosition))
                {
                    validMovement[futurePosition.Line, futurePosition.Column] = true;
                }
            }
            else
            {
                futurePosition.DefinePosition(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(futurePosition) && FreeToMove(futurePosition))
                {
                    validMovement[futurePosition.Line, futurePosition.Column] = true;
                }

                futurePosition.DefinePosition(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(futurePosition) && FreeToMove(futurePosition) && MovementAmount == 0)
                {
                    validMovement[futurePosition.Line, futurePosition.Column] = true;
                }

                futurePosition.DefinePosition(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(futurePosition) && EnemyInPosition(futurePosition))
                {
                    validMovement[futurePosition.Line, futurePosition.Column] = true;
                }

                futurePosition.DefinePosition(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(futurePosition) && EnemyInPosition(futurePosition))
                {
                    validMovement[futurePosition.Line, futurePosition.Column] = true;
                }
            }

            return validMovement;
        }

        private bool EnemyInPosition(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece.Color != Color;
        }

        private bool FreeToMove(Position position)
        {
            return Board.GetPiece(position) == null;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
