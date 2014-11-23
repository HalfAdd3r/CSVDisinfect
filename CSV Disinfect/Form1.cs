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
            UseOpenDialog();
        }


        private void UseOpenDialog()
        {
            // Get Users Downloads Path and set as variable
            var envPath = @"%USERPROFILE%\Downloads";
            var filePath = Environment.ExpandEnvironmentVariables(envPath);

            // Open File and set global
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = filePath;
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";

            // After click "open" in dialog
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    readFile(openFileDialog1.OpenFile());
                } // end Try
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                } // end catch
            } // Dialog okay
        } // end UseOpenDialog



        private void readFile(Stream strmFile)
        {
            if (strmFile != null) // not empty
            {
                MessageBox.Show("value found");
                TextReader reader = new StreamReader(strmFile);
                while (strmFile.)
                MessageBox.Show(reader.ReadLine());
                //for (; ; )
                //{
                //    string s = reader.ReadLine();
                //    if (s == null)
                //        break;
                //    s = s.Replace(" ", ", ");
                //    s = "{" + s + "},";
                //    writer.WriteLine(s);
                //}

                strmFile.Close();
            }

            //TextReader reader = new StreamReader("triangle.txt");
            //TextWriter writer = new StreamWriter("triangle2.txt");
            //for (; ; )
            //{
            //    string s = reader.ReadLine();
            //    if (s == null)
            //        break;
            //    s = s.Replace(" ", ", ");
            //    s = "{" + s + "},";
            //    writer.WriteLine(s);
            //}
        } // end readFile


    } // End Form1
}
