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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        byte[] res = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void encrypt_button_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text == "")
            {
                MessageBox.Show("Choose input file");
                return;
            }

            string key = key_textBox.Text;
            if (key.Length < 32)
            {
                MessageBox.Show("Key length is less than 16 bytes");
                return;
            }
            else if (key.Length < 64)
                key = key.Substring(0, 32);
            string nonce = nonce_textBox.Text;
            if (nonce.Length < 16)
            {
                MessageBox.Show("Nonce length is less than 8 bytes");
                return;
            }

            byte[] key_bytes = StringToByteArray(key);

            Salsa20 salsa = new Salsa20(key_bytes);
            
            byte[] nonce_bytes = StringToByteArray(nonce);
            byte[] message = File.ReadAllBytes(input_textBox.Text);
            save_button.Enabled = false;
            res = salsa.encrypt(message, nonce_bytes);
            MessageBox.Show("Complete");
            save_button.Enabled = true;
        }

        private void upload_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.Cancel)
                return;
            input_textBox.Text = dialog.FileName;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = dialog.FileName;
            File.WriteAllBytes(filename, res);
        }

        private void key_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) &&
                (e.KeyChar < 65 || e.KeyChar > 70) && (e.KeyChar < 97 || e.KeyChar > 102))
                e.Handled = true;
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
