using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testapp.Properties;

namespace testapp
{
    public partial class Form1 : Form
    {

        private static string[] files = Directory.GetFiles("C:\\Users\\Angela\\source\\repos\\testapp\\testapp\\Resources");
        private static Random rng = new Random();
        public Form1()
        {
            
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnClosed(EventArgs e)
        {
            
            base.OnClosed(e);
            this.Dispose();
            int temp = rng.Next(files.Length - 1);
            Form1 f = new Form1();
            f.pictureBox1.ImageLocation = files[temp];
            f.ShowDialog();
        }

    }
}
