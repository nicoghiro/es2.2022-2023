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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string p = textBox1.Text;
            p.ToUpper();
            int recordlenght = 528;
            var f = new FileStream(@"./veneto_verona.csv", FileMode.Open, FileAccess.ReadWrite);
            int tot = ((int)(f.Length));
            int linee = tot / recordlenght + 1;
            string line = Convert.ToString(linee);
            MessageBox.Show(line);
            f.Close();
            comune a = Getstring(linee / 2);
            int n = linee;
            int j = linee - 1 , pos = -1, i=0 , m;
            do
            {
                m = (i + j) / 2;
                if (a[m] == x)
                    pos = m;
                else if (a[m] < x)
                    i = m + 1;
                else
                    j = m - 1;

            } while (i <= j && pos == -1);



        }
        public static comune Getstring(int line)
        {
            string linea;
            byte[] br;
            var f = new FileStream(@"./veneto_verona.csv", FileMode.Open, FileAccess.ReadWrite);
            f.Seek(line * 528, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(f);
            br = reader.ReadBytes(528);
            linea = Encoding.ASCII.GetString(br, 0, br.Length);
            string[] com = linea.Split(';');
            comune post;
            post.posto = com[0];
            post.modalità = com[2];
            return post;
            

        }
      public struct comune
    {
       public string posto;
        public string modalità;
    }
    }
    
}
