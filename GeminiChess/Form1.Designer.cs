namespace GeminiChess
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panelNewGame = new System.Windows.Forms.Panel();
            this.buttonLocalPlay = new System.Windows.Forms.Button();
            this.buttonExitMain = new System.Windows.Forms.Button();
            this.buttonServerPlay = new System.Windows.Forms.Button();
            this.panelLocalPlay = new System.Windows.Forms.Panel();
            this.buttonStartLocalPlay = new System.Windows.Forms.Button();
            this.buttonExitLocalPlay = new System.Windows.Forms.Button();
            this.checkBoxAi = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBlackPlayer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWhitePlayer = new System.Windows.Forms.TextBox();
            this.panelServerPlay = new System.Windows.Forms.Panel();
            this.buttonStartServerPlay = new System.Windows.Forms.Button();
            this.buttonExitServerPlay = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxIpAddressServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxWhitePlayerServer = new System.Windows.Forms.TextBox();
            this.panelCapturedPieces = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelBlackCapturedPieces = new System.Windows.Forms.Label();
            this.labelWhiteCapuredPieces = new System.Windows.Forms.Label();
            this.panelCapturedPiecesBlack = new System.Windows.Forms.Panel();
            this.panelCapturedPiecesWhite = new System.Windows.Forms.Panel();
            this.panelMoves = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelBlackMoves = new System.Windows.Forms.Label();
            this.labelWhiteMoves = new System.Windows.Forms.Label();
            this.listBoxBlackMoves = new System.Windows.Forms.ListBox();
            this.listBoxWhiteMoves = new System.Windows.Forms.ListBox();
            this.panelNewGame.SuspendLayout();
            this.panelLocalPlay.SuspendLayout();
            this.panelServerPlay.SuspendLayout();
            this.panelCapturedPieces.SuspendLayout();
            this.panelMoves.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.Location = new System.Drawing.Point(232, 54);
            this.panelBoard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(600, 443);
            this.panelBoard.TabIndex = 0;
            this.panelBoard.Visible = false;
            // 
            // panelNewGame
            // 
            this.panelNewGame.BackColor = System.Drawing.Color.Transparent;
            this.panelNewGame.Controls.Add(this.buttonLocalPlay);
            this.panelNewGame.Controls.Add(this.buttonExitMain);
            this.panelNewGame.Controls.Add(this.buttonServerPlay);
            this.panelNewGame.Location = new System.Drawing.Point(556, 123);
            this.panelNewGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelNewGame.Name = "panelNewGame";
            this.panelNewGame.Size = new System.Drawing.Size(223, 194);
            this.panelNewGame.TabIndex = 4;
            // 
            // buttonLocalPlay
            // 
            this.buttonLocalPlay.Location = new System.Drawing.Point(31, 16);
            this.buttonLocalPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLocalPlay.Name = "buttonLocalPlay";
            this.buttonLocalPlay.Size = new System.Drawing.Size(163, 47);
            this.buttonLocalPlay.TabIndex = 1;
            this.buttonLocalPlay.Text = "Local Play";
            this.buttonLocalPlay.UseVisualStyleBackColor = true;
            this.buttonLocalPlay.Click += new System.EventHandler(this.buttonLocalPlay_Click);
            // 
            // buttonExitMain
            // 
            this.buttonExitMain.Location = new System.Drawing.Point(31, 124);
            this.buttonExitMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExitMain.Name = "buttonExitMain";
            this.buttonExitMain.Size = new System.Drawing.Size(163, 47);
            this.buttonExitMain.TabIndex = 3;
            this.buttonExitMain.Text = "Exit";
            this.buttonExitMain.UseVisualStyleBackColor = true;
            this.buttonExitMain.Click += new System.EventHandler(this.buttonExitMain_Click);
            // 
            // buttonServerPlay
            // 
            this.buttonServerPlay.Location = new System.Drawing.Point(31, 70);
            this.buttonServerPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonServerPlay.Name = "buttonServerPlay";
            this.buttonServerPlay.Size = new System.Drawing.Size(163, 47);
            this.buttonServerPlay.TabIndex = 2;
            this.buttonServerPlay.Text = "Server Play";
            this.buttonServerPlay.UseVisualStyleBackColor = true;
            this.buttonServerPlay.Click += new System.EventHandler(this.buttonServerPlay_Click);
            // 
            // panelLocalPlay
            // 
            this.panelLocalPlay.Controls.Add(this.buttonStartLocalPlay);
            this.panelLocalPlay.Controls.Add(this.buttonExitLocalPlay);
            this.panelLocalPlay.Controls.Add(this.checkBoxAi);
            this.panelLocalPlay.Controls.Add(this.label2);
            this.panelLocalPlay.Controls.Add(this.textBoxBlackPlayer);
            this.panelLocalPlay.Controls.Add(this.label1);
            this.panelLocalPlay.Controls.Add(this.textBoxWhitePlayer);
            this.panelLocalPlay.Location = new System.Drawing.Point(505, 142);
            this.panelLocalPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelLocalPlay.Name = "panelLocalPlay";
            this.panelLocalPlay.Size = new System.Drawing.Size(323, 162);
            this.panelLocalPlay.TabIndex = 1;
            this.panelLocalPlay.Visible = false;
            // 
            // buttonStartLocalPlay
            // 
            this.buttonStartLocalPlay.Location = new System.Drawing.Point(27, 105);
            this.buttonStartLocalPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStartLocalPlay.Name = "buttonStartLocalPlay";
            this.buttonStartLocalPlay.Size = new System.Drawing.Size(97, 38);
            this.buttonStartLocalPlay.TabIndex = 5;
            this.buttonStartLocalPlay.Text = "Start";
            this.buttonStartLocalPlay.UseVisualStyleBackColor = true;
            this.buttonStartLocalPlay.Click += new System.EventHandler(this.buttonStartLocalPlay_Click);
            // 
            // buttonExitLocalPlay
            // 
            this.buttonExitLocalPlay.Location = new System.Drawing.Point(212, 105);
            this.buttonExitLocalPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExitLocalPlay.Name = "buttonExitLocalPlay";
            this.buttonExitLocalPlay.Size = new System.Drawing.Size(97, 38);
            this.buttonExitLocalPlay.TabIndex = 4;
            this.buttonExitLocalPlay.Text = "Exit";
            this.buttonExitLocalPlay.UseVisualStyleBackColor = true;
            this.buttonExitLocalPlay.Click += new System.EventHandler(this.buttonExitLocalPlay_Click);
            // 
            // checkBoxAi
            // 
            this.checkBoxAi.AutoSize = true;
            this.checkBoxAi.Location = new System.Drawing.Point(261, 53);
            this.checkBoxAi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAi.Name = "checkBoxAi";
            this.checkBoxAi.Size = new System.Drawing.Size(42, 21);
            this.checkBoxAi.TabIndex = 4;
            this.checkBoxAi.Text = "AI";
            this.checkBoxAi.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Black Player";
            // 
            // textBoxBlackPlayer
            // 
            this.textBoxBlackPlayer.Location = new System.Drawing.Point(120, 49);
            this.textBoxBlackPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBlackPlayer.Name = "textBoxBlackPlayer";
            this.textBoxBlackPlayer.Size = new System.Drawing.Size(132, 22);
            this.textBoxBlackPlayer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "White Player";
            // 
            // textBoxWhitePlayer
            // 
            this.textBoxWhitePlayer.Location = new System.Drawing.Point(120, 16);
            this.textBoxWhitePlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxWhitePlayer.Name = "textBoxWhitePlayer";
            this.textBoxWhitePlayer.Size = new System.Drawing.Size(132, 22);
            this.textBoxWhitePlayer.TabIndex = 0;
            // 
            // panelServerPlay
            // 
            this.panelServerPlay.BackColor = System.Drawing.Color.Transparent;
            this.panelServerPlay.Controls.Add(this.buttonStartServerPlay);
            this.panelServerPlay.Controls.Add(this.buttonExitServerPlay);
            this.panelServerPlay.Controls.Add(this.label7);
            this.panelServerPlay.Controls.Add(this.textBoxIpAddressServer);
            this.panelServerPlay.Controls.Add(this.label6);
            this.panelServerPlay.Controls.Add(this.textBoxWhitePlayerServer);
            this.panelServerPlay.Location = new System.Drawing.Point(509, 138);
            this.panelServerPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelServerPlay.Name = "panelServerPlay";
            this.panelServerPlay.Size = new System.Drawing.Size(323, 176);
            this.panelServerPlay.TabIndex = 2;
            this.panelServerPlay.Visible = false;
            // 
            // buttonStartServerPlay
            // 
            this.buttonStartServerPlay.Location = new System.Drawing.Point(27, 111);
            this.buttonStartServerPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStartServerPlay.Name = "buttonStartServerPlay";
            this.buttonStartServerPlay.Size = new System.Drawing.Size(97, 38);
            this.buttonStartServerPlay.TabIndex = 7;
            this.buttonStartServerPlay.Text = "Start";
            this.buttonStartServerPlay.UseVisualStyleBackColor = true;
            this.buttonStartServerPlay.Click += new System.EventHandler(this.buttonStartServerPlay_Click);
            // 
            // buttonExitServerPlay
            // 
            this.buttonExitServerPlay.Location = new System.Drawing.Point(212, 111);
            this.buttonExitServerPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExitServerPlay.Name = "buttonExitServerPlay";
            this.buttonExitServerPlay.Size = new System.Drawing.Size(97, 38);
            this.buttonExitServerPlay.TabIndex = 6;
            this.buttonExitServerPlay.Text = "Exit";
            this.buttonExitServerPlay.UseVisualStyleBackColor = true;
            this.buttonExitServerPlay.Click += new System.EventHandler(this.buttonExitServerPlay_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Server IP";
            // 
            // textBoxIpAddressServer
            // 
            this.textBoxIpAddressServer.Location = new System.Drawing.Point(120, 52);
            this.textBoxIpAddressServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxIpAddressServer.Name = "textBoxIpAddressServer";
            this.textBoxIpAddressServer.Size = new System.Drawing.Size(132, 22);
            this.textBoxIpAddressServer.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "White Player";
            // 
            // textBoxWhitePlayerServer
            // 
            this.textBoxWhitePlayerServer.Location = new System.Drawing.Point(120, 7);
            this.textBoxWhitePlayerServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxWhitePlayerServer.Name = "textBoxWhitePlayerServer";
            this.textBoxWhitePlayerServer.Size = new System.Drawing.Size(132, 22);
            this.textBoxWhitePlayerServer.TabIndex = 2;
            // 
            // panelCapturedPieces
            // 
            this.panelCapturedPieces.Controls.Add(this.label5);
            this.panelCapturedPieces.Controls.Add(this.labelBlackCapturedPieces);
            this.panelCapturedPieces.Controls.Add(this.labelWhiteCapuredPieces);
            this.panelCapturedPieces.Controls.Add(this.panelCapturedPiecesBlack);
            this.panelCapturedPieces.Controls.Add(this.panelCapturedPiecesWhite);
            this.panelCapturedPieces.Location = new System.Drawing.Point(16, 543);
            this.panelCapturedPieces.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCapturedPieces.Name = "panelCapturedPieces";
            this.panelCapturedPieces.Size = new System.Drawing.Size(1320, 256);
            this.panelCapturedPieces.TabIndex = 3;
            this.panelCapturedPieces.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(632, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Captured Pieces";
            // 
            // labelBlackCapturedPieces
            // 
            this.labelBlackCapturedPieces.AutoSize = true;
            this.labelBlackCapturedPieces.Location = new System.Drawing.Point(28, 146);
            this.labelBlackCapturedPieces.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBlackCapturedPieces.Name = "labelBlackCapturedPieces";
            this.labelBlackCapturedPieces.Size = new System.Drawing.Size(55, 17);
            this.labelBlackCapturedPieces.TabIndex = 3;
            this.labelBlackCapturedPieces.Text = "Black - ";
            // 
            // labelWhiteCapuredPieces
            // 
            this.labelWhiteCapuredPieces.AutoSize = true;
            this.labelWhiteCapuredPieces.Location = new System.Drawing.Point(28, 43);
            this.labelWhiteCapuredPieces.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWhiteCapuredPieces.Name = "labelWhiteCapuredPieces";
            this.labelWhiteCapuredPieces.Size = new System.Drawing.Size(57, 17);
            this.labelWhiteCapuredPieces.TabIndex = 2;
            this.labelWhiteCapuredPieces.Text = "White - ";
            // 
            // panelCapturedPiecesBlack
            // 
            this.panelCapturedPiecesBlack.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelCapturedPiecesBlack.Location = new System.Drawing.Point(27, 166);
            this.panelCapturedPiecesBlack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCapturedPiecesBlack.Name = "panelCapturedPiecesBlack";
            this.panelCapturedPiecesBlack.Size = new System.Drawing.Size(1271, 63);
            this.panelCapturedPiecesBlack.TabIndex = 1;
            // 
            // panelCapturedPiecesWhite
            // 
            this.panelCapturedPiecesWhite.BackColor = System.Drawing.SystemColors.Info;
            this.panelCapturedPiecesWhite.Location = new System.Drawing.Point(27, 63);
            this.panelCapturedPiecesWhite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCapturedPiecesWhite.Name = "panelCapturedPiecesWhite";
            this.panelCapturedPiecesWhite.Size = new System.Drawing.Size(1271, 63);
            this.panelCapturedPiecesWhite.TabIndex = 0;
            // 
            // panelMoves
            // 
            this.panelMoves.Controls.Add(this.label4);
            this.panelMoves.Controls.Add(this.labelBlackMoves);
            this.panelMoves.Controls.Add(this.labelWhiteMoves);
            this.panelMoves.Controls.Add(this.listBoxBlackMoves);
            this.panelMoves.Controls.Add(this.listBoxWhiteMoves);
            this.panelMoves.Location = new System.Drawing.Point(1016, 41);
            this.panelMoves.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMoves.Name = "panelMoves";
            this.panelMoves.Size = new System.Drawing.Size(320, 473);
            this.panelMoves.TabIndex = 4;
            this.panelMoves.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Moves";
            // 
            // labelBlackMoves
            // 
            this.labelBlackMoves.AutoSize = true;
            this.labelBlackMoves.Location = new System.Drawing.Point(175, 44);
            this.labelBlackMoves.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBlackMoves.Name = "labelBlackMoves";
            this.labelBlackMoves.Size = new System.Drawing.Size(55, 17);
            this.labelBlackMoves.TabIndex = 6;
            this.labelBlackMoves.Text = "Black - ";
            // 
            // labelWhiteMoves
            // 
            this.labelWhiteMoves.AutoSize = true;
            this.labelWhiteMoves.Location = new System.Drawing.Point(4, 44);
            this.labelWhiteMoves.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWhiteMoves.Name = "labelWhiteMoves";
            this.labelWhiteMoves.Size = new System.Drawing.Size(57, 17);
            this.labelWhiteMoves.TabIndex = 5;
            this.labelWhiteMoves.Text = "White - ";
            // 
            // listBoxBlackMoves
            // 
            this.listBoxBlackMoves.FormattingEnabled = true;
            this.listBoxBlackMoves.ItemHeight = 16;
            this.listBoxBlackMoves.Location = new System.Drawing.Point(179, 64);
            this.listBoxBlackMoves.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxBlackMoves.Name = "listBoxBlackMoves";
            this.listBoxBlackMoves.Size = new System.Drawing.Size(136, 388);
            this.listBoxBlackMoves.TabIndex = 1;
            // 
            // listBoxWhiteMoves
            // 
            this.listBoxWhiteMoves.FormattingEnabled = true;
            this.listBoxWhiteMoves.ItemHeight = 16;
            this.listBoxWhiteMoves.Location = new System.Drawing.Point(4, 64);
            this.listBoxWhiteMoves.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxWhiteMoves.Name = "listBoxWhiteMoves";
            this.listBoxWhiteMoves.Size = new System.Drawing.Size(136, 388);
            this.listBoxWhiteMoves.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1357, 814);
            this.Controls.Add(this.panelNewGame);
            this.Controls.Add(this.panelMoves);
            this.Controls.Add(this.panelCapturedPieces);
            this.Controls.Add(this.panelServerPlay);
            this.Controls.Add(this.panelLocalPlay);
            this.Controls.Add(this.panelBoard);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Gemini Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelNewGame.ResumeLayout(false);
            this.panelLocalPlay.ResumeLayout(false);
            this.panelLocalPlay.PerformLayout();
            this.panelServerPlay.ResumeLayout(false);
            this.panelServerPlay.PerformLayout();
            this.panelCapturedPieces.ResumeLayout(false);
            this.panelCapturedPieces.PerformLayout();
            this.panelMoves.ResumeLayout(false);
            this.panelMoves.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Panel panelNewGame;
        private System.Windows.Forms.Button buttonLocalPlay;
        private System.Windows.Forms.Button buttonExitMain;
        private System.Windows.Forms.Button buttonServerPlay;
        private System.Windows.Forms.Panel panelLocalPlay;
        private System.Windows.Forms.Panel panelServerPlay;
        private System.Windows.Forms.CheckBox checkBoxAi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBlackPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWhitePlayer;
        private System.Windows.Forms.Button buttonStartLocalPlay;
        private System.Windows.Forms.Button buttonExitLocalPlay;
        private System.Windows.Forms.Panel panelCapturedPieces;
        private System.Windows.Forms.Panel panelMoves;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelBlackMoves;
        private System.Windows.Forms.Label labelWhiteMoves;
        private System.Windows.Forms.ListBox listBoxBlackMoves;
        private System.Windows.Forms.ListBox listBoxWhiteMoves;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelBlackCapturedPieces;
        private System.Windows.Forms.Label labelWhiteCapuredPieces;
        private System.Windows.Forms.Panel panelCapturedPiecesBlack;
        private System.Windows.Forms.Panel panelCapturedPiecesWhite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxWhitePlayerServer;
        private System.Windows.Forms.Button buttonStartServerPlay;
        private System.Windows.Forms.Button buttonExitServerPlay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxIpAddressServer;
    }
}

