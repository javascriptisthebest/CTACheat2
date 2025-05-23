namespace CTACheat2
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            button1 = new Button();
            GameSelectionBox = new ComboBox();
            StatusLabel = new Label();
            ActionSelectionBox = new ComboBox();
            ValueBox = new TextBox();
            BuildDateLabel = new Label();
            button4 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(439, 277);
            button1.Name = "button1";
            button1.Size = new Size(91, 35);
            button1.TabIndex = 0;
            button1.Text = "Cheat it";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // GameSelectionBox
            // 
            GameSelectionBox.FormattingEnabled = true;
            GameSelectionBox.Location = new Point(12, 12);
            GameSelectionBox.Name = "GameSelectionBox";
            GameSelectionBox.Size = new Size(297, 23);
            GameSelectionBox.TabIndex = 1;
            GameSelectionBox.Text = "Select a game...";
            GameSelectionBox.SelectedIndexChanged += GameSelectionBox_SelectedIndexChanged;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(12, 277);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(105, 15);
            StatusLabel.TabIndex = 3;
            StatusLabel.Text = "Detecting games...";
            // 
            // ActionSelectionBox
            // 
            ActionSelectionBox.FormattingEnabled = true;
            ActionSelectionBox.Location = new Point(12, 41);
            ActionSelectionBox.Name = "ActionSelectionBox";
            ActionSelectionBox.Size = new Size(297, 23);
            ActionSelectionBox.TabIndex = 4;
            ActionSelectionBox.Text = "Select an action...";
            ActionSelectionBox.SelectedIndexChanged += ActionSelectionBox_SelectedIndexChanged;
            // 
            // ValueBox
            // 
            ValueBox.Enabled = false;
            ValueBox.Location = new Point(12, 94);
            ValueBox.Name = "ValueBox";
            ValueBox.PlaceholderText = "Type in a value...";
            ValueBox.Size = new Size(226, 23);
            ValueBox.TabIndex = 5;
            // 
            // BuildDateLabel
            // 
            BuildDateLabel.AutoSize = true;
            BuildDateLabel.Location = new Point(13, 299);
            BuildDateLabel.Name = "BuildDateLabel";
            BuildDateLabel.Size = new Size(59, 15);
            BuildDateLabel.TabIndex = 7;
            BuildDateLabel.Text = "Loading...";
            // 
            // button4
            // 
            button4.Location = new Point(439, 226);
            button4.Name = "button4";
            button4.Size = new Size(91, 45);
            button4.TabIndex = 8;
            button4.Text = "About CTACheat2";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(434, 11);
            button2.Name = "button2";
            button2.Size = new Size(96, 36);
            button2.TabIndex = 9;
            button2.Text = "Settings";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 324);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(BuildDateLabel);
            Controls.Add(ValueBox);
            Controls.Add(ActionSelectionBox);
            Controls.Add(StatusLabel);
            Controls.Add(GameSelectionBox);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "CTACheat2";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox GameSelectionBox;
        private Label StatusLabel;
        private ComboBox ActionSelectionBox;
        private TextBox ValueBox;
        private Label BuildDateLabel;
        private Button button4;
        private Button button2;
    }
}
