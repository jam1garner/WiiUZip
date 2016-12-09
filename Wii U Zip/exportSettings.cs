using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wii_U_Zip
{
    public partial class exportSettings : Form
    {
        public exportSettings(Settings s)
        {
            InitializeComponent();
            settings = s;
        }

        Settings settings;

        private void button1_Click(object sender, EventArgs e)
        {
            settings.bigEndian = bigEndianCheck.Checked;
            settings.offset = (int)numericUpDown1.Value;
            settings.flags = Convert.ToInt32(textBox1.Text, 16);
            settings.save = true;
            Close();
        }

        private void exportSettings_Load(object sender, EventArgs e)
        {
            bigEndianCheck.Checked = settings.bigEndian;
        }
    }

    public class Settings
    {
        public bool save = false;
        public bool bigEndian = true;
        public int offset = 0x2000;
        public int flags;
    }
}
