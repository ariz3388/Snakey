namespace Snake
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
            this.components = new System.ComponentModel.Container();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.dspScore = new System.Windows.Forms.Label();
            this.lblGameOverMessage = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.dspLevel = new System.Windows.Forms.Label();
            this.dspHighScore = new System.Windows.Forms.Label();
            this.dspLives = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.dspSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dspCanvasWidthP = new System.Windows.Forms.Label();
            this.dspCanvasWidthU = new System.Windows.Forms.Label();
            this.dspCanvasHeightP = new System.Windows.Forms.Label();
            this.dspCanvasHeightU = new System.Windows.Forms.Label();
            this.lblMusicCredit1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.Black;
            this.pbCanvas.Location = new System.Drawing.Point(12, 71);
            this.pbCanvas.MaximumSize = new System.Drawing.Size(541, 560);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(541, 560);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.updateGraphics);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(309, 36);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(129, 19);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Score:";
            // 
            // dspScore
            // 
            this.dspScore.AutoSize = true;
            this.dspScore.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dspScore.Location = new System.Drawing.Point(444, 36);
            this.dspScore.Name = "dspScore";
            this.dspScore.Size = new System.Drawing.Size(109, 19);
            this.dspScore.TabIndex = 2;
            this.dspScore.Text = "00000";
            // 
            // lblGameOverMessage
            // 
            this.lblGameOverMessage.AutoSize = true;
            this.lblGameOverMessage.BackColor = System.Drawing.Color.Black;
            this.lblGameOverMessage.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOverMessage.ForeColor = System.Drawing.Color.Gold;
            this.lblGameOverMessage.Location = new System.Drawing.Point(65, 268);
            this.lblGameOverMessage.Name = "lblGameOverMessage";
            this.lblGameOverMessage.Size = new System.Drawing.Size(189, 19);
            this.lblGameOverMessage.TabIndex = 3;
            this.lblGameOverMessage.Text = "GAME OVER";
            this.lblGameOverMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.Location = new System.Drawing.Point(12, 9);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(229, 19);
            this.lblHighScore.TabIndex = 4;
            this.lblHighScore.Text = "High Score:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(369, 9);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(129, 19);
            this.lblLevel.TabIndex = 5;
            this.lblLevel.Text = "Level:";
            // 
            // dspLevel
            // 
            this.dspLevel.AutoSize = true;
            this.dspLevel.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dspLevel.Location = new System.Drawing.Point(504, 9);
            this.dspLevel.Name = "dspLevel";
            this.dspLevel.Size = new System.Drawing.Size(49, 19);
            this.dspLevel.TabIndex = 6;
            this.dspLevel.Text = "00";
            // 
            // dspHighScore
            // 
            this.dspHighScore.AutoSize = true;
            this.dspHighScore.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dspHighScore.Location = new System.Drawing.Point(238, 9);
            this.dspHighScore.Name = "dspHighScore";
            this.dspHighScore.Size = new System.Drawing.Size(109, 19);
            this.dspHighScore.TabIndex = 7;
            this.dspHighScore.Text = "00000";
            // 
            // dspLives
            // 
            this.dspLives.AutoSize = true;
            this.dspLives.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dspLives.ForeColor = System.Drawing.Color.OrangeRed;
            this.dspLives.Location = new System.Drawing.Point(194, 36);
            this.dspLives.Name = "dspLives";
            this.dspLives.Size = new System.Drawing.Size(109, 19);
            this.dspLives.TabIndex = 8;
            this.dspLives.Text = "OOOOO";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(12, 36);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(129, 19);
            this.lblSpeed.TabIndex = 9;
            this.lblSpeed.Text = "Speed:";
            // 
            // dspSpeed
            // 
            this.dspSpeed.AutoSize = true;
            this.dspSpeed.Font = new System.Drawing.Font("C64 Pro Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dspSpeed.Location = new System.Drawing.Point(139, 36);
            this.dspSpeed.Name = "dspSpeed";
            this.dspSpeed.Size = new System.Drawing.Size(49, 19);
            this.dspSpeed.TabIndex = 10;
            this.dspSpeed.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("C64 Pro Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(559, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Canvas Width (P):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("C64 Pro Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(559, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Canvas Width (U):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("C64 Pro Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(559, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Canvas Height (P):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("C64 Pro Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(559, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Canvas Height (U):";
            // 
            // dspCanvasWidthP
            // 
            this.dspCanvasWidthP.AutoSize = true;
            this.dspCanvasWidthP.Font = new System.Drawing.Font("C64 Pro Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dspCanvasWidthP.Location = new System.Drawing.Point(829, 71);
            this.dspCanvasWidthP.Name = "dspCanvasWidthP";
            this.dspCanvasWidthP.Size = new System.Drawing.Size(33, 13);
            this.dspCanvasWidthP.TabIndex = 15;
            this.dspCanvasWidthP.Text = "00";
            // 
            // dspCanvasWidthU
            // 
            this.dspCanvasWidthU.AutoSize = true;
            this.dspCanvasWidthU.Font = new System.Drawing.Font("C64 Pro Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dspCanvasWidthU.Location = new System.Drawing.Point(829, 94);
            this.dspCanvasWidthU.Name = "dspCanvasWidthU";
            this.dspCanvasWidthU.Size = new System.Drawing.Size(33, 13);
            this.dspCanvasWidthU.TabIndex = 16;
            this.dspCanvasWidthU.Text = "00";
            // 
            // dspCanvasHeightP
            // 
            this.dspCanvasHeightP.AutoSize = true;
            this.dspCanvasHeightP.Font = new System.Drawing.Font("C64 Pro Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dspCanvasHeightP.Location = new System.Drawing.Point(829, 119);
            this.dspCanvasHeightP.Name = "dspCanvasHeightP";
            this.dspCanvasHeightP.Size = new System.Drawing.Size(33, 13);
            this.dspCanvasHeightP.TabIndex = 17;
            this.dspCanvasHeightP.Text = "00";
            // 
            // dspCanvasHeightU
            // 
            this.dspCanvasHeightU.AutoSize = true;
            this.dspCanvasHeightU.Font = new System.Drawing.Font("C64 Pro Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dspCanvasHeightU.Location = new System.Drawing.Point(829, 145);
            this.dspCanvasHeightU.Name = "dspCanvasHeightU";
            this.dspCanvasHeightU.Size = new System.Drawing.Size(33, 13);
            this.dspCanvasHeightU.TabIndex = 18;
            this.dspCanvasHeightU.Text = "00";
            // 
            // lblMusicCredit1
            // 
            this.lblMusicCredit1.AutoSize = true;
            this.lblMusicCredit1.Location = new System.Drawing.Point(590, 201);
            this.lblMusicCredit1.Name = "lblMusicCredit1";
            this.lblMusicCredit1.Size = new System.Drawing.Size(35, 13);
            this.lblMusicCredit1.TabIndex = 19;
            this.lblMusicCredit1.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 643);
            this.Controls.Add(this.lblMusicCredit1);
            this.Controls.Add(this.dspCanvasHeightU);
            this.Controls.Add(this.dspCanvasHeightP);
            this.Controls.Add(this.dspCanvasWidthU);
            this.Controls.Add(this.dspCanvasWidthP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dspSpeed);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.dspLives);
            this.Controls.Add(this.dspHighScore);
            this.Controls.Add(this.dspLevel);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.lblGameOverMessage);
            this.Controls.Add(this.dspScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbCanvas);
            this.Name = "Form1";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label dspScore;
        private System.Windows.Forms.Label lblGameOverMessage;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label dspLevel;
        private System.Windows.Forms.Label dspHighScore;
        private System.Windows.Forms.Label dspLives;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label dspSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label dspCanvasWidthP;
        private System.Windows.Forms.Label dspCanvasWidthU;
        private System.Windows.Forms.Label dspCanvasHeightP;
        private System.Windows.Forms.Label dspCanvasHeightU;
        private System.Windows.Forms.Label lblMusicCredit1;
    }
}