using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardLayer
{
    class BoardException : Exception
    {
        public BoardException(string msg) : base(msg) { }
    }
}
