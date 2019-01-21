namespace gomoku_project
{
    partial class Gomoku
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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPvC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiComStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYouStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCvC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPvP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pnlAI = new System.Windows.Forms.Panel();
            this.lbNodes = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pbTurn = new System.Windows.Forms.PictureBox();
            this.btnAIPlay = new System.Windows.Forms.Button();
            this.lbTurn = new System.Windows.Forms.Label();
            this.cbDepth = new System.Windows.Forms.ComboBox();
            this.lbDepth = new System.Windows.Forms.Label();
            this.msMenu.SuspendLayout();
            this.pnlAI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).BeginInit();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiHelp});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(505, 24);
            this.msMenu.TabIndex = 1;
            this.msMenu.Text = "msMenu";
            // 
            // tsmiNew
            // 
            this.tsmiNew.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tsmiNew.Checked = true;
            this.tsmiNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPvC,
            this.tsmiCvC,
            this.tsmiPvP});
            this.tsmiNew.ForeColor = System.Drawing.Color.Black;
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(43, 20);
            this.tsmiNew.Text = "New";
            // 
            // tsmiPvC
            // 
            this.tsmiPvC.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tsmiPvC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiComStart,
            this.tsmiYouStart});
            this.tsmiPvC.Name = "tsmiPvC";
            this.tsmiPvC.Size = new System.Drawing.Size(96, 22);
            this.tsmiPvC.Text = "PvC";
            // 
            // tsmiComStart
            // 
            this.tsmiComStart.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tsmiComStart.Name = "tsmiComStart";
            this.tsmiComStart.Size = new System.Drawing.Size(126, 22);
            this.tsmiComStart.Text = "Com start";
            this.tsmiComStart.Click += new System.EventHandler(this.tsmiComStart_Click);
            // 
            // tsmiYouStart
            // 
            this.tsmiYouStart.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tsmiYouStart.Name = "tsmiYouStart";
            this.tsmiYouStart.Size = new System.Drawing.Size(126, 22);
            this.tsmiYouStart.Text = "You Start";
            this.tsmiYouStart.Click += new System.EventHandler(this.tsmiYouStart_Click);
            // 
            // tsmiCvC
            // 
            this.tsmiCvC.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tsmiCvC.Name = "tsmiCvC";
            this.tsmiCvC.Size = new System.Drawing.Size(96, 22);
            this.tsmiCvC.Text = "CvC";
            this.tsmiCvC.Click += new System.EventHandler(this.tsmiCvC_Click);
            // 
            // tsmiPvP
            // 
            this.tsmiPvP.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tsmiPvP.Name = "tsmiPvP";
            this.tsmiPvP.Size = new System.Drawing.Size(96, 22);
            this.tsmiPvP.Text = "PvP";
            this.tsmiPvP.Click += new System.EventHandler(this.tsmiPvP_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tsmiHelp.Checked = true;
            this.tsmiHelp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "Help";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlBoard.Location = new System.Drawing.Point(2, 24);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(501, 501);
            this.pnlBoard.TabIndex = 2;
            this.pnlBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBoard_Paint);
            this.pnlBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseClick);
            // 
            // pnlAI
            // 
            this.pnlAI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlAI.Controls.Add(this.lbNodes);
            this.pnlAI.Controls.Add(this.lbStatus);
            this.pnlAI.Controls.Add(this.pbTurn);
            this.pnlAI.Controls.Add(this.btnAIPlay);
            this.pnlAI.Controls.Add(this.lbTurn);
            this.pnlAI.Location = new System.Drawing.Point(0, 526);
            this.pnlAI.Name = "pnlAI";
            this.pnlAI.Size = new System.Drawing.Size(505, 30);
            this.pnlAI.TabIndex = 3;
            // 
            // lbNodes
            // 
            this.lbNodes.AutoSize = true;
            this.lbNodes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNodes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbNodes.Location = new System.Drawing.Point(3, 3);
            this.lbNodes.Name = "lbNodes";
            this.lbNodes.Size = new System.Drawing.Size(0, 21);
            this.lbNodes.TabIndex = 3;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbStatus.Location = new System.Drawing.Point(320, 3);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 21);
            this.lbStatus.TabIndex = 3;
            // 
            // pbTurn
            // 
            this.pbTurn.Location = new System.Drawing.Point(463, 0);
            this.pbTurn.Name = "pbTurn";
            this.pbTurn.Size = new System.Drawing.Size(30, 30);
            this.pbTurn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTurn.TabIndex = 6;
            this.pbTurn.TabStop = false;
            // 
            // btnAIPlay
            // 
            this.btnAIPlay.BackColor = System.Drawing.Color.Red;
            this.btnAIPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAIPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAIPlay.ForeColor = System.Drawing.Color.White;
            this.btnAIPlay.Location = new System.Drawing.Point(225, 0);
            this.btnAIPlay.Margin = new System.Windows.Forms.Padding(5);
            this.btnAIPlay.Name = "btnAIPlay";
            this.btnAIPlay.Size = new System.Drawing.Size(75, 30);
            this.btnAIPlay.TabIndex = 0;
            this.btnAIPlay.Text = "AIPlay";
            this.btnAIPlay.UseVisualStyleBackColor = false;
            this.btnAIPlay.Click += new System.EventHandler(this.btnAIPlay_Click);
            // 
            // lbTurn
            // 
            this.lbTurn.AutoSize = true;
            this.lbTurn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbTurn.Location = new System.Drawing.Point(415, 3);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Size = new System.Drawing.Size(42, 21);
            this.lbTurn.TabIndex = 2;
            this.lbTurn.Text = "Turn";
            // 
            // cbDepth
            // 
            this.cbDepth.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbDepth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepth.FormattingEnabled = true;
            this.cbDepth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbDepth.Location = new System.Drawing.Point(444, 2);
            this.cbDepth.Name = "cbDepth";
            this.cbDepth.Size = new System.Drawing.Size(49, 21);
            this.cbDepth.TabIndex = 5;
            this.cbDepth.Text = "1";
            this.cbDepth.SelectedIndexChanged += new System.EventHandler(this.cbDepth_SelectedIndexChanged);
            // 
            // lbDepth
            // 
            this.lbDepth.AutoSize = true;
            this.lbDepth.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbDepth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepth.ForeColor = System.Drawing.Color.Black;
            this.lbDepth.Location = new System.Drawing.Point(399, 4);
            this.lbDepth.Name = "lbDepth";
            this.lbDepth.Size = new System.Drawing.Size(39, 15);
            this.lbDepth.TabIndex = 4;
            this.lbDepth.Text = "Depth";
            // 
            // Gomoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(505, 557);
            this.Controls.Add(this.pnlAI);
            this.Controls.Add(this.cbDepth);
            this.Controls.Add(this.lbDepth);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.msMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(400, 400);
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "Gomoku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gomoku";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.pnlAI.ResumeLayout(false);
            this.pnlAI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiPvC;
        private System.Windows.Forms.ToolStripMenuItem tsmiComStart;
        private System.Windows.Forms.ToolStripMenuItem tsmiYouStart;
        private System.Windows.Forms.ToolStripMenuItem tsmiCvC;
        private System.Windows.Forms.ToolStripMenuItem tsmiPvP;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.Panel pnlAI;
        private System.Windows.Forms.Button btnAIPlay;
        private System.Windows.Forms.ComboBox cbDepth;
        private System.Windows.Forms.Label lbDepth;
        private System.Windows.Forms.Label lbTurn;
        private System.Windows.Forms.PictureBox pbTurn;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbNodes;
    }
}

