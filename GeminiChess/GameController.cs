using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace GeminiChess
{
    class GameController
    {
        private Game game;

        private Board board;

        private MoveValidator moveValidator;

        private MoveGenerator moveGenerator;

        private string capturedImagePath;

        private string serverIp;

        private Client client;

        public GameController(string whitePlayerName, string blackPlayerName, bool isAi)
        {
            game = new Game(whitePlayerName, blackPlayerName, isAi);
            board = new Board();
            moveValidator = new MoveValidator(board);
            moveGenerator = new MoveGenerator(board, moveValidator);
        }

        public GameController(string whitePlayerName, string serverIp)
        {
            game = new Game(whitePlayerName, "", false);
            board = new Board();
            moveValidator = new MoveValidator(board);
            moveGenerator = new MoveGenerator(board, moveValidator);
            this.serverIp = serverIp;
        }

        public void BuildBoard()
        {
            board.BuildInitialBoard(game.GetWhitePlayer(), game.GetBlackPlayer());
        }

        public Color GetSquareColor(int i, int j)
        {
            return board.GetSquares()[i, j].GetColor();
        }

        public string GetPieceImagePath(int i, int j)
        {
            Piece piece = board.GetSquares()[i, j].GetPiece();
            if (piece != null)
            {
                return piece.GetImagePath();
            }
            return "";
        }

        public void PerformMove(int iFrom, int jFrom, int iTo, int jTo, bool canSendMove)
        {
            Square squareFrom = board.GetSquares()[iFrom, jFrom];
            CanMove(squareFrom.GetPiece().GetPlayer());
            Square squareTo = board.GetSquares()[iTo, jTo];
            if (moveValidator.CanMove(squareFrom, squareTo))
            {
                ProcessCapture(squareTo);
                squareTo.SetPiece(squareFrom.GetPiece());
                squareTo.GetPiece().SetSquare(squareTo);
                squareFrom.SetPiece(null);
                game.SaveMove(squareFrom, squareTo);
                game.SetTurn();
                if (canSendMove)
                {
                    SendMoveToServer(iFrom, jFrom, iTo, jTo);
                }
            }
            else
            {
                throw new Exception("Invalid Move!");
            }
        }

        private void SendMoveToServer(int iFrom, int jFrom, int iTo, int jTo)
        {
                string response = iFrom + "," + jFrom + "," + iTo + "," + jTo;
                client.sendResponseToServer(response);
        }

        public void MoveIfAi()
        {
            if (game.IsAi())
            {
                AiMovePicker aiMovePicker = new AiMovePicker(moveGenerator);
                aiMovePicker.PickMove(game.GetAvailablePiecesForCurrentPlayer());
                PerformMove(aiMovePicker.GetMoveFrom().GetX(), aiMovePicker.GetMoveFrom().GetY(),
                    aiMovePicker.GetMoveTo().GetX(), aiMovePicker.GetMoveTo().GetY(), false);
            }
        }

        private void ProcessCapture(Square squareTo)
        {
            if (squareTo.GetPiece() != null)
            {
                game.AddCapture(squareTo.GetPiece());
                game.RemovePiece(squareTo.GetPiece());
                capturedImagePath = squareTo.GetPiece().GetImagePath();
            }
            else
            {
                capturedImagePath = "";
            }
        }

        public void ConnectToServer()
        {
            client = new Client();
            client.Connect(serverIp);
            client.sendResponseToServer(game.GetCurrentPlayerName());
            string serverName = client.receiveResponseFromServer();
            if (serverName != null)
            {
                game.GetBlackPlayer().SetName(serverName);
            }
            var thread = new Thread(() => Run());
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Run()
        {
            while (true)
            {
                ReceiveMoveFromServer();
            }

        }

        public void ReceiveMoveFromServer()
        {
            string move = client.receiveResponseFromServer();
            if (!string.IsNullOrEmpty(move))
            {
                string[] indexes = move.Split(',');
                PerformMove(int.Parse(indexes[0]), int.Parse(indexes[1]),
                    int.Parse(indexes[2]), int.Parse(indexes[3]),false);
            }
            else
            {
                throw new Exception("Move not provided by the server");
            }
        }

        public string GetLastCapturePieceImagePath()
        {
            return capturedImagePath;
        }

        public string GetLastMove()
        {
            Move move = game.GetLastMove();
            if (move!= null)
            {
                string moveString = move.GetPlayer().GetName();
                moveString += "," + move.GetSquareFrom().GetPosition().GetPositionX()
                                  + move.GetSquareFrom().GetPosition().GetPositionY();
                moveString += "," + move.GetSquareTo().GetPosition().GetPositionX()
                                  + move.GetSquareTo().GetPosition().GetPositionY();
                return moveString;
            }
          return "";
        }

        private void CanMove(Player player)
        {
            if (!player.CanMove())
            {
                throw new Exception("It's not your turn!");
            }
        }

        public string GetCurrentPlayerName()
        {
            return game.GetCurrentPlayerName();
        }

        public List<MatrixIndex> GetAvailableMoves(int x, int y)
        {
            Square squareFrom = board.GetSquares()[x, y];
            return moveGenerator.GenerateMoves(squareFrom);
        }
    }
}
