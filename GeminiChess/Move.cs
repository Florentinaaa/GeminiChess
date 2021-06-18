
namespace GeminiChess
{
    class Move
    {
        private Player player;
        private Square squareFrom;
        private Square squareTo;

        public Move(Player player, Square squareFrom, Square squareTo)
        {
            this.player = player;
            this.squareFrom = squareFrom;
            this.squareTo = squareTo;
        }
        public Move(Player player, Piece pieceMoved, Square squareFrom, Square squareTo)
        {
            this.player = player;
            this.squareFrom = squareFrom;
            this.squareTo = squareTo;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public Square GetSquareFrom()
        {
            return squareFrom;
        }

        public Square GetSquareTo()
        {
            return squareTo;
        }
    }
    
}
