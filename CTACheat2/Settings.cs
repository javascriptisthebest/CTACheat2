using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = Environment.GetEnvironmentVariable("USERNAME");
            FileIniDataParser parser = new FileIniDataParser();
            string settingsIniPath = "C:\\Users\\" + username + "\\AppData\\Local\\CTACheat2\\settings.ini";
            string settingsDirPath = "C:\\Users\\" + username + "\\AppData\\Local\\CTACheat2";


            IniData settingsData = parser.ReadFile(settingsIniPath);
            settingsData["CTACheat2"]["GameAbbreviationSetting"] = GameAbbreviationCheck.Checked.ToString();

            parser.WriteFile(settingsIniPath, settingsData);

            this.Close();
        }
    }
}
