using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taxi.Areas.Admin
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddEmpl().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddCars().ShowDialog();
        }


        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.autarization.Show();
        }
    }
}
