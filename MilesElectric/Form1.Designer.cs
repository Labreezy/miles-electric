namespace MilesElectric
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
            this.memWatchTimer = new System.Windows.Forms.Timer(this.components);
            this.attachBtn = new System.Windows.Forms.Button();
            this.respawnPosLabel = new System.Windows.Forms.Label();
            this.savePosBtn = new System.Windows.Forms.Button();
            this.posLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.dimnesionCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // memWatchTimer
            // 
            this.memWatchTimer.Interval = 10;
            this.memWatchTimer.Tick += new System.EventHandler(this.memWatchTimer_Tick);
            // 
            // attachBtn
            // 
            this.attachBtn.Location = new System.Drawing.Point(8, 34);
            this.attachBtn.Name = "attachBtn";
            this.attachBtn.Size = new System.Drawing.Size(189, 48);
            this.attachBtn.TabIndex = 0;
            this.attachBtn.Text = "Attach";
            this.attachBtn.UseVisualStyleBackColor = true;
            this.attachBtn.Click += new System.EventHandler(this.attachBtn_Click);
            // 
            // respawnPosLabel
            // 
            this.respawnPosLabel.Location = new System.Drawing.Point(12, 179);
            this.respawnPosLabel.Name = "respawnPosLabel";
            this.respawnPosLabel.Size = new System.Drawing.Size(184, 43);
            this.respawnPosLabel.TabIndex = 3;
            this.respawnPosLabel.Text = "Current Respawn Position:";
            // 
            // savePosBtn
            // 
            this.savePosBtn.Enabled = false;
            this.savePosBtn.Location = new System.Drawing.Point(8, 236);
            this.savePosBtn.Name = "savePosBtn";
            this.savePosBtn.Size = new System.Drawing.Size(184, 31);
            this.savePosBtn.TabIndex = 4;
            this.savePosBtn.Text = "Save Position";
            this.savePosBtn.UseVisualStyleBackColor = true;
            this.savePosBtn.Click += new System.EventHandler(this.savePosBtn_Click);
            // 
            // posLabel
            // 
            this.posLabel.Location = new System.Drawing.Point(13, 103);
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(184, 37);
            this.posLabel.TabIndex = 5;
            this.posLabel.Text = "Current Position:";
            // 
            // refreshButton
            // 
            this.refreshButton.Enabled = false;
            this.refreshButton.Location = new System.Drawing.Point(13, 310);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(179, 29);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "Refresh Pointers";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // dimnesionCheck
            // 
            this.dimnesionCheck.Location = new System.Drawing.Point(30, 371);
            this.dimnesionCheck.Name = "dimnesionCheck";
            this.dimnesionCheck.Size = new System.Drawing.Size(133, 22);
            this.dimnesionCheck.TabIndex = 7;
            this.dimnesionCheck.Text = "Save As 2D";
            this.dimnesionCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(214, 399);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dimnesionCheck);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.posLabel);
            this.Controls.Add(this.savePosBtn);
            this.Controls.Add(this.respawnPosLabel);
            this.Controls.Add(this.attachBtn);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.CheckBox dimnesionCheck;

        private System.Windows.Forms.Button refreshButton;

        private System.Windows.Forms.Label posLabel;

        private System.Windows.Forms.Label stgLabel;
        private System.Windows.Forms.Label respawnPosLabel;
        private System.Windows.Forms.Button savePosBtn;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Timer memWatchTimer;
        private System.Windows.Forms.Button attachBtn;

        #endregion
    }
}