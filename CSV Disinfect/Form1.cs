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
using System.Text.RegularExpressions;


namespace CSV_Disinfect
{
    public partial class Form1 : Form
    {
        private String strFileName;
        private Stream strmInputFile;


        public Form1()
        {
            InitializeComponent();
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            UseOpenDialog();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFile();
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
                    strFileName = openFileDialog1.FileName;
                    strmInputFile = openFileDialog1.OpenFile();
                    btnClean.Enabled = true;
                } // end Try
                
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                } // end catch
            } // Dialog okay
        } // end UseOpenDialog



        private void CleanFile()
        {
            string strLine;
            string strNewFile;
            Regex rgx;

            // Create New Filename for writing
            strNewFile = strFileName;
            strNewFile = strNewFile.Insert(strNewFile.Length - 4, "_cleaned");
            rgx = new Regex("[^\\w\\d, ]"); // Allow letters, numbers, comma, and spaces only

            if (strmInputFile != null) // not empty
            {
                TextReader reader = new StreamReader(strmInputFile);
                TextWriter writer = new StreamWriter(strNewFile);
                
                // Main Working Loop
                while ((strLine = reader.ReadLine()) != null)
                {
                    MessageBox.Show(strLine);

                    writer.WriteLine(rgx.Replace(strLine," "));
                }

                // Cleanup
                reader.Close();
                writer.Close();
                btnClean.Enabled = false;
                strmInputFile = null;
                strFileName = null;

                // Exit Msg
                MessageBox.Show("New File Generated");
            } // end if
        } // End Clean File


    } // End Form1
}
