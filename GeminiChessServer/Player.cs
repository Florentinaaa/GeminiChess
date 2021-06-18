using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiChessServer
{
    class Player
    {
        private string name;
        private bool canMove;
        private bool isInCheck;
        private bool isInCheckMate;
        private bool isAi;
        private List<Move> moves;
        private List<Piece> capturedPieces;
        private List<Piece> remainingPieces;

        public Player(string name, bool isAi, bool canMove) {
            this.name = name;
            this.isAi = isAi;
            this.canMove = canMove;
            moves = new List<Move>();
            capturedPieces = new List<Piece>();
            remainingPieces = new List<Piece>();
        }

        public string GetName() {
            return name;
        }

        public bool CanMove()
        {
            return canMove;
        }

        public void SetCanMove(bool canMove)
        {
            this.canMove = canMove;
        }

        public bool IsInCheck()
        {
            return isInCheck;
        }

        public bool IsAi()
        {
            return isAi;
        }

        public void SetIsInCheck(bool isInCheck)
        {
            this.isInCheck = isInCheck;
        }

        public bool IsInCheckMate()
        {
            return isInCheckMate;
        }

        public void SetIsInCheckMate(bool isInCheckMate)
        {
            this.isInCheckMate = isInCheckMate;
        }

        public void AddMove(Move move) {
            moves.Add(move);
        }

        public void AddCapturedPiece(Piece piece)
        {
            capturedPieces.Add(piece);
        }

        public void AddRemainingPiece(Piece piece)
        {
            remainingPieces.Add(piece);
        }

        public List<Piece> GetRemainingPieces()
        {
            return remainingPieces;
        }

        public void RemoveRemainingPiece(Piece piece)
        {
            remainingPieces.Remove(piece);
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
