
namespace Othelo_UI
{
    partial class GameSettingsWindow
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
            this.boardSizeButton = new System.Windows.Forms.Button();
            this.playComputerButton = new System.Windows.Forms.Button();
            this.playHumanButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardSizeButton
            // 
            this.boardSizeButton.Location = new System.Drawing.Point(67, 33);
            this.boardSizeButton.Name = "BoardSizeButton";
            this.boardSizeButton.Size = new System.Drawing.Size(420, 40);
            this.boardSizeButton.TabIndex = 0;
            s_BoardSizeText = s_BoardSize.ToString();
            this.boardSizeButton.Text = s_BoardSizeText;
            this.boardSizeButton.UseVisualStyleBackColor = true;
            this.boardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // PlayComputerButton
            // 
            this.playComputerButton.Location = new System.Drawing.Point(67, 102);
            this.playComputerButton.Name = "PlayComputerButton";
            this.playComputerButton.Size = new System.Drawing.Size(200, 40);
            this.playComputerButton.TabIndex = 1;
            this.playComputerButton.Text = "Play against the computer";
            this.playComputerButton.UseVisualStyleBackColor = true;
            this.playComputerButton.Click += new System.EventHandler(this.playComputerButton_Click);
            // 
            // PlayHumanButton
            // 
            this.playHumanButton.Location = new System.Drawing.Point(287, 102);
            this.playHumanButton.Name = "PlayHumanButton";
            this.playHumanButton.Size = new System.Drawing.Size(200, 40);
            this.playHumanButton.TabIndex = 2;
            this.playHumanButton.Text = "Play against your friend";
            this.playHumanButton.UseVisualStyleBackColor = true;
            this.playHumanButton.Click += new System.EventHandler(this.playHumanButton_Click);
            // 
            // GameSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.CenterToScreen();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 189);
            this.Controls.Add(this.playHumanButton);
            this.Controls.Add(this.playComputerButton);
            this.Controls.Add(this.boardSizeButton);
            this.Name = "GameSettingsWindow";
            this.Text = "Othello - Game Settings";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button boardSizeButton;
        private System.Windows.Forms.Button playComputerButton;
        private System.Windows.Forms.Button playHumanButton;
    }
}

