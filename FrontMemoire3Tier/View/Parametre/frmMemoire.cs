using FrontMemoire3Tier.ServiceMemoire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontMemoire3Tier.View.Parametre
{
    public partial class frmMemoire : Form
    {
        readonly ServiceMemoire.Service1Client service = new ServiceMemoire.Service1Client();
        public frmMemoire()
        {
            InitializeComponent();
        }

        private void Effacer()
        {
            txtAnnee.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtSujet.Text = String.Empty;
            dgMemoire.DataSource = service.GetAllMemoire();
            txtSujet.Focus();
        }

        private void frmMemoire_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
           ServiceMemoire.Memoire memoire = new ServiceMemoire.Memoire();
            memoire.AnneeMemoire = int.Parse(txtAnnee.Text);
            memoire.SujetMemoire = txtSujet.Text;
            memoire.DescriptionMemoire = txtDescription.Text;
            service.AddMemoire(memoire);
            Effacer();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ServiceMemoire.Memoire memoire = new ServiceMemoire.Memoire();
            memoire.AnneeMemoire = int.Parse(txtAnnee.Text);
            memoire.SujetMemoire = txtSujet.Text;
            memoire.DescriptionMemoire = txtDescription.Text;
            service.EditMemoire(memoire);
            Effacer();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ServiceMemoire.Memoire memoire = new ServiceMemoire.Memoire();
            memoire.AnneeMemoire = int.Parse(txtAnnee.Text);
            memoire.SujetMemoire = txtSujet.Text;
            memoire.DescriptionMemoire = txtDescription.Text;
            service.DeleteMemoire(memoire);
            Effacer();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ServiceMemoire.MemoireModel memoire = new ServiceMemoire.MemoireModel();
            memoire.AnneeMemoire = int.Parse(txtAnnee.Text);
            memoire.SujetMemoire = txtSujet.Text;
            service.GetMemoireList(memoire);
            Effacer();
        }
    }
}
