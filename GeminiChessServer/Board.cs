using System.Drawing;
using System.IO;


namespace GeminiChessServer
{
    class Board
    {
        private Square[,] squares;

        public Board() {
            squares = new Square[Utils.NUMBER_OF_ROWS, Utils.NUMBER_OF_COLLUMNS];
        }

        public void BuildInitialBoard(Player whitePlayer, Player blackPlayer) {

            buildBlackPlayerSideBoard(blackPlayer);
            buildWhitePlayerSideBoard(whitePlayer);
            buildEmptySquares();
        }

        private void buildEmptySquares()
        {
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < Utils.NUMBER_OF_COLLUMNS; j++)
                {
                    Square square = new Square(this);
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            square.SetColor(Utils.WHITE);
                        else
                        {
                            square.SetColor(Utils.BLACK);
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {

                            square.SetColor(Utils.BLACK);
                        }
                        else
                        {
                            square.SetColor(Utils.WHITE);
                        }
                    }
                    square.SetPosition(new Position(Utils.xCoordinates[j], Utils.yCoordinates[i],i,j));
                    squares[i, j] = square;
                }
            }
        }

        private void buildBlackPlayerSideBoard(Player blackPlayer) {
            addPieceToSquares(blackPlayer, "black_rook.png", PieceType.BlackRook, Utils.WHITE, 0, 0);
            addPieceToSquares(blackPlayer, "black_knight.PNG", PieceType.BlackKnight, Utils.BLACK, 1, 0);
            addPieceToSquares(blackPlayer, "black_bishop.PNG", PieceType.BlackBishop, Utils.WHITE, 2, 0);
            addPieceToSquares(blackPlayer, "black_archbishop.PNG", PieceType.BlackArchBishop, Utils.BLACK, 3, 0);
            addPieceToSquares(blackPlayer, "black_queen.PNG", PieceType.BlackQueen, Utils.WHITE, 4, 0);
            addPieceToSquares(blackPlayer, "black_king.PNG", PieceType.BlackKing, Utils.BLACK, 5, 0);
            addPieceToSquares(blackPlayer, "black_archbishop.PNG", PieceType.BlackArchBishop, Utils.WHITE, 6, 0);
            addPieceToSquares(blackPlayer, "black_bishop.PNG", PieceType.BlackBishop, Utils.BLACK, 7, 0);
            addPieceToSquares(blackPlayer, "black_knight.PNG", PieceType.BlackKnight, Utils.WHITE, 8, 0);
            addPieceToSquares(blackPlayer, "black_rook.png", PieceType.BlackRook, Utils.BLACK, 9, 0);
            addBlackPawns(blackPlayer);
        }

        private void buildWhitePlayerSideBoard(Player whitePlayer)
        {
            addPieceToSquares(whitePlayer, "white_rook.png", PieceType.WhiteRook, Utils.BLACK, 0, 7);
            addPieceToSquares(whitePlayer, "white_knight.PNG", PieceType.WhiteKnight, Utils.WHITE, 1, 7);
            addPieceToSquares(whitePlayer, "white_bishop.PNG", PieceType.WhiteBishop, Utils.BLACK, 2, 7);
            addPieceToSquares(whitePlayer, "white_archbishop.PNG", PieceType.WhiteArchBishop, Utils.WHITE, 3, 7);
            addPieceToSquares(whitePlayer, "white_queen.PNG", PieceType.WhiteQueen, Utils.BLACK, 4, 7);
            addPieceToSquares(whitePlayer, "white_king.PNG", PieceType.WhiteKing, Utils.WHITE, 5, 7);
            addPieceToSquares(whitePlayer, "white_archbishop.PNG", PieceType.WhiteArchBishop, Utils.BLACK, 6, 7);
            addPieceToSquares(whitePlayer, "white_bishop.PNG", PieceType.WhiteBishop, Utils.WHITE, 7, 7);
            addPieceToSquares(whitePlayer, "white_knight.PNG", PieceType.WhiteKnight, Utils.BLACK, 8, 7);
            addPieceToSquares(whitePlayer, "white_rook.png", PieceType.WhiteRook, Utils.WHITE, 9, 7);
            addWhitePawns(whitePlayer);
        }

        private void addWhitePawns(Player whitePlayer)
        {
            for (int k = 0; k < Utils.NUMBER_OF_COLLUMNS; k++)
            {
                if (k%2 == 0)
                {
                    addPieceToSquares(whitePlayer, "white_pawn.PNG", PieceType.WhitePawn, Utils.WHITE,k,6);
                }
                else
                {
                    addPieceToSquares(whitePlayer, "white_pawn.PNG", PieceType.WhitePawn, Utils.BLACK, k, 6);
                }
                
            }
        }

        private void addBlackPawns(Player blackPlayer)
        {
            for (int k = 0; k < Utils.NUMBER_OF_COLLUMNS; k++)
            {
                if (k % 2 == 0)
                {
                    addPieceToSquares(blackPlayer, "black_pawn.PNG", PieceType.BlackPawn, Utils.BLACK, k, 1);
                }
                else
                {
                    addPieceToSquares(blackPlayer, "black_pawn.PNG", PieceType.BlackPawn, Utils.WHITE, k, 1);
                }

            }
        }

        private void addPieceToSquares(Player player, string imageName, PieceType pieceType, Color color, int i, int j)
        {
            Square squareLeftRook = new Square(this);
            Piece piece = new Piece(pieceType, 
                Directory.GetCurrentDirectory() + "\\piece_image\\"+ imageName,
                player,squareLeftRook);
            player.AddRemainingPiece(piece);
            squareLeftRook.SetColor(color);
            squareLeftRook.SetPiece(piece);
            squareLeftRook.SetPosition(new Position(Utils.xCoordinates[i], Utils.yCoordinates[j],j,i));
            squares[j, i] = squareLeftRook;
        }

        public Square[,] GetSquares()
        {
            return squares;
        }

       
    }
}
