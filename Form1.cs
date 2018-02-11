using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTPManager;

namespace FTPManagerApp
{
    public partial class Form1 : Form
    {
        FTPManagerClass client;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            client = new FTPManagerClass(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = client.getFilesOnServer("");
            foreach(string filename in files)
            {
                dataGridView1.Rows.Add(filename);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string ext = textBox4.Text.Substring(textBox4.Text.Length - 4, 4);
            sfd.Filter = "Download file extension(" + ext + ")|*" + ext;
            if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox5.Text = sfd.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.DownloadFile(textBox4.Text, textBox5.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files | *.*";
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox6.Text = ofd.FileName;
                textBox7.Text = ofd.SafeFileName;
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            client.UploadFile(textBox6.Text, textBox7.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            client.Rename(textBox9.Text, textBox8.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            client.CreateDir(textBox10.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value).Contains("."))
            {
                return;
            }
            else
            {
                string[] files = client.getFilesOnServer(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                dataGridView1.Rows.Clear();
                foreach (string file in files)
                {
                    dataGridView1.Rows.Add(file);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
