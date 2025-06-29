using System.Diagnostics;

namespace CTACheat2
{
    public partial class Acknowledgements : Form
    {
        public Acknowledgements()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(linkLabel1.Text) { UseShellExecute = true });
        }
    }
}
