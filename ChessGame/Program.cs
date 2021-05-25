using System;
using ChessGame.BoardLayer;
using ChessGame.ChessGame;
namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessInGame inGame = new ChessInGame();

            while (!inGame.End)
            {
                try
                {
                    //Console.Clear();
                    Display.PrintTurn(inGame);
                    Console.Write("Origin: ");
                    Position origin = Display.ReadChessPosition().ToPosition();
                    inGame.ValidateOriginPostion(origin);

                    bool[,] possiblePosition = inGame.ChessBoard.GetPiece(origin).AllowedMovement();


                    //Console.Clear();
                    Display.PrintMovement(inGame.ChessBoard, possiblePosition);
                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Display.ReadChessPosition().ToPosition();
                    inGame.ValidateDestinationPosition(origin, destination);

                    inGame.ExecutePlay(origin, destination);

                    if (!inGame.End)
                    {
                        if (inGame.Check)
                        {
                            ConsoleColor consoleColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("CHECK");
                            Console.ForegroundColor = consoleColor;
                        }
                    }
                    else
                    {
                        ConsoleColor consoleColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Check Mate!");
                        Console.ForegroundColor = consoleColor;
                        Console.WriteLine("The winner is: " + inGame.ColorTurn);
                    }
                }
                catch (BoardException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
