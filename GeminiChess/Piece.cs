
namespace GeminiChess
{
    class Piece
    {
        private PieceType type;
        private string imagePath;
        private Player player;
        private Square square;

        public Piece(PieceType type, string imagePath, Player player, Square square)
        {
            this.type = type;
            this.imagePath = imagePath;
            this.player = player;
            this.square = square;
        }

        public PieceType GetPieceType()
        {
            return type;
        }

        public string GetImagePath()
        {
            return imagePath;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public void SetSquare(Square square)
        {
            this.square = square;
        }

        public Square GetSquare()
        {
            return square;
        }
    }
}
