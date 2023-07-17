using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace memo_tool
{
    public partial class memo : Form
    {
        public memo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var ofd = new OpenFileDialog()
            {
                FileName = "Folder Selection",
                Filter = "Folder|.",
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
            }
            )
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = Path.GetDirectoryName(ofd.FileName);
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("フォルダを設定しましょう");
            }
            else
            {
                string fileName = @textBox1.Text + @"\memo.csv";
                DateTime dt1 = DateTime.Now;
                string d = dt1.ToString("yyyy/MM/dd HH:mm:ss");
                // 追記
                if (System.IO.File.Exists(fileName))
                {
//                    File.AppendAllText(@fileName, d + " " + textBox2.Text + "," + Environment.NewLine);
                    File.AppendAllText(@fileName, textBox2.Text + "," + textBox3.Text + Environment.NewLine);
                }
                // 新規作成
                else
                {
 //                   File.WriteAllText(@fileName, d + " " + textBox2.Text + "," + Environment.NewLine);
                    File.AppendAllText(@fileName, textBox2.Text + "," + textBox3.Text + Environment.NewLine);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fileName = @textBox1.Text + @"\memo.csv";
            if (System.IO.File.Exists(fileName))
            {
                ProcessStartInfo pInfo = new ProcessStartInfo();
                pInfo.FileName = "code";
                pInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pInfo.Arguments = fileName;
                Process.Start(pInfo);
            }
            else{
                MessageBox.Show("'" + fileName + "'は存在しません。");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
