using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTACheat2
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LicenseBox licenseForm = new LicenseBox();
            licenseForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acknowledgements AcknowledgementForm = new Acknowledgements();
            AcknowledgementForm.Show();
        }
    }
}
