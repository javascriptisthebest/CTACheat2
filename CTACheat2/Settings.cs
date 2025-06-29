using IniParser;
using IniParser.Model;

namespace CTACheat2
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            ToolTip gameAbbreviationToolTip = new ToolTip();

            gameAbbreviationToolTip.AutoPopDelay = 5000;
            gameAbbreviationToolTip.InitialDelay = 1000;
            gameAbbreviationToolTip.ReshowDelay = 500;
            gameAbbreviationToolTip.ShowAlways = true;

            gameAbbreviationToolTip.SetToolTip(this.GameAbbreviationCheck, "(ex: CTA 1 (original) -> The Adventures of Catto Boi (original))");

            debugLevelSelection.Items.Add("None");
            debugLevelSelection.Items.Add("Error");
            debugLevelSelection.Items.Add("Verbose");

            GameAbbreviationCheck.Checked = Main.GlobalSettings.GameAbbreviationSetting;
            debugLevelSelection.SelectedItem = Main.GlobalSettings.DebugLevel;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = Environment.GetEnvironmentVariable("USERNAME");
            FileIniDataParser parser = new FileIniDataParser();
            string settingsIniPath = "C:\\Users\\" + username + "\\AppData\\Local\\CTACheat2\\settings.ini";
            string settingsDirPath = "C:\\Users\\" + username + "\\AppData\\Local\\CTACheat2";


            IniData settingsData = parser.ReadFile(settingsIniPath);
            settingsData["CTACheat2"]["GameAbbreviationSetting"] = GameAbbreviationCheck.Checked.ToString();
            settingsData["CTACheat2"]["DebugConsoleSetting"] = debugConsoleCheck.Checked.ToString();

            switch (debugLevelSelection.Text)
            {
                case "None":
                    settingsData["CTACheat2"]["DebugLevel"] = "none";
                    break;
                case "Error":
                    settingsData["CTACheat2"]["DebugLevel"] = "error";
                    break;
                case "Verbose":
                    settingsData["CTACheat2"]["DebugLevel"] = "verbose";
                    break;
            }

            parser.WriteFile(settingsIniPath, settingsData);

            MessageBox.Show("For now, you need to restart the application to reflect the changes made in the settings window.", "CTACheat2: Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
