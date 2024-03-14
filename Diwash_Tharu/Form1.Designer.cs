namespace Diwash_Tharu
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
            this.RunBtn = new System.Windows.Forms.Button();
            this.SyntaxBtn = new System.Windows.Forms.Button();
            this.DispalyPictureBox = new System.Windows.Forms.PictureBox();
            this.multiLinetxt = new System.Windows.Forms.TextBox();
            this.singleLineCommand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorMessage = new System.Windows.Forms.Label();
            this.colorlab = new System.Windows.Forms.Label();
            this.Fill = new System.Windows.Forms.Label();
            this.mulLineCmdTwo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DispalyPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(52, 584);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(125, 41);
            this.RunBtn.TabIndex = 0;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // SyntaxBtn
            // 
            this.SyntaxBtn.Location = new System.Drawing.Point(209, 581);
            this.SyntaxBtn.Name = "SyntaxBtn";
            this.SyntaxBtn.Size = new System.Drawing.Size(125, 41);
            this.SyntaxBtn.TabIndex = 0;
            this.SyntaxBtn.Text = "Syntax";
            this.SyntaxBtn.UseVisualStyleBackColor = true;
            this.SyntaxBtn.Click += new System.EventHandler(this.SyntaxBtn_Click);
            // 
            // DispalyPictureBox
            // 
            this.DispalyPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DispalyPictureBox.Location = new System.Drawing.Point(493, 65);
            this.DispalyPictureBox.Name = "DispalyPictureBox";
            this.DispalyPictureBox.Size = new System.Drawing.Size(624, 485);
            this.DispalyPictureBox.TabIndex = 1;
            this.DispalyPictureBox.TabStop = false;
            this.DispalyPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.dispalyPictureBox_Paint);
            // 
            // multiLinetxt
            // 
            this.multiLinetxt.Location = new System.Drawing.Point(52, 65);
            this.multiLinetxt.Multiline = true;
            this.multiLinetxt.Name = "multiLinetxt";
            this.multiLinetxt.Size = new System.Drawing.Size(406, 353);
            this.multiLinetxt.TabIndex = 2;
            // 
            // singleLineCommand
            // 
            this.singleLineCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleLineCommand.Location = new System.Drawing.Point(52, 514);
            this.singleLineCommand.Name = "singleLineCommand";
            this.singleLineCommand.Size = new System.Drawing.Size(377, 28);
            this.singleLineCommand.TabIndex = 3;
            this.singleLineCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.singleLineCommand_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Single Command";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Miltiple Command";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(755, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Output";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1585, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Open});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(128, 26);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(128, 26);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.Location = new System.Drawing.Point(49, 686);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(0, 16);
            this.errorMessage.TabIndex = 5;
            // 
            // colorlab
            // 
            this.colorlab.AutoSize = true;
            this.colorlab.Location = new System.Drawing.Point(551, 572);
            this.colorlab.Name = "colorlab";
            this.colorlab.Size = new System.Drawing.Size(98, 16);
            this.colorlab.TabIndex = 5;
            this.colorlab.Text = "Pen Color :Red";
            // 
            // Fill
            // 
            this.Fill.AutoSize = true;
            this.Fill.Location = new System.Drawing.Point(791, 572);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(0, 16);
            this.Fill.TabIndex = 5;
            // 
            // mulLineCmdTwo
            // 
            this.mulLineCmdTwo.Location = new System.Drawing.Point(1148, 65);
            this.mulLineCmdTwo.Multiline = true;
            this.mulLineCmdTwo.Name = "mulLineCmdTwo";
            this.mulLineCmdTwo.Size = new System.Drawing.Size(406, 353);
            this.mulLineCmdTwo.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1241, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Miltiple Command";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1585, 759);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mulLineCmdTwo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Fill);
            this.Controls.Add(this.colorlab);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.singleLineCommand);
            this.Controls.Add(this.multiLinetxt);
            this.Controls.Add(this.DispalyPictureBox);
            this.Controls.Add(this.SyntaxBtn);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DispalyPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Button SyntaxBtn;
        private System.Windows.Forms.PictureBox DispalyPictureBox;
        private System.Windows.Forms.TextBox multiLinetxt;
        private System.Windows.Forms.TextBox singleLineCommand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label errorMessage;
        private System.Windows.Forms.Label colorlab;
        private System.Windows.Forms.Label Fill;
        private System.Windows.Forms.TextBox mulLineCmdTwo;
        private System.Windows.Forms.Label label1;
    }
}

