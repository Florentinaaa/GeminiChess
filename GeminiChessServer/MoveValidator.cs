using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiChessServer
{
    class MoveValidator
    {
        private Board board;
        public MoveValidator(Board board)
        {
            this.board = board;
        }

        public bool CanMove(Square squareFrom, Square squareTo)
        {
            if (squareFrom.GetPiece()!= null)
            {
                switch (squareFrom.GetPiece().GetPieceType())
                {
                    case PieceType.BlackKnight:
                    case PieceType.WhiteKnight:
                        return CanMoveKnight(squareFrom, squareTo);

                    case PieceType.BlackBishop:
                    case PieceType.WhiteBishop:
                        return CanMoveBishop(squareFrom, squareTo);

                    case PieceType.BlackRook:
                    case PieceType.WhiteRook:
                        return CanMoveRook(squareFrom, squareTo);

                    case PieceType.BlackArchBishop:
                    case PieceType.WhiteArchBishop:
                        return CanMoveArchBishop(squareFrom, squareTo);

                    case PieceType.BlackQueen:
                    case PieceType.WhiteQueen:
                        return CanMoveQueen(squareFrom, squareTo);

                    case PieceType.BlackPawn:
                        return CanMoveBlackPawn(squareFrom, squareTo);

                    case PieceType.WhitePawn:
                        return CanMoveWhitePawn(squareFrom, squareTo);

                    case PieceType.BlackKing:
                    case PieceType.WhiteKing:
                        return CanMoveKing(squareFrom, squareTo);
                    default:
                        return false;
                }
            }
            return false;
        }

        private bool CanMoveWhitePawn(Square squareFrom, Square squareTo)
        {
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();
            int xTo = squareTo.GetPosition().GetLocationX();
            int yTo = squareTo.GetPosition().GetLocationY();
            if ((xFrom - 1) == xTo)
            {
                if (yFrom == yTo && squareTo.GetPiece() == null)
                    return true;
                else
                    if ((yFrom + 1 == yTo && squareTo.GetPiece() != null && squareTo.GetPiece().GetPieceType() < 0)
                    || (yFrom - 1 == yTo && squareTo.GetPiece() != null && squareTo.GetPiece().GetPieceType() < 0))
                    return true;
            }
            return false;
        }
        private bool CanMoveBlackPawn(Square squareFrom, Square squareTo)
        {
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();
            int xTo = squareTo.GetPosition().GetLocationX();
            int yTo = squareTo.GetPosition().GetLocationY();
            if ((xFrom + 1) == xTo)
            {
                if (yFrom == yTo && squareTo.GetPiece() == null)
                    return true;
                else
                    if ((yFrom + 1 == yTo && squareTo.GetPiece() != null && squareTo.GetPiece().GetPieceType() > 0)
                    || (yFrom - 1 == yTo && squareTo.GetPiece() != null && squareTo.GetPiece().GetPieceType() > 0))
                    return true;
            }
            return false;
        }

        private bool CanMoveKing(Square squareFrom, Square squareTo)
        {
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();
            int xTo = squareTo.GetPosition().GetLocationX();
            int yTo = squareTo.GetPosition().GetLocationY();
            bool pieceCond = squareTo.GetPiece() == null || checkIfOpponentPiece(squareFrom.GetPiece(),squareTo.GetPiece());
            bool cond1 = xTo == xFrom + 1 && yTo == yFrom;
            bool cond2 = xTo == xFrom + 1 && yTo == yFrom - 1;
            bool cond3 = xTo == xFrom + 1 && yTo == yFrom + 1;
            bool cond4 = xTo == xFrom - 1 && yTo == yFrom;
            bool cond5 = xTo == xFrom - 1 && yTo == yFrom + 1;
            bool cond6 = xTo == xFrom - 1 && yTo == yFrom - 1;
            bool cond7 = xTo == xFrom && yTo == yFrom + 1;
            bool cond8 = xTo == xFrom && yTo == yFrom - 1;
            return (cond1 || cond2 || cond3 || cond4 || cond5 || cond6 || cond7 || cond8) && pieceCond;
        }

        private bool CanMoveQueen(Square squareFrom, Square squareTo)
        {
            return CanMoveRook(squareFrom,squareTo) || CanMoveBishop(squareFrom,squareTo);
        }

        private bool CanMoveArchBishop(Square squareFrom,Square squareTo)
        {
            return CanMoveBishop(squareFrom,squareTo) || CanMoveKnight(squareFrom,squareTo);
        }

        private bool CanMoveRook(Square squareFrom, Square squareTo)
        {
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();
            int xTo = squareTo.GetPosition().GetLocationX();
            int yTo = squareTo.GetPosition().GetLocationY();
            if (xTo < xFrom) // going up
            {
                for (int x = xFrom - 1; x >= 0; x--)
                {
                    bool isPieceOnTheWay = board.GetSquares()[x, yFrom].GetPiece() != null;
                    bool isOpponentPiece = checkIfOpponentPiece(board.GetSquares()[xFrom, yFrom].GetPiece(),board.GetSquares()[x, yFrom].GetPiece());
                    if (isPieceOnTheWay && !isOpponentPiece && x != xTo)
                    {
                        return false;
                    }
                    if (x == xTo && yFrom == yTo)
                    {
                        if (isOpponentPiece || !isPieceOnTheWay)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else if (xTo > xFrom) //going down
            {
                for (int x = xFrom + 1; x < Utils.NUMBER_OF_ROWS; x++)
                {
                    bool isPieceOnTheWay = board.GetSquares()[x, yFrom].GetPiece() != null;
                    bool isOpponentPiece = checkIfOpponentPiece(board.GetSquares()[xFrom, yFrom].GetPiece(),board.GetSquares()[x, yFrom].GetPiece());
                    if (isPieceOnTheWay && !isOpponentPiece && x != xTo)
                    {
                        return false;
                    }
                    if (x == xTo && yFrom == yTo)
                    {
                        if (isOpponentPiece || !isPieceOnTheWay)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else if (yTo < yFrom) //going left
            {
                for (int y = yFrom - 1; y >= 0; y--)
                {
                    bool isPieceOnTheWay = board.GetSquares()[xFrom, y].GetPiece() != null;
                    bool isOpponentPiece = checkIfOpponentPiece(board.GetSquares()[xFrom, yFrom].GetPiece(), board.GetSquares()[xFrom, y].GetPiece());
                    if (isPieceOnTheWay && !isOpponentPiece && y != yTo)
                    {
                        return false;
                    }
                    if (xFrom == xTo && y == yTo)
                    {
                        if (isOpponentPiece || !isPieceOnTheWay)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else if (yTo > yFrom) //going right
            {
                for (int y = yFrom + 1; y < Utils.NUMBER_OF_COLLUMNS; y++)
                {
                    bool isPieceOnTheWay = board.GetSquares()[xFrom, y].GetPiece() != null;
                    bool isOpponentPiece = checkIfOpponentPiece(board.GetSquares()[xFrom, yFrom].GetPiece(),board.GetSquares()[xFrom, y].GetPiece());
                    if (isPieceOnTheWay && !isOpponentPiece && y != yTo)
                    {
                        return false;
                    }
                    if (xFrom == xTo && y == yTo)
                    {
                        if (isOpponentPiece || !isPieceOnTheWay)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        private bool CanMoveBishop(Square squareFrom, Square squareTo)
        {
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();
            int xTo = squareTo.GetPosition().GetLocationX();
            int yTo = squareTo.GetPosition().GetLocationY();

            if (xTo < xFrom && yTo > yFrom)
            {
                return UpRightDiagonalCheck(xFrom, yFrom, xTo, yTo);
            }
            else if (xTo > xFrom && yTo > yFrom)
            {
                return DownRightDiagonalCheck(xFrom, yFrom, xTo, yTo);
            }
            else if (xTo < xFrom && yTo < yFrom)
            {
                return UpLeftDiagonalCheck(xFrom, yFrom, xTo, yTo);
            }
            else if (xTo > xFrom && yTo < yFrom)
            {
                return DownLeftDiagonalCheck(xFrom, yFrom, xTo, yTo);
            }
            return false;
        }

        private bool DownRightDiagonalCheck(int xFrom, int yFrom, int xTo, int yTo)
        {
            int y = yFrom + 1;
            for (int x = xFrom + 1; x < Utils.NUMBER_OF_ROWS && y< Utils.NUMBER_OF_COLLUMNS; x++) //down right diagonal
            {
                bool isPieceOnTheWay = board.GetSquares()[x, y].GetPiece() != null;
                bool isOpponentPiece = checkIfOpponentPiece(board.GetSquares()[xFrom, yFrom].GetPiece(),board.GetSquares()[x, y].GetPiece());
                if (isPieceOnTheWay && !isOpponentPiece && x != xTo && y != yTo)
                {
                    return false;
                }
                if (x == xTo && y == yTo)
                {
                    if (isOpponentPiece || !isPieceOnTheWay)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                y++;
            }
            return false;
        }

        private bool checkIfOpponentPiece(Piece currentPiece, Piece opponentPiece)
        {
            if (opponentPiece == null)
            {
                return true;
            }
            if (currentPiece.GetPieceType() > 0)
            {
                return opponentPiece.GetPieceType() < 0;
            }
            return opponentPiece.GetPieceType() > 0;
        }

        private bool UpLeftDiagonalCheck(int xFrom, int yFrom, int xTo, int yTo)
        {
            int y = yFrom - 1;
            for (int x = xFrom - 1; x >= 0 && y >=0; x--) //up left diagonal
            {
                bool isPieceOnTheWay = board.GetSquares()[x, y].GetPiece() != null;
                bool isOpponentPiece = checkIfOpponentPiece(board.GetSquares()[xFrom, yFrom].GetPiece(),board.GetSquares()[x, y].GetPiece());
                if (isPieceOnTheWay && !isOpponentPiece && x != xTo && y != yTo)
                {
                    return false;
                }
                if (x == xTo && y == yTo)
                {
                    if (isOpponentPiece || !isPieceOnTheWay)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                y--;
            }
            return false;
        }

        private bool UpRightDiagonalCheck(int xFrom, int yFrom, int xTo, int yTo)
        {
            int y = yFrom + 1;
            for (int x = xFrom - 1; x >= 0 && y < Utils.NUMBER_OF_COLLUMNS; x--) //Up right diagonal
            {
                bool isPieceOnTheWay = board.GetSquares()[x, y].GetPiece() != null;
                bool isOpponentPiece = checkIfOpponentPiece(board.GetSquares()[xFrom, yFrom].GetPiece(),board.GetSquares()[x, y].GetPiece());
                if (isPieceOnTheWay && !isOpponentPiece && x != xTo && y != yTo)
                {
                    return false;
                }
                if (x == xTo && y == yTo)
                {
                    if (isOpponentPiece || !isPieceOnTheWay)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                y++;
            }
            return false;
        }

        private bool DownLeftDiagonalCheck(int xFrom, int yFrom, int xTo, int yTo)
        {
            int y = yFrom - 1;
            for (int x = xFrom + 1; x < Utils.NUMBER_OF_ROWS && y >=0; x++) //down left diagonal
            {
                bool isPieceOnTheWay = board.GetSquares()[x, y].GetPiece() != null;
                bool isOpponentPiece = checkIfOpponentPiece(board.GetSquares()[xFrom, yFrom].GetPiece(),board.GetSquares()[x, y].GetPiece());
                if (isPieceOnTheWay && !isOpponentPiece && x != xTo && y != yTo)
                {
                    return false;
                }
                if (x == xTo && y == yTo)
                {
                    if (isOpponentPiece || !isPieceOnTheWay)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                y--;
            }
            return false;
        }

        private bool CanMoveKnight(Square squareFrom, Square squareTo)
        {
            int xFrom = squareFrom.GetPosition().GetLocationX();
            int yFrom = squareFrom.GetPosition().GetLocationY();
            int xTo = squareTo.GetPosition().GetLocationX();
            int yTo = squareTo.GetPosition().GetLocationY();
            bool pieceCond = squareTo.GetPiece() == null || checkIfOpponentPiece(squareFrom.GetPiece(),squareTo.GetPiece());
            bool cond1 = xTo == xFrom + 2 && yTo == yFrom + 1;
            bool cond2 = xTo == xFrom + 2 && yTo == yFrom - 1;
            bool cond3 = xTo == xFrom - 2 && yTo == yFrom + 1;
            bool cond4 = xTo == xFrom - 2 && yTo == yFrom - 1;
            bool cond5 = xTo == xFrom + 1 && yTo == yFrom + 2;
            bool cond6 = xTo == xFrom + 1 && yTo == yFrom - 2;
            bool cond7 = xTo == xFrom - 1 && yTo == yFrom + 2;
            bool cond8 = xTo == xFrom - 1 && yTo == yFrom - 2;

            return (cond1 || cond2 || cond3 || cond4 || cond5 || cond6 || cond7 || cond8) && pieceCond;

        }
    }
}
