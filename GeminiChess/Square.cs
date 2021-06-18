using System.Drawing;


namespace GeminiChess
{
    class Square
    {
        private Color color;
        private Position position;
        private Piece piece;
        private Board board;


        public Square(Board board)
        {
            this.board = board;
        }

        public Square(Square square)
        {
            color = square.GetColor();
            position = square.GetPosition();
            piece = square.GetPiece();
        }
        public Color GetColor()
        {
            return color;
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }
        public Position GetPosition()
        {
            return position;
        }

        public void SetPosition(Position position)
        {
            this.position = position;
        }
        public Piece GetPiece()
        {
            return piece;
        }

        public void SetPiece(Piece piece)
        {
            this.piece = piece;
        }

        public Board GetBoard()
        {
            return board;
        }

    }
}
