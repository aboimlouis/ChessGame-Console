using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class ChessInGame
    {
        public Board ChessBoard { get; private set; }
        public  int Turn { get; private set; }
        public bool End { get; private set; }
        public bool Check { get; private set; }
        public Color ColorTurn { get; private set; }
        private Piece[,] Pieces;
        private List<Piece> InGamePieces;
        private List<Piece> CapturedPieces;
        public ChessInGame()
        {
            this.ChessBoard = new Board(8, 8);
            this.Turn = 1;
            this.ColorTurn = Color.White;
            End = false;
            Check = false;
            Pieces = new Piece[,]{
                {
                    new Rook(Color.Black, ChessBoard),
                    new Knight(Color.Black, ChessBoard),
                    new Bishop(Color.Black, ChessBoard),
                    new King(Color.Black, ChessBoard),
                    new Queen(Color.Black, ChessBoard),
                    new Bishop(Color.Black, ChessBoard),
                    new Knight(Color.Black, ChessBoard),
                    new Rook(Color.Black, ChessBoard)
                },
                {
                    new Rook(Color.White, ChessBoard),
                    new Knight(Color.White, ChessBoard),
                    new Bishop(Color.White, ChessBoard),
                    new King(Color.White, ChessBoard),
                    new Queen(Color.White, ChessBoard),
                    new Bishop(Color.White, ChessBoard),
                    new Knight(Color.White, ChessBoard),
                    new Rook(Color.White, ChessBoard)
                },
            };
            CapturedPieces = new List<Piece>();
            InGamePieces = new List<Piece>();
            PlacePieces();
        }
        
        public List<Piece> TakenPieces(Color color)
        {
            return CapturedPieces.FindAll(piece => piece.Color == color);
        }
        public List<Piece> GamePieces(Color color)
        {
            return InGamePieces.FindAll(piece => piece.Color == color);
        }
        private Piece ExecuteMove(Position origin, Position destination)
        {
            Piece piece = ChessBoard.RemovePiece(origin);
            piece.IncrementMovementAmount();
            Piece takenPiece = ChessBoard.RemovePiece(destination);
            ChessBoard.InsertPiece(piece, destination);
            if (takenPiece != null) 
            {
                CapturedPieces.Add(takenPiece);
                InGamePieces.Remove(takenPiece);
            }
            return takenPiece;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = ChessBoard.RemovePiece(destination);
            piece.DecrementMovementAmount();
            if(capturedPiece != null)
            {
                ChessBoard.InsertPiece(capturedPiece, destination);
                CapturedPieces.Remove(capturedPiece);
            }

            ChessBoard.InsertPiece(piece, origin);
        }

        public void ExecutePlay(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMove(origin, destination);

            if (CalculateCheck(ColorTurn))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            Check = CalculateCheck(Adversary(ColorTurn));
            End = CalculateCheckMate(Adversary(ColorTurn));
            Turn++;
            ChangePlayer();
        }


        private Color Adversary(Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }

        private Piece GetKing(Color color)
        {
            return GamePieces(color).Find(piece => piece is King);
        }

        public bool CalculateCheck(Color color)
        {
            Piece king = GetKing(color);
            foreach (Piece piece in GamePieces(Adversary(color)))
            {
                bool[,] movements = piece.AllowedMovement();
                if (movements[king.Position.Line, king.Position.Column]) return true;
            }
            return false;
        }

        public bool CalculateCheckMate(Color color)
        {
            if (!CalculateCheck(color)) return false;
            foreach (Piece piece in GamePieces(color))
            {
                bool[,] possibleMoves = piece.AllowedMovement();
                for (int x = 0; x < ChessBoard.Lines; x++)
                {
                    for (int y = 0; y < ChessBoard.Lines; y++)
                    {
                        if (possibleMoves[x,y])
                        {
                            Position origin = piece.Position;
                            Position destination = new Position(x, y);
                            Piece capturedPiece = ExecuteMove(origin, destination);
                            bool testCheck = CalculateCheck(color);
                            UndoMove(origin, destination, capturedPiece);
                            if(!testCheck) return false;
                        }
                    }
                }
            }
            return true;
        }

        public void ValidateOriginPostion(Position position)
        {
            if (ChessBoard.GetPiece(position) == null)
                throw new BoardException("Empty space.");
            if (ColorTurn != ChessBoard.GetPiece(position).Color)
                throw new BoardException("Piece not controlled by the player.");
            if (!ChessBoard.GetPiece(position).CanMove())
                throw new BoardException("Piece can not move.");
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!ChessBoard.GetPiece(origin).CanMoveTo(destination))
                throw new BoardException("Can not move piece to desired destination.");
        }

        private void ChangePlayer()
        {
            ColorTurn = ColorTurn == Color.White ? Color.Black : Color.White;
        }
        private void PlacePieces()
        {

            for (int i = 1; i < ChessBoard.Lines + 1; i++)
            {
                PlaceNewPiece((char)(96 + i), 7, new Pawn(Color.Black, ChessBoard));
                PlaceNewPiece((char)(96 + i), 8, Pieces[0, i - 1]);
                PlaceNewPiece((char)(96 + i), 2, new Pawn(Color.White, ChessBoard));
                PlaceNewPiece((char)(96 + i), 1, Pieces[1, i - 1]);
            }
        }
        public void PlaceNewPiece(char column, int line, Piece piece)
        {
            ChessBoard.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
            InGamePieces.Add(piece);
        }
    }
}
