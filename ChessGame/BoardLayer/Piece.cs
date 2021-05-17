using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardLayer
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementAmount { get; protected set; }
        public Board Board { get; protected set; }


        public Piece()
        {
        }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            MovementAmount = 0;
        }

        public void IncrementMovementAmount()
        {
            MovementAmount++;
        }

        public void DecrementMovementAmount()
        {
            MovementAmount--;
        }

        public bool CanMove()
        {
            bool[,] listOfMovements = AllowedMovement();
            for (int x = 0; x < Board.Lines; x++)
            {
                for (int y = 0; y < Board.Columns; y++)
                {
                    if (listOfMovements[x,y])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return AllowedMovement()[position.Line, position.Column];
        }

        public abstract bool[,] AllowedMovement();
    }
}
