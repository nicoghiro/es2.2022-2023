using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace es2._2022_2023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int recordlenght = 528;
            var f = new FileStream(@"./veneto_verona.csv", FileMode.Open, FileAccess.ReadWrite);
            int tot = ((int)(f.Length));
            int linee = tot / recordlenght+1;
            string line = Convert.ToString(linee);
            MessageBox.Show(line);
            f.Close();
        }
    }
}
