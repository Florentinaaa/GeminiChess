using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeminiChessServer
{
    public partial class Form1 : Form
    {
        private bool isFirstClicked = true;
        private PictureBox pictureBoxSource;
        private PictureBox[,] uIBoard;
        private GameController gameController;

        private bool onlineMode;
        private bool stopFlag;
        public Form1()
        {
            InitializeComponent();
            onlineMode = false;
            stopFlag = true;
        }
        private void pictureBox_Click(object sender, System.EventArgs e)
        {
            PictureBox currentPicture = (PictureBox)sender;
            if(isFirstClicked)
            {
                pictureBoxSource = currentPicture;
                ShowPosibleMoves();
                isFirstClicked = false; 
            }
            else
            {
                isFirstClicked = true;
                string[] coordinatesFrom = pictureBoxSource.Tag.ToString().Split(',');
                string[] coordinatesTo = currentPicture.Tag.ToString().Split(',');
                int xFrom = int.Parse(coordinatesFrom[0]);
                int yFrom = int.Parse(coordinatesFrom[1]);
                int xTo = int.Parse(coordinatesTo[0]);
                int yTo = int.Parse(coordinatesTo[1]);
                try
                {
                    gameController.PerformMove(xFrom, yFrom, xTo, yTo,onlineMode);
                    WriteMoveOnListBox();
                    ShowCapturedPiece();
                    refreshUIBoard();

                    if (checkBoxAi.Checked)
                    {
                        gameController.MoveIfAi();
                        WriteMoveOnListBox();
                        ShowCapturedPiece();
                        refreshUIBoard();
                    }

                    if (onlineMode && stopFlag)
                    {
                        labelWhiteCapuredPieces.Text += gameController.GetCurrentPlayerName();
                        labelWhiteMoves.Text += gameController.GetCurrentPlayerName();
                        stopFlag = false;
                    }
                }
                catch (Exception exception)
                {
                    refreshUIBoard();
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void ShowPosibleMoves()
        {
            string[] coordinatesFrom = pictureBoxSource.Tag.ToString().Split(',');
            int xFrom = int.Parse(coordinatesFrom[0]);
            int yFrom = int.Parse(coordinatesFrom[1]);
            foreach (var move in gameController.GetAvailableMoves(xFrom, yFrom))
            {
                uIBoard[move.GetX(), move.GetY()].BackColor = Color.Red;
            }
        }

        private void ShowCapturedPiece()
        {
            string playerName = gameController.GetCurrentPlayerName();
            string capturedPiecePath = gameController.GetLastCapturePieceImagePath();

            PictureBox picture = new PictureBox();
            picture.Width = 45;
            picture.Height = 45;

            if (!string.IsNullOrEmpty(capturedPiecePath))
            {
                picture.Image = new Bitmap(capturedPiecePath);
                if (labelWhiteCapuredPieces.Text.Equals(playerName))
                {
                    picture.Location = new Point(45 * panelCapturedPiecesBlack.Controls.Count, 0);
                    panelCapturedPiecesBlack.Controls.Add(picture);
                }
                else
                {
                    picture.Location = new Point(45 * panelCapturedPiecesWhite.Controls.Count, 0);
                    panelCapturedPiecesWhite.Controls.Add(picture);
                }
            }
        }

        private void WriteMoveOnListBox()
        {
            string moveString = gameController.GetLastMove();
            if (!string.IsNullOrEmpty(moveString))
            {
                string[] splittedString = moveString.Split(',');
                string playerName = splittedString[0];
                string moveFrom = splittedString[1];
                string moveTo = splittedString[2];
                if (labelWhiteMoves.Text.Equals("White - " + playerName))
                {
                    listBoxWhiteMoves.Items.Add(moveFrom + "->" + moveTo);
                }
                else
                {
                    listBoxBlackMoves.Items.Add(moveFrom + "->" + moveTo);
                }
            }
        }

        private void refreshUIBoard()
        {
            for (int i = 0; i < Utils.NUMBER_OF_ROWS; i++)
            {
                for (int j = 0; j < Utils.NUMBER_OF_COLLUMNS; j++)
                {
                    string imagePath = gameController.GetPieceImagePath(i, j);
                    uIBoard[i, j].BackColor = gameController.GetSquareColor(i, j);
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        uIBoard[i,j].Image = new Bitmap(imagePath);
                    }
                    else
                    {
                        uIBoard[i, j].Image = null;
                    }
                }
            }
        }

        private void buildUIBoard()
        { 
            int x = 0, y = 0;
            for (int i = 0; i < Utils.NUMBER_OF_ROWS; i++)
            {
                for (int j = 0; j < Utils.NUMBER_OF_COLLUMNS; j++)
                {
                    PictureBox picture = new PictureBox();
                    picture.Width = 45;
                    picture.Height = 45;
                    picture.Location = new Point(x, y);
                    x += 45;
                    picture.BackColor = gameController.GetSquareColor(i, j);
                    string imagePath = gameController.GetPieceImagePath(i, j);
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        picture.Image = new Bitmap(imagePath);
                    }
                    else
                    {
                        picture.Image = null;
                    }
                    
                    picture.Tag = i + "," + j;
                    uIBoard[i, j] = picture;
                    picture.Click += new EventHandler(pictureBox_Click);
                    panelBoard.Controls.Add(picture);
                }
                x = 0;
                y += 45;
            }
            panelBoard.Refresh();
        }

        private void buttonLocalPlay_Click(object sender, EventArgs e)
        {
            panelLocalPlay.Visible = true;
            panelNewGame.Visible = false;
        }

        private void buttonExitMain_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonServerPlay_Click(object sender, EventArgs e)
        {
            panelServerPlay.Visible = true;
            panelNewGame.Visible = false;
        }

        private void buttonExitLocalPlay_Click(object sender, EventArgs e)
        {
            panelLocalPlay.Visible = false;
            panelNewGame.Visible = true;
        }

        private void buttonExitServerPlay_Click(object sender, EventArgs e)
        {
            panelServerPlay.Visible = false;
            panelNewGame.Visible = true;
        }

        private void buttonStartLocalPlay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBlackPlayer.Text) && string.IsNullOrEmpty(textBoxWhitePlayer.Text))
            {
                MessageBox.Show("Please fill the name inside the textbox!");
            }
            else
            {
                uIBoard = new PictureBox[Utils.NUMBER_OF_ROWS, Utils.NUMBER_OF_COLLUMNS];
                gameController = new GameController(textBoxWhitePlayer.Text, textBoxBlackPlayer.Text, checkBoxAi.Checked);

                gameController.BuildBoard();
                buildUIBoard();

                labelBlackCapturedPieces.Text += textBoxBlackPlayer.Text;
                labelBlackMoves.Text += textBoxBlackPlayer.Text;
                labelWhiteCapuredPieces.Text += textBoxWhitePlayer.Text;
                labelWhiteMoves.Text += textBoxWhitePlayer.Text;

                panelLocalPlay.Visible = false;
                panelBoard.Visible = true;
                panelCapturedPieces.Visible = true;
                panelMoves.Visible = true;
            }
        }

        private void buttonStartServerPlay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBlackPlayerServer.Text))
            {
                MessageBox.Show("Please fill the name and ip inside the textbox!");
            }
            else
            {
                try
                {
                    uIBoard = new PictureBox[Utils.NUMBER_OF_ROWS, Utils.NUMBER_OF_COLLUMNS];
                    gameController = new GameController(textBoxBlackPlayerServer.Text);
                    gameController.BuildBoard();
                    buildUIBoard();
                    gameController.StartServer();
                    onlineMode = true;

                    labelBlackCapturedPieces.Text += textBoxBlackPlayerServer.Text;
                    labelBlackMoves.Text += textBoxBlackPlayerServer.Text;

                    panelServerPlay.Visible = false;
                    panelBoard.Visible = true;
                    panelCapturedPieces.Visible = true;
                    panelMoves.Visible = true;

                    labelServerIp.Visible = true;
                    labelServerIp.Text += gameController.GetServerIp();
                    buttonExitGame.Visible = true;

                    StartTimer();
                }
                catch (SocketException)
                {
                    MessageBox.Show("Cannot start the server!");
                }
               
            }
        }

        private void StartTimer()
        {
            System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 3000;
            myTimer.Start();
        }

        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            refreshUIBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelBoard.Visible = true;
        }

        private void buttonExitGame_Click(object sender, EventArgs e)
        {
            gameController.Disconnect();
            Close();
        }
    }
}
