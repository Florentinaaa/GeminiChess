using System;
using System.Collections.Generic;

namespace GeminiChessServer
{
    class AiMovePicker
    {
        private MoveGenerator moveGenerator;

        private MatrixIndex moveFrom;
        private MatrixIndex moveTo;

        public AiMovePicker(MoveGenerator moveGenerator)
        {
            this.moveGenerator = moveGenerator;
        }

        public void PickMove(List<Piece> availablePieces)
        {
            Piece piece = PickRandomPiece(availablePieces);
            moveFrom = new MatrixIndex(piece.GetSquare().GetPosition().GetLocationX(),
                piece.GetSquare().GetPosition().GetLocationY());
            moveTo = PickRandomMove(moveGenerator.GenerateMoves(piece.GetSquare()));
        }

        private MatrixIndex PickRandomMove(List<MatrixIndex> moves)
        {
            Random random = new Random();
            int randomIndex = random.Next(moves.Count - 1);
            return moves[randomIndex];
        }

        private Piece PickRandomPiece(List<Piece> availablePieces)
        {
            Random random = new Random();
            int randomIndex = random.Next(availablePieces.Count - 1);
            while (moveGenerator.GenerateMoves(availablePieces[randomIndex].GetSquare()).Count == 0)
            {
                randomIndex = random.Next(availablePieces.Count - 1);
            }
            return availablePieces[randomIndex];
        }

        public MatrixIndex GetMoveFrom()
        {
            return moveFrom;
        }

        public MatrixIndex GetMoveTo()
        {
            return moveTo;
        }
    }
}
