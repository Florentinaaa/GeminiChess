using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiChessServer
{
    class MoveGenerator
    {
        private Board board;
        private MoveValidator moveValidator;
        public MoveGenerator(Board board, MoveValidator moveValidator)
        {
            this.board = board;
            this.moveValidator = moveValidator;
        }

        public List<MatrixIndex> GenerateMoves(Square squareFrom)
        {
            if (squareFrom.GetPiece()!= null)
            {
                switch (squareFrom.GetPiece().GetPieceType())
                {
                    case PieceType.WhiteKing:
                    case PieceType.BlackKing:
                        return GenerateKingMoves(squareFrom);
                    case PieceType.WhiteQueen:
                    case PieceType.BlackQueen:
                        return GenerateQueenMoves(squareFrom);
                    case PieceType.WhiteArchBishop:
                    case PieceType.BlackArchBishop:
                        return GenerateArchBishopMoves(squareFrom);
                    case PieceType.WhiteBishop:
                    case PieceType.BlackBishop:
                        return GenerateBishopMoves(squareFrom);
                    case PieceType.WhiteKnight:
                    case PieceType.BlackKnight:
                        return GenerateKnightMoves(squareFrom);
                    case PieceType.WhiteRook:
                    case PieceType.BlackRook:
                        return GenerateRookMoves(squareFrom);
                    case PieceType.WhitePawn:
                        return GenerateWhitePawnMoves(squareFrom);
                    case PieceType.BlackPawn:
                        return GenerateBlackPawnMoves(squareFrom);
                    default:
                        return new List<MatrixIndex>();
                }
            }
            return new List<MatrixIndex>();
        }

        private List<MatrixIndex> GenerateBlackPawnMoves(Square squareFrom)
        {
            List<MatrixIndex> moves = new List<MatrixIndex>();
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();

            int x = xFrom + 1;
            if (x < Utils.NUMBER_OF_ROWS)
            {
                Square squareTo = board.GetSquares()[x, yFrom];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(x, yFrom));
                }

                if (yFrom+1 < Utils.NUMBER_OF_COLLUMNS)
                {
                    squareTo = board.GetSquares()[x, yFrom + 1];
                    if (moveValidator.CanMove(squareFrom, squareTo))
                    {
                        moves.Add(new MatrixIndex(x, yFrom + 1));
                    }
                }

                if (yFrom-1 >= 0)
                {
                    squareTo = board.GetSquares()[x, yFrom - 1];
                    if (moveValidator.CanMove(squareFrom, squareTo))
                    {
                        moves.Add(new MatrixIndex(x, yFrom - 1));
                    }
                }
               
            }
             return moves;
        }

        private List<MatrixIndex> GenerateWhitePawnMoves(Square squareFrom)
        {
            List<MatrixIndex> moves = new List<MatrixIndex>();
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();

            int x = xFrom - 1;
            if (x >= 0)
            {
                Square squareTo = board.GetSquares()[x, yFrom];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(x, yFrom));
                }
                if (yFrom+1 < Utils.NUMBER_OF_COLLUMNS)
                {
                    squareTo = board.GetSquares()[x, yFrom + 1];
                    if (moveValidator.CanMove(squareFrom, squareTo))
                    {
                        moves.Add(new MatrixIndex(x, yFrom + 1));
                    }
                }

                if (yFrom-1 >= 0)
                {
                    squareTo = board.GetSquares()[x, yFrom - 1];
                    if (moveValidator.CanMove(squareFrom, squareTo))
                    {
                        moves.Add(new MatrixIndex(x, yFrom - 1));
                    }
                }
            }
            return moves;
        }

        private List<MatrixIndex> GenerateRookMoves(Square squareFrom)
        {
            List<MatrixIndex> moves = new List<MatrixIndex>();
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();

            Square squareTo;
            for (int x = xFrom - 1; x >= 0; x--) // going up
            {
                squareTo = board.GetSquares()[x, yFrom];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(x, yFrom));
                }
            }

            for (int x = xFrom + 1; x < Utils.NUMBER_OF_ROWS; x++) //going down
            {
                squareTo = board.GetSquares()[x, yFrom];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(x, yFrom));
                }
            }

            for (int y = yFrom - 1; y >= 0; y--)//going left
            {
                squareTo = board.GetSquares()[xFrom, y];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom, y));
                }
            }

            for (int y = yFrom + 1; y < Utils.NUMBER_OF_COLLUMNS; y++)//going right
            {
                squareTo = board.GetSquares()[xFrom, y];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom, y));
                }
            }
            return moves;
        }

        private List<MatrixIndex> GenerateKnightMoves(Square squareFrom)
        {
            List<MatrixIndex> moves = new List<MatrixIndex>();
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();
            Square squareTo;
            if (xFrom + 2 < Utils.NUMBER_OF_ROWS && yFrom + 1 < Utils.NUMBER_OF_COLLUMNS)
            {
                squareTo = board.GetSquares()[xFrom + 2, yFrom + 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom + 2, yFrom + 1));
                }
            }

            if (xFrom + 2 < Utils.NUMBER_OF_ROWS && yFrom - 1 >= 0)
            {
                squareTo = board.GetSquares()[xFrom + 2, yFrom - 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom + 2, yFrom - 1));
                }
            }

            if (xFrom - 2 >= 0 && yFrom + 1 < Utils.NUMBER_OF_COLLUMNS)
            {
                squareTo = board.GetSquares()[xFrom - 2, yFrom + 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom - 2, yFrom + 1));
                }
            }

            if (xFrom - 2 >= 0 && yFrom - 1 >= 0)
            {
                squareTo = board.GetSquares()[xFrom - 2, yFrom - 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom - 2, yFrom - 1));
                }
            }

            if (xFrom +1 < Utils.NUMBER_OF_ROWS && yFrom +2 < Utils.NUMBER_OF_COLLUMNS)
            {
                squareTo = board.GetSquares()[xFrom + 1, yFrom + 2];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom + 1, yFrom + 2));
                }
            }

            if (xFrom + 1 < Utils.NUMBER_OF_ROWS && yFrom - 2 >=0)
            {
                squareTo = board.GetSquares()[xFrom + 1, yFrom - 2];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom + 1, yFrom - 2));
                }
            }

            if (xFrom - 1 >= 0 && yFrom + 2 < Utils.NUMBER_OF_COLLUMNS)
            {
                squareTo = board.GetSquares()[xFrom - 1, yFrom + 2];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom - 1, yFrom + 2));
                }
            }

            if (xFrom - 1 >= 0 && yFrom - 2 >=0)
            {
                squareTo = board.GetSquares()[xFrom - 1, yFrom - 2];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom - 1, yFrom - 2));
                }
            }

            return moves;
        }

        private List<MatrixIndex> GenerateBishopMoves(Square squareFrom)
        {
            List<MatrixIndex> moves = new List<MatrixIndex>();
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();
            int y = yFrom + 1;
            Square squareTo;
            for (int x = xFrom - 1; x >= 0 && y < Utils.NUMBER_OF_COLLUMNS; x--) //Up right diagonal
            {
                squareTo = board.GetSquares()[x, y];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(x, y));
                }
                y++;
            }

            y = yFrom - 1;
            for (int x = xFrom + 1; x < Utils.NUMBER_OF_ROWS && y >= 0; x++) //down left diagonal
            {
                squareTo = board.GetSquares()[x, y];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(x, y));
                }
                y--;
            }

            y = yFrom - 1;
            for (int x = xFrom - 1; x >= 0 && y >= 0; x--) //up left diagonal
            {
                squareTo = board.GetSquares()[x, y];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(x, y));
                }
                y--;
            }

            y = yFrom + 1;
            for (int x = xFrom + 1; x < Utils.NUMBER_OF_ROWS && y<Utils.NUMBER_OF_COLLUMNS; x++) //down right diagonal
            {
                squareTo = board.GetSquares()[x, y];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(x, y));
                }
                y++;
            }
            return moves;
        }

        private List<MatrixIndex> GenerateArchBishopMoves(Square squareFrom)
        {
            List<MatrixIndex> moves = new List<MatrixIndex>();
            moves.AddRange(GenerateKnightMoves(squareFrom));
            moves.AddRange(GenerateBishopMoves(squareFrom));
            return moves;
        }

        private List<MatrixIndex> GenerateQueenMoves(Square squareFrom)
        {
            List<MatrixIndex> moves = new List<MatrixIndex>();
            moves.AddRange(GenerateBishopMoves(squareFrom));
            moves.AddRange(GenerateRookMoves(squareFrom));
            return moves;
        }

        private List<MatrixIndex> GenerateKingMoves(Square squareFrom)
        {
            List<MatrixIndex> moves = new List<MatrixIndex>();
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();
            Square squareTo;
            if (xFrom + 1 < Utils.NUMBER_OF_ROWS)
            {
                squareTo = board.GetSquares()[xFrom + 1, yFrom];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom + 1, yFrom));
                }
            }

            if (xFrom + 1 < Utils.NUMBER_OF_ROWS && yFrom-1 >=0)
            {
                squareTo = board.GetSquares()[xFrom + 1, yFrom - 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom + 1, yFrom - 1));
                }
            }

            if (xFrom + 1 < Utils.NUMBER_OF_ROWS && yFrom + 1 < Utils.NUMBER_OF_COLLUMNS)
            {
                squareTo = board.GetSquares()[xFrom + 1, yFrom + 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom + 1, yFrom + 1));
                }
            }

            if (xFrom - 1 >= 0 )
            {
                squareTo = board.GetSquares()[xFrom - 1, yFrom];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom - 1, yFrom));
                }
            }

            if (xFrom - 1 >= 0 && yFrom + 1 < Utils.NUMBER_OF_COLLUMNS)
            {
                squareTo = board.GetSquares()[xFrom - 1, yFrom + 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom - 1, yFrom + 1));
                }
            }

            if (xFrom - 1 >= 0 && yFrom - 1 >= 0)
            {
                squareTo = board.GetSquares()[xFrom - 1, yFrom - 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom - 1, yFrom - 1));
                }
            }

            if (yFrom+1 < Utils.NUMBER_OF_COLLUMNS)
            {
                squareTo = board.GetSquares()[xFrom, yFrom + 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom, yFrom + 1));
                }
            }

            if (yFrom - 1 >=0)
            {
                squareTo = board.GetSquares()[xFrom, yFrom - 1];
                if (moveValidator.CanMove(squareFrom, squareTo))
                {
                    moves.Add(new MatrixIndex(xFrom, yFrom - 1));
                }
            }

            return moves;
        }
    }
}
