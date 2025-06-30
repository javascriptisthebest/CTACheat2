using IniParser;
using IniParser.Model;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CTACheat2
{
    public partial class Main : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Main()
        {
            InitializeComponent();
        }

        public static class UsefulVariables
        {
            public static string Username = Environment.GetEnvironmentVariable("USERNAME");
            public static string LocalAppData = Environment.GetEnvironmentVariable("localappdata");
            public static class SaveFilePaths
            {
                public static string CTA1OGDirPath = UsefulVariables.LocalAppData + "\\Catto_Boi";
                public static string CTA1OGFilePath = UsefulVariables.LocalAppData + "\\Catto_Boi\\progress.ini";

                public static string CTA2OGDirPath = UsefulVariables.LocalAppData + "\\Catto_Bizarre_Adventure";
                public static string CTA2OGFilePath = UsefulVariables.LocalAppData + "\\Catto_Bizarre_Adventure\\hello.ini";
                
                public static string CTA3OGDirPath = UsefulVariables.LocalAppData + "\\Catto_Boi_Journey";
                public static string CTA3OGFilePath = UsefulVariables.LocalAppData + "\\Catto_Boi_Journey\\hello.ini";

                public static string CTA4OGDirPath = UsefulVariables.LocalAppData + "\\Catto_Boi_Tuna";
                public static string CTA4OGFilePath = UsefulVariables.LocalAppData + "\\Catto_Boi_Tuna\\file.ini";

                public static string CTA5OGDirPath = UsefulVariables.LocalAppData + "\\Doggo_Boye";
                public static string CTA5OGFilePath = UsefulVariables.LocalAppData + "\\Doggo_Boye\\file.ini";

                public static string CTA6OGDirPath = UsefulVariables.LocalAppData + "\\Catto_Boi_Fragments";
                public static string CTA6OGFilePath = UsefulVariables.LocalAppData + "\\Catto_Boi_Fragments\\file.ini";

                public static string CTA7OGDirPath = UsefulVariables.LocalAppData + "\\Catto_Boi_Quest";
                public static string CTA7OGFilePath = UsefulVariables.LocalAppData + "\\Catto_Boi_Quest\\file.ini";
            }

            public static string settingsIniPath = LocalAppData + "\\CTACheat2\\settings.ini";
            public static string settingsDirPath = LocalAppData + "\\CTACheat2";
        }
        public static class GlobalSettings
        {
            public static bool GameAbbreviationSetting = false;
            public static string DebugLevel = "none";
            public static bool DebugConsoleSetting = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BuildDateLabel.Text = "Built on " + CTACheat2.Properties.Resources.BuildDate;

            if (!File.Exists(UsefulVariables.settingsIniPath) || !Directory.Exists(UsefulVariables.settingsDirPath))
            {
                if (Directory.Exists(UsefulVariables.settingsDirPath))
                {
                    var file = File.Create(UsefulVariables.settingsIniPath);
                    file.Dispose();

                    IniData defaultSettings = new IniData();
                    var parser = new FileIniDataParser();

                    defaultSettings["CTACheat2"]["GameAbbreviationSetting"] = "false";
                    defaultSettings["CTACheat2"]["DebugLevel"] = "none";
                    defaultSettings["CTACheat2"]["DebugConsoleSetting"] = "false";
                    parser.WriteFile(UsefulVariables.settingsIniPath, defaultSettings);
                }
                else
                {
                    Directory.CreateDirectory(UsefulVariables.settingsDirPath);
                    var file = File.Create(UsefulVariables.settingsIniPath);
                    file.Dispose();
                    IniData defaultSettings = new IniData();
                    var parser = new FileIniDataParser();

                    defaultSettings["CTACheat2"]["GameAbbreviationSetting"] = "false";
                    defaultSettings["CTACheat2"]["DebugLevel"] = "none";
                    defaultSettings["CTACheat2"]["DebugConsoleSetting"] = "false";
                    parser.WriteFile(UsefulVariables.settingsIniPath, defaultSettings);
                }
            }
            else if (File.Exists(UsefulVariables.settingsIniPath) && new FileInfo(UsefulVariables.settingsIniPath).Length != 0)
            {
                var parser = new FileIniDataParser();

                IniData settingsData = parser.ReadFile(UsefulVariables.settingsIniPath);

                try
                {
                    Boolean.Parse(settingsData["CTACheat2"]["GameAbbreviationSetting"]);
                }
                catch (Exception c)
                {
                    MessageBox.Show("The error: " + c.Message + " was thrown on parsing the game abbreviation setting.", "CTACheat2: Error on loading settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GlobalSettings.DebugLevel = settingsData["CTACheat2"]["DebugLevel"];
                GlobalSettings.GameAbbreviationSetting = Boolean.Parse(settingsData["CTACheat2"]["GameAbbreviationSetting"]);
                GlobalSettings.DebugConsoleSetting = Boolean.Parse(settingsData["CTACheat2"]["DebugConsoleSetting"]);
            }
            if (GlobalSettings.DebugConsoleSetting)
            {
                AllocConsole();
                Console.WriteLine("CTACheat2: The sequel to CTACheat, that no one wanted :)");
                Console.WriteLine("Compilation date: " + CTACheat2.Properties.Resources.BuildDate);
            }
            int GameTally = 0;
            if (Directory.Exists(UsefulVariables.SaveFilePaths.CTA1OGDirPath))
            {
                if (GlobalSettings.DebugLevel == "verbose")
                {
                    Console.WriteLine("[Game detection logic]: CTA 1 (original) detected");
                }
                if (!GlobalSettings.GameAbbreviationSetting)
                {
                    GameSelectionBox.Items.Add("CTA 1 (original)");
                }
                else
                {
                    GameSelectionBox.Items.Add("The Adventures of Catto Boi (original)");
                }
                GameTally += 1;
            }
            if (Directory.Exists(UsefulVariables.SaveFilePaths.CTA2OGDirPath))
            {
                if (GlobalSettings.DebugLevel == "verbose")
                {
                    Console.WriteLine("[Game detection logic]: CTA 2 (original) detected");
                }
                if (!GlobalSettings.GameAbbreviationSetting)
                {
                    GameSelectionBox.Items.Add("CTA 2 (original)");
                }
                else
                {
                    GameSelectionBox.Items.Add("Catto Boi's Bizarre Adventure (original)");
                }

                GameTally += 1;
            }
            if (Directory.Exists(UsefulVariables.SaveFilePaths.CTA3OGDirPath))
            {
                if (GlobalSettings.DebugLevel == "verbose")
                {
                    Console.WriteLine("[Game detection logic]: CTA 3 (original) detected");
                }
                if (!GlobalSettings.GameAbbreviationSetting)
                {
                    GameSelectionBox.Items.Add("CTA 3 (original)");
                }
                else
                {
                    GameSelectionBox.Items.Add("Catto Boi's Journey To Catto Land (original)");
                }
                GameTally += 1;
            }
            if (Directory.Exists(UsefulVariables.SaveFilePaths.CTA4OGDirPath))
            {
                if (GlobalSettings.DebugLevel == "verbose")
                {
                    Console.WriteLine("[Game detection logic]: CTA 4 (original) detected");
                }
                if (!GlobalSettings.GameAbbreviationSetting)
                {
                    GameSelectionBox.Items.Add("CTA 4 (original)");
                }
                else
                {
                    GameSelectionBox.Items.Add("Catto Boi's Quest For The Frozen Tuna (original)");
                }

                GameTally += 1;
            }
            if (Directory.Exists(UsefulVariables.SaveFilePaths.CTA5OGDirPath))
            {
                if (GlobalSettings.DebugLevel == "verbose")
                {
                    Console.WriteLine("[Game detection logic]: CTA 5 (original) detected");
                }
                if (!GlobalSettings.GameAbbreviationSetting)
                {
                    GameSelectionBox.Items.Add("CTA 5 (original)");
                }
                else
                {
                    GameSelectionBox.Items.Add("Doggo Boye's Fantastic Adventure (original)");
                }

                GameTally += 1;
            }
            if (Directory.Exists(UsefulVariables.SaveFilePaths.CTA6OGDirPath))
            {
                if (GlobalSettings.DebugLevel == "verbose")
                {
                    Console.WriteLine("[Game detection logic]: CTA 6 (original) detected");
                }
                if (!GlobalSettings.GameAbbreviationSetting)
                {
                    GameSelectionBox.Items.Add("CTA 6 (original)");
                }
                else
                {
                    GameSelectionBox.Items.Add("Catto Boi and the Legendary Fragments (original)");
                }
                GameTally += 1;
            }
            if (Directory.Exists(UsefulVariables.SaveFilePaths.CTA7OGDirPath))
            {
                if (GlobalSettings.DebugLevel == "verbose")
                {
                    Console.WriteLine("[Game detection logic]: CTA 7 (original) detected");
                }
                if (!GlobalSettings.GameAbbreviationSetting)
                {
                    GameSelectionBox.Items.Add("CTA 7 (original)");
                }
                else
                {
                    GameSelectionBox.Items.Add("Catto Boi's Village Quest (original)");
                }
                GameTally += 1;
            }
            StatusLabel.Text = "Found save files for " + GameTally.ToString() + " games.";
            if (GlobalSettings.DebugLevel == "verbose")
            {
                Console.WriteLine("[Game detection logic]: Found saves for " + GameTally.ToString() + " games.");
            }
        }

        private void GameSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GlobalSettings.DebugLevel == "verbose")
            {
                Console.WriteLine("[Main]: Game selection changed to " + GameSelectionBox.Text);
            }
            switch (GameSelectionBox.Text)
            {
                case "CTA 1 (original)" or "The Adventures of Catto Boi (original)":
                    ActionSelectionBox.Items.Clear();
                    string[] actions = { "Change stage" };
                    ActionSelectionBox.Items.AddRange(actions);
                    break;
                case "CTA 2 (original)" or "Catto Boi's Bizarre Adventure (original)":
                    ActionSelectionBox.Items.Clear();
                    string[] actions2 = { "Change stage" };
                    ActionSelectionBox.Items.AddRange(actions2);
                    break;
                case "CTA 3 (original)" or "Catto Boi's Journey To Catto Land (original)":
                    ActionSelectionBox.Items.Clear();
                    string[] actions3 = { "Change stage" };
                    ActionSelectionBox.Items.AddRange(actions3);
                    break;
                case "CTA 4 (original)" or "Catto Boi's Quest For The Frozen Tuna (original)":
                    ActionSelectionBox.Items.Clear();
                    string[] actions4 = { "Change stage", "Set post bad ending", "Set bad ending" };
                    ActionSelectionBox.Items.AddRange(actions4);
                    break;
                case "CTA 5 (original)" or "Doggo Boye's Fantastic Adventure (original)":
                    ActionSelectionBox.Items.Clear();
                    string[] actions5 = { "Change stage", "Set end value"  };
                    ActionSelectionBox.Items.AddRange(actions5);
                    break;
                case "CTA 6 (original)" or "Catto Boi and the Legendary Fragments (original)":
                    ActionSelectionBox.Items.Clear();
                    string[] actions6 = { "Change ACT", "Set bad ending", "Set TRUE bad ending", "Set true good ending" };
                    ActionSelectionBox.Items.AddRange(actions6);
                    break;
                case "CTA 7 (original)" or "Catto Boi's Village Quest (original)":
                    ActionSelectionBox.Items.Clear();
                    string[] actions7 = { "Change ACT", "Set bad ending", "Set good ending" };
                    ActionSelectionBox.Items.AddRange(actions7);
                    break;
            }
        }

        private void ActionSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GlobalSettings.DebugLevel == "verbose")
            {
                Console.WriteLine("[Main]: Action changed to " + ActionSelectionBox.Text);
            }
            switch (ActionSelectionBox.Text)
            {
                case "Change stage" or "Change ACT":
                    switch (GameSelectionBox.Text)
                    {
                        case "CTA 1 (original)" or "The Adventures of Catto Boi (original)":
                            ValueBox.PlaceholderText = "Type in a stage from 0 to 4";
                            break;
                        case "CTA 2 (original)" or "Catto Boi's Bizarre Adventure (original)":
                            ValueBox.PlaceholderText = "Type in a stage from 0 to 4";
                            break;
                        case "CTA 3 (original)" or "Catto Boi's Journey To Catto Land (original)":
                            ValueBox.PlaceholderText = "Type in a stage from 1 to 5";
                            break;
                        case "CTA 4 (original)" or "Catto Boi's Quest For The Frozen Tuna (original)":
                            ValueBox.PlaceholderText = "Type in a stage from 0 to 4";
                            break;
                        case "CTA 5 (original)" or "Doggo Boye's Fantastic Adventure (original)":
                            ValueBox.PlaceholderText = "Type in a stage from 0 to 4";
                            break;
                        case "CTA 6 (original)" or "Catto Boi and the Legendary Fragments (original)":
                            ValueBox.PlaceholderText = "Type in an ACT from 1 to 8";
                            break;
                        case "CTA 7 (original)" or "Catto Boi's Village Quest (original)":
                            ValueBox.PlaceholderText = "Type in an ACT from 1 to 4";
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
                case "CTA 1 (original)" or "The Adventures of Catto Boi (original)":
                    if (ActionSelectionBox.Text == "Change stage")
                    {
                        try
                        {
                            Int32.Parse(ValueBox.Text);
                        }
                        catch (Exception c)
                        {
                            MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (Int32.Parse(ValueBox.Text) > 4 || Int32.Parse(ValueBox.Text) < 0)
                        {
                            MessageBox.Show("Illegal argument: Stage cannot be more than 4 or less than 0!", "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        IniData saveFileData = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA1OGFilePath);

                        saveFileData["progress"]["stage"] = ValueBox.Text.ToString();

                        parser.WriteFile(UsefulVariables.SaveFilePaths.CTA1OGFilePath, saveFileData);
                    }
                    break;
                case "CTA 2 (original)" or "Catto Boi's Bizarre Adventure (original)":
                    if (ActionSelectionBox.Text == "Change stage")
                    {
                        try
                        {
                            Int32.Parse(ValueBox.Text);
                        }
                        catch (Exception c)
                        {
                            MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (Int32.Parse(ValueBox.Text) > 4 || Int32.Parse(ValueBox.Text) < 0)
                        {
                            MessageBox.Show("Illegal argument: Stage cannot be more than 4 or less than 0!", "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        IniData saveFileData = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA2OGFilePath);

                        saveFileData["progress"]["stage"] = ValueBox.Text.ToString();

                        parser.WriteFile(UsefulVariables.SaveFilePaths.CTA2OGFilePath, saveFileData);
                    }
                    break;
                case "CTA 3 (original)" or "Catto Boi's Journey To Catto Land (original)":
                    if (ActionSelectionBox.Text == "Change stage")
                    {
                        try
                        {
                            Int32.Parse(ValueBox.Text);
                        }
                        catch (Exception c)
                        {
                            MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (Int32.Parse(ValueBox.Text) > 5 || Int32.Parse(ValueBox.Text) < 1)
                        {
                            MessageBox.Show("Illegal argument: Stage cannot be more than 5 or less than 1!", "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        IniData saveFileData = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA3OGFilePath);

                        saveFileData["progress"]["stage"] = ValueBox.Text.ToString();

                        parser.WriteFile(UsefulVariables.SaveFilePaths.CTA3OGFilePath, saveFileData);
                    }
                    break;
                case "CTA 4 (original)" or "Catto Boi's Quest For The Frozen Tuna (original)":
                    switch (ActionSelectionBox.Text)
                    {
                        case "Set post bad ending":
                            IniData saveFileData = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA4OGFilePath);

                            if (saveFileData["Catto"]["PostBadEnd"] == "1")
                            {
                                saveFileData["Catto"]["PostBadEnd"] = "0";
                            }
                            else
                            {
                                saveFileData["Catto"]["PostBadEnd"] = "1";
                            }

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA4OGFilePath, saveFileData);
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

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA4OGFilePath, saveFileData2);
                            break;
                        case "Change stage":
                            try
                            {
                                Int32.Parse(ValueBox.Text);
                            }
                            catch (Exception c)
                            {
                                MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (Int32.Parse(ValueBox.Text) > 4 || Int32.Parse(ValueBox.Text) < 0)
                            {
                                MessageBox.Show("Illegal argument: Stage cannot be more than 4 or less than 0!", "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            IniData saveFileData3 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA4OGFilePath);

                            saveFileData3["Catto"]["Stage"] = ValueBox.Text.ToString();

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA4OGFilePath, saveFileData3);
                            break;
                    }
                    break;
                case "CTA 5 (original)" or "Doggo Boye's Fantastic Adventure (original)":
                    switch (ActionSelectionBox.Text)
                    {
                        case "Set end value":

                            IniData saveFileData4 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA5OGFilePath);

                            if (saveFileData4["Doggo"]["End"] == "1")
                            {
                                saveFileData4["Doggo"]["End"] = "0";
                            }
                            else
                            {
                                saveFileData4["Doggo"]["End"] = "1";
                            }

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA5OGFilePath, saveFileData4);
                            break;
                        case "Change stage":
                            try
                            {
                                Int32.Parse(ValueBox.Text);
                            }
                            catch (Exception c)
                            {
                                MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (Int32.Parse(ValueBox.Text) < 0 || Int32.Parse(ValueBox.Text) > 4)
                            {
                                MessageBox.Show("Illegal argument: Stage cannot be more than 4 or less than 0!", "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            IniData saveFileData5 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA5OGFilePath);

                            saveFileData5["Doggo"]["Stage"] = ValueBox.Text.ToString();

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA5OGFilePath, saveFileData5);
                            break;

                    }

                    break;
                case "CTA 6 (original)" or "Catto Boi and the Legendary Fragments (original)":
                    //string[] actions6 = { "Change ACT", "Set bad ending", "Set TRUE bad ending", "Set true good ending" };
                    switch (ActionSelectionBox.Text)
                    {
                        case "Change ACT":
                            try
                            {
                                Int32.Parse(ValueBox.Text);
                            }
                            catch (Exception c)
                            {
                                MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat2: Error on modifcation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (Int32.Parse(ValueBox.Text) < 1 || Int32.Parse(ValueBox.Text) > 8)
                            {
                                MessageBox.Show("Illegal argument: ACT cannot be more than 8 or less than 1!", "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            IniData saveFileData6 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA6OGFilePath);

                            saveFileData6["All-stars"]["ACT"] = ValueBox.Text.ToString();

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA6OGFilePath, saveFileData6);
                            break;
                        case "Set bad ending":
                            IniData saveFileData7 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA6OGFilePath);

                            if (saveFileData7["All-stars"]["BadEnd"] == "0")
                            {
                                saveFileData7["All-stars"]["BadEnd"] = "1";
                            }
                            else
                            {
                                saveFileData7["All-stars"]["BadEnd"] = "0";
                            }

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA6OGFilePath, saveFileData7);
                            break;
                        case "Set TRUE bad ending":
                            IniData saveFileData8 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA6OGFilePath);

                            if (saveFileData8["All-stars"]["TrueBadEnd"] == "0")
                            {
                                saveFileData8["All-stars"]["TrueBadEnd"] = "1";
                            }
                            else
                            {
                                saveFileData8["All-stars"]["TrueBadEnd"] = "0";
                            }

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA6OGFilePath, saveFileData8);
                            break;
                        case "Set true good ending":
                            IniData saveFileData9 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA6OGFilePath);

                            if (saveFileData9["All-stars"]["TrueGoodEnd"] == "0")
                            {
                                saveFileData9["All-stars"]["TrueGoodEnd"] = "1";
                            }
                            else
                            {
                                saveFileData9["All-stars"]["TrueGoodEnd"] = "0";
                            }

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA6OGFilePath, saveFileData9);
                        break;
                    }
                    break;
                    case "CTA 7 (original)" or "Catto Boi's Village Quest (original)":
                    //string[] actions7 = { "Change ACT", "Set bad ending", "Set good ending" };
                    switch (ActionSelectionBox.Text)
                        {
                            case "Change ACT":
                               try
                            {
                                Int32.Parse(ValueBox.Text);
                            }
                            catch (Exception c)
                            {
                                MessageBox.Show("Unknown exception while parsing value: " + c.Message, "CTACheat2: Error on modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            IniData saveFileData10 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA7OGFilePath);

                            saveFileData10["VillageQuest"]["ACT"] = ValueBox.Text.ToString();

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA7OGFilePath, saveFileData10);
                            break;
                            case "Set bad ending":
                                IniData saveFileData11 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA7OGFilePath);

                            if (saveFileData11["VillageQuest"]["BadEnd"] == "0")
                            {
                                saveFileData11["VillageQuest"]["BadEnd"] = "1";
                            } else
                            {
                                saveFileData11["VillageQuest"]["BadEnd"] = "0";
                            }

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA7OGFilePath, saveFileData11);
                                break;
                            case "Set good ending":
                            IniData saveFileData12 = parser.ReadFile(UsefulVariables.SaveFilePaths.CTA7OGFilePath);

                            if (saveFileData12["VillageQuest"]["GoodEnd"] == "0")
                            {
                                saveFileData12["VillageQuest"]["GoodEnd"] = "1";
                            } else
                            {
                                saveFileData12["VillageQuest"]["GoodEnd"] = "0";
                            }

                            parser.WriteFile(UsefulVariables.SaveFilePaths.CTA7OGFilePath, saveFileData12);
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
        private void button2_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.Show();
        }
    }
}
