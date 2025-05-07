using IniParser;
using IniParser.Model;
using System.Data;

namespace CTACheat2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BuildDateLabel.Text = "Built on " + CTACheat2.Properties.Resources.BuildDate;
            string username = Environment.GetEnvironmentVariable("USERNAME");
            int GameTally = 0;
            if (Directory.Exists("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi"))
            {
                GameSelectionBox.Items.Add("CTA 1 (original)");
                GameTally += 1;
            }
            if (Directory.Exists("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Bizarre_Adventure"))
            {
                GameSelectionBox.Items.Add("CTA 2 (original)");
                GameTally += 1;
            }
            if (Directory.Exists("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi_Journey"))
            {
                GameSelectionBox.Items.Add("CTA 3 (original)");
                GameTally += 1;
            }
            if (Directory.Exists("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi_Tuna"))
            {
                GameSelectionBox.Items.Add("CTA 4 (original)");
                GameTally += 1;
            }
            StatusLabel.Text = "Found save files for " + GameTally.ToString() + " games.";
        }

        private void GameSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (GameSelectionBox.Text)
            {
                case "CTA 1 (original)":
                    string[] actions = { "Change stage" };
                    ActionSelectionBox.Items.AddRange(actions);
                    break;
                case "CTA 2 (original)":
                    string[] actions2 = { "Change stage" };
                    ActionSelectionBox.Items.AddRange(actions2);
                    break;
                case "CTA 3 (original)":
                    string[] actions3 = { "Not implemented!" };
                    ActionSelectionBox.Items.AddRange(actions3);
                    break;
                case "CTA 4 (original)":
                    string[] actions4 = { "Set post bad ending", "Set bad ending", "Change stage" };
                    ActionSelectionBox.Items.AddRange(actions4);
                    break;
            }
        }

        private void ActionSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ActionSelectionBox.Text)
            {
                case "Change stage":
                    switch (GameSelectionBox.Text)
                    {
                        case "CTA 1 (original)":
                            ValueBox.PlaceholderText = "Type in a stage from 1 to 4";
                            break;
                        case "CTA 2 (original)":
                            ValueBox.PlaceholderText = "Type in a stage from 1 to 4";
                            break;
                        case "CTA 4 (original)":
                            ValueBox.PlaceholderText = "Type in a stage from 1 to 4";
                            break;
                    }
                    ValueBox.Enabled = true;
                    break;
                default:
                    ValueBox.PlaceholderText = "Type in a value";
                    ValueBox.Enabled = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            string username = Environment.GetEnvironmentVariable("USERNAME");
            switch (GameSelectionBox.Text)
            {
                case "CTA 1 (original)":
                    if (ActionSelectionBox.Text == "Change stage")
                    {
                        try
                        {
                            Int32.Parse(ValueBox.Text);
                        }
                        catch (Exception c)
                        {
                            MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (Int32.Parse(ValueBox.Text) > 4 || Int32.Parse(ValueBox.Text) < 1)
                        {
                            MessageBox.Show("Illegal argument: Stage cannot be more than 4 or less than 1!", "CTACheat: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        IniData saveFileData = parser.ReadFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi\\progress.ini");

                        saveFileData["progress"]["stage"] = ValueBox.Text.ToString();

                        parser.WriteFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi\\progress.ini", saveFileData);
                    }
                    break;
                case "CTA 2 (original)":
                    if (ActionSelectionBox.Text == "Change stage")
                    {
                        try
                        {
                            Int32.Parse(ValueBox.Text);
                        }
                        catch (Exception c)
                        {
                            MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (Int32.Parse(ValueBox.Text) > 4 || Int32.Parse(ValueBox.Text) < 1)
                        {
                            MessageBox.Show("Illegal argument: Stage cannot be more than 4 or less than 1!", "CTACheat: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        IniData saveFileData = parser.ReadFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Bizarre_Adventure\\hello.ini");

                        saveFileData["progress"]["stage"] = ValueBox.Text.ToString();

                        parser.WriteFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Bizarre_Adventure\\hello.ini", saveFileData);
                    }
                    break;
                case "CTA 3 (original)":
                        if (ActionSelectionBox.Text == "Change stage")
                        {
                            try
                            {
                                Int32.Parse(ValueBox.Text);
                            }
                            catch (Exception c)
                            {
                                MessageBox.Show("Unknwon exception while parsing value: " + c.Message, "CTACheat: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (Int32.Parse(ValueBox.Text) > 5 || Int32.Parse(ValueBox.Text) < 1)
                            {
                                MessageBox.Show("Illegal argument: Stage cannot be more than 5 or less than 1!", "CTACheat: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                       
                            IniData saveFileData = parser.ReadFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi_Journey\\hello.ini");
                    
                            saveFileData["progress"]["stage"] = ValueBox.Text.ToString();

                            parser.WriteFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Bizarre_Adventure\\hello.ini", saveFileData);
                        }
                break;
                case "CTA 4 (original)":
                    switch (ActionSelectionBox.Text)
                    {
                        case "Set post bad ending":
                            IniData saveFileData = parser.ReadFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi_Tuna\\file.ini");

                            if (saveFileData["Catto"]["PostBadEnd"] == "1")
                            {
                                saveFileData["Catto"]["PostBadEnd"] = "0";
                            }
                            else
                            {
                                saveFileData["Catto"]["PostBadEnd"] = "1";
                            }

                            parser.WriteFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi_Tuna\\file.ini", saveFileData);
                            break;
                        case "Set bad ending":
                            IniData saveFileData2 = parser.ReadFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi_Tuna\\file.ini");

                            if (saveFileData2["Catto"]["BadEnd"] == "1")
                            {
                                saveFileData2["Catto"]["BadEnd"] = "0";
                            }
                            else
                            {
                                saveFileData2["Catto"]["BadEnd"] = "1";
                            }

                            parser.WriteFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi_Tuna\\file.ini", saveFileData2);
                            break;
                        case "Change stage":
                            try
                            {
                                Int32.Parse(ValueBox.Text);
                            }
                            catch (Exception c)
                            {
                                MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (Int32.Parse(ValueBox.Text) > 4 || Int32.Parse(ValueBox.Text) < 1)
                            {
                                MessageBox.Show("Illegal argument: Stage cannot be more than 4 or less than 1!", "CTACheat: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            IniData saveFileData3 = parser.ReadFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi_Tuna\\file.ini");

                            saveFileData3["progress"]["stage"] = ValueBox.Text.ToString();

                            parser.WriteFile("C:\\Users\\" + username + "\\AppData\\Local\\Catto_Boi_Tuna\\file.ini", saveFileData3);
                            break;
                    }
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            About aboutBox = new About();
            aboutBox.Show();
        }
    }
}
