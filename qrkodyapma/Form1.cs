using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qrkodyapma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          comboBox1.SelectedIndex = 0;
            dateTimePicker1.Value= new DateTime(2000,01,01);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            StringBuilder qrbuild=new StringBuilder();
            qrbuild.Append(textBox1.Text);
            qrbuild.AppendLine();
            qrbuild.Append(dateTimePicker1.Value.ToString());
            qrbuild.AppendLine();
            qrbuild.Append(comboBox1.Text);
            qrbuild.AppendLine();
            qrbuild.Append("http://" + textBox2.Text);
            pictureBox1.Image=QrCodeCreate(qrbuild.ToString());


        }
        public Image QrCodeCreate(String Cev)
        {
            QRCodeEncoder encoder= new QRCodeEncoder();
            Image img=encoder.Encode(Cev);
            return img;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog=new SaveFileDialog();
            saveDialog.InitialDirectory = Application.ExecutablePath;
            saveDialog.Title = "QR CODE WILL BE SAVED.";
            saveDialog.Filter = "Png Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp";
            saveDialog.DefaultExt = "*.png";
            saveDialog.FileName=DateTime.Now.ToString();

            if (saveDialog.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image.Save(saveDialog.FileName);
                Process.Start(saveDialog.FileName); 

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            QRCodeDecoder decoder=new QRCodeDecoder();
            Bitmap btmp= (Bitmap)pictureBox1.Image;
            MessageBox.Show(decoder.Decode(new QRCodeBitmapImage(btmp)), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
