﻿namespace Snake
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
            this.lblScore = new System.Windows.Forms.Label();
            this.lblScoreValue = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGameOver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbCanvas.Location = new System.Drawing.Point(13, 13);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(648, 416);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(687, 66);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(92, 25);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "SCORE:";
            // 
            // lblScoreValue
            // 
            this.lblScoreValue.AutoSize = true;
            this.lblScoreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreValue.ForeColor = System.Drawing.Color.Red;
            this.lblScoreValue.Location = new System.Drawing.Point(687, 114);
            this.lblScoreValue.Name = "lblScoreValue";
            this.lblScoreValue.Size = new System.Drawing.Size(0, 25);
            this.lblScoreValue.TabIndex = 2;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.Location = new System.Drawing.Point(70, 82);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(93, 33);
            this.lblGameOver.TabIndex = 3;
            this.lblGameOver.Text = "label1";
            this.lblGameOver.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblScoreValue);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblScoreValue;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblGameOver;
    }
}

