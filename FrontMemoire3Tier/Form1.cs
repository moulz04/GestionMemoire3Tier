using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontMemoire3Tier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceMemoire.Service1Client service=new ServiceMemoire.Service1Client();

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(service.GetData(15));
        }
    }
}
