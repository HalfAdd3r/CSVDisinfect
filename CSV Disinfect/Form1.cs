using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Disinfect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Get Users Downloads Path and set as variable
            var envPath = @"%USERPROFILE%\Downloads";
            var filePath = Environment.ExpandEnvironmentVariables(envPath);
            
            // Open File and set global
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = filePath;
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            
            openFileDialog1.ShowDialog();


            TextReader reader = new StreamReader("triangle.txt");
            TextWriter writer = new StreamWriter("triangle2.txt");
            for (; ; )
            {
                string s = reader.ReadLine();
                if (s == null)
                    break;
                s = s.Replace(" ", ", ");
                s = "{" + s + "},";
                writer.WriteLine(s);
            }

        }
    }
}
