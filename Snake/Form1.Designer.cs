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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Time = new System.Windows.Forms.Label();
            this.label_Snake_Size = new System.Windows.Forms.Label();
            this.label_restart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_start = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(850, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_Time
            // 
            this.label_Time.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Time.Location = new System.Drawing.Point(967, 89);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(18, 17);
            this.label_Time.TabIndex = 1;
            this.label_Time.Text = "0";
            // 
            // label_Snake_Size
            // 
            this.label_Snake_Size.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Snake_Size.AutoSize = true;
            this.label_Snake_Size.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Snake_Size.Location = new System.Drawing.Point(966, 130);
            this.label_Snake_Size.Name = "label_Snake_Size";
            this.label_Snake_Size.Size = new System.Drawing.Size(18, 17);
            this.label_Snake_Size.TabIndex = 2;
            this.label_Snake_Size.Text = "0";
            // 
            // label_restart
            // 
            this.label_restart.AutoSize = true;
            this.label_restart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_restart.Font = new System.Drawing.Font("OCR A Extended", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_restart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_restart.Location = new System.Drawing.Point(272, 292);
            this.label_restart.Name = "label_restart";
            this.label_restart.Size = new System.Drawing.Size(435, 35);
            this.label_restart.TabIndex = 3;
            this.label_restart.Text = "Press Enter to start!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(884, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(884, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Length:";
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_start.Font = new System.Drawing.Font("OCR A Extended", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_start.Location = new System.Drawing.Point(187, 156);
            this.label_start.MaximumSize = new System.Drawing.Size(600, 0);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(535, 35);
            this.label_start.TabIndex = 6;
            this.label_start.Text = "Movement with WASD or HJKL";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info.Location = new System.Drawing.Point(951, 500);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(68, 12);
            this.label_info.TabIndex = 7;
            this.label_info.Text = "v 0.2 JoZ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1034, 541);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_restart);
            this.Controls.Add(this.label_Snake_Size);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(1050, 580);
            this.MinimumSize = new System.Drawing.Size(1050, 580);
            this.Name = "Form1";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.Label label_Snake_Size;
        private System.Windows.Forms.Label label_restart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.Label label_info;
    }
}

