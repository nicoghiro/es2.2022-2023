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

        private int ricerca(string filename = @"./veneto_verona.csv")
        {
            textBox1.Text = textBox1.Text.Trim();
            string x = textBox1.Text.ToUpper();                    
            int recordlenght = 529;
            var f = new FileStream(@"./veneto_verona.csv", FileMode.Open, FileAccess.ReadWrite);
            int tot = ((int)(f.Length));
            int linee = tot / recordlenght + 1;
           
            f.Close();
            comune a = Getstring(linee / 2);
            int n = linee;
            int j = linee - 1 , pos = -1, i=0 , m;
            do
            {
                m = (i + j) / 2;
                a=Getstring(m);
                
                int result = string.Compare(a.posto, x);
                if (a.posto == x) { 
                    
                    return m;
                }
                
                else if (result==-1) { 
                    i = m + 1;
                }
                else { 
                    j = m - 1;
                }

            } while (i <= j && pos == -1);
            
            if (pos == -1) { 
                MessageBox.Show("Comune non trovato");
                return 3000;
            }
            return 0;


        }
        public static comune Getstring(int line)
        {
            string linea;
            byte[] br;
            var f = new FileStream(@"./veneto_verona.csv", FileMode.Open, FileAccess.ReadWrite);
            f.Seek(line * 529, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(f);
            br = reader.ReadBytes(529);
            linea = Encoding.ASCII.GetString(br, 0, br.Length);
            string[] com = linea.Split(';');
            comune post;
            post.posto = com[0];
            post.modalità = com[7];
            f.Close();
            return post;
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int posto = ricerca();
            string postonum = Convert.ToString(posto);
            MessageBox.Show(postonum);
            byte[] br;
            var f = new FileStream(@"./veneto_verona.csv", FileMode.Open, FileAccess.ReadWrite);
            f.Seek(posto * 529, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(f);
            br = reader.ReadBytes(529);
            string linea = Encoding.ASCII.GetString(br, 0, br.Length);
            string[] com = linea.Split(';');
            comune post;
            post.posto = com[0];
            post.modalità = com[7];
            f.Close();
            MessageBox.Show( post.modalità);


        }
      public struct comune
    {
       public string posto;
        public string modalità;
    }
    }
    
}
