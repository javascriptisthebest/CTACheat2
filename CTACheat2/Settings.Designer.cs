namespace CTACheat2
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            GameAbbreviationCheck = new CheckBox();
            label1 = new Label();
            button1 = new Button();
            debugLevelSelection = new ComboBox();
            label2 = new Label();
            debugConsoleCheck = new CheckBox();
            SuspendLayout();
            // 
            // GameAbbreviationCheck
            // 
            GameAbbreviationCheck.AutoSize = true;
            GameAbbreviationCheck.Location = new Point(8, 6);
            GameAbbreviationCheck.Name = "GameAbbreviationCheck";
            GameAbbreviationCheck.Size = new Size(191, 19);
            GameAbbreviationCheck.TabIndex = 0;
            GameAbbreviationCheck.Text = "Do not abbreviate game names";
            GameAbbreviationCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Help;
            label1.Location = new Point(354, 162);
            label1.Name = "label1";
            label1.Size = new Size(174, 15);
            label1.TabIndex = 1;
            label1.Text = "Hover over checkboxes for help";
            // 
            // button1
            // 
            button1.Location = new Point(411, 201);
            button1.Name = "button1";
            button1.Size = new Size(117, 23);
            button1.TabIndex = 2;
            button1.Text = "Save changes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // debugLevelSelection
            // 
            debugLevelSelection.FormattingEnabled = true;
            debugLevelSelection.Location = new Point(86, 28);
            debugLevelSelection.Name = "debugLevelSelection";
            debugLevelSelection.Size = new Size(182, 23);
            debugLevelSelection.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 31);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 4;
            label2.Text = "Debug level:";
            // 
            // debugConsoleCheck
            // 
            debugConsoleCheck.AutoSize = true;
            debugConsoleCheck.Location = new Point(8, 57);
            debugConsoleCheck.Name = "debugConsoleCheck";
            debugConsoleCheck.Size = new Size(136, 19);
            debugConsoleCheck.TabIndex = 5;
            debugConsoleCheck.Text = "Show debug console";
            debugConsoleCheck.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 227);
            Controls.Add(debugConsoleCheck);
            Controls.Add(label2);
            Controls.Add(debugLevelSelection);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(GameAbbreviationCheck);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Settings";
            Text = "Settings";
            Load += Settings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox GameAbbreviationCheck;
        private Label label1;
        private Button button1;
        private ComboBox debugLevelSelection;
        private Label label2;
        private CheckBox debugConsoleCheck;
    }
}