using System.Collections.Generic;
using System.Linq;

namespace GeminiChessServer
{
    class Game
    {
        private Player whitePlayer;
        private Player blackPlayer;

        private List<Move> moveHistory;

        public Game(string whitePlayerName, string blackPlayerName, bool isAi)
        {
            whitePlayer = new Player(whitePlayerName, false, true);
            blackPlayer = new Player(blackPlayerName, isAi, false);
            moveHistory = new List<Move>();
        }

        public void AddMoveToHistory(Move move)
        {
            moveHistory.Add(move);
        }

        public void SetTurn()
        {
            if (whitePlayer.CanMove())
            {
                blackPlayer.SetCanMove(true);
                whitePlayer.SetCanMove(false);
            }
            else
            {
                blackPlayer.SetCanMove(false);
                whitePlayer.SetCanMove(true);
            }
        }

        private Player GetCurentPlayer()
        {
            if (whitePlayer.CanMove())
            {
                return whitePlayer;
            }
            return blackPlayer;

        }

        public Player GetWhitePlayer()
        {
            return whitePlayer;
        }

        public Player GetBlackPlayer()
        {
            return blackPlayer;
        }

        public void SaveMove(Square squareFrom, Square squareTo )
        {
            Move move = new Move(GetCurentPlayer(), squareFrom, squareTo);
            moveHistory.Add(move);
            GetCurentPlayer().AddMove(move);
        }

        public void AddCapture(Piece piece)
        {
            GetCurentPlayer().AddCapturedPiece(piece);
        }

        public void RemovePiece(Piece piece)
        {
            if (whitePlayer.CanMove())
            {
                blackPlayer.RemoveRemainingPiece(piece);
            }
            else
            {
                whitePlayer.RemoveRemainingPiece(piece);
            }
        }

        public bool IsAi()
        {
            return GetCurentPlayer().IsAi();
        }

        public List<Piece> GetAvailablePiecesForCurrentPlayer()
        {
            return GetCurentPlayer().GetRemainingPieces();
        }

        public Move GetLastMove()
        {
            if (moveHistory.Count>0)
            {
                return moveHistory.Last();
            }
            return null;
        }

        public string GetCurrentPlayerName()
        {
            if (whitePlayer.CanMove())
            {
                return "White - " + whitePlayer.GetName();
            }
            return "Black - " + blackPlayer.GetName();
        }
    }
}
