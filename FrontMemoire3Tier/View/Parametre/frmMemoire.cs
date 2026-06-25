using System;
using System.Windows.Forms;

namespace FrontMemoire3Tier.View.Parametre
{
    public partial class frmMemoire : Form
    {
        ServiceMemoire.Service1Client service = new ServiceMemoire.Service1Client();

        public frmMemoire()
        {
            InitializeComponent();
            btnSelectionner.Click += btnSelectionner_Click;
            btnRechercher.Click += btnRechercher_Click;
            dgMemoire.CellDoubleClick += dgMemoire_CellDoubleClick;
        }

        private void Effacer()
        {
            txtAnneeMemoire.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtSujet.Text = string.Empty;
            dgMemoire.DataSource = service.GetAllMemoire();
            txtSujet.Focus();
        }

        private void frmMemoire_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int annee;
            if (!int.TryParse(txtAnneeMemoire.Text, out annee))
            {
                MessageBox.Show("Veuillez saisir une année valide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSujet.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Le sujet et la description ne peuvent pas être vides.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ServiceMemoire.Memoire memoire = new ServiceMemoire.Memoire();
            memoire.AnneeMemoire = annee.ToString();
            memoire.DescriptionMemoire = txtDescription.Text;
            memoire.SujetMemoire = txtSujet.Text;

            if (service.AddMemoire(memoire))
            {
                MessageBox.Show("Mémoire ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Effacer();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout du mémoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgMemoire.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un mémoire dans le tableau à modifier.", "Sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int annee;
            if (!int.TryParse(txtAnneeMemoire.Text, out annee))
            {
                MessageBox.Show("Veuillez saisir une année valide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSujet.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Le sujet et la description ne peuvent pas être vides.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ServiceMemoire.Memoire memoire = new ServiceMemoire.Memoire();
            memoire.IdMemoire = Convert.ToInt32(dgMemoire.CurrentRow.Cells["IdMemoire"].Value);
            memoire.AnneeMemoire = annee.ToString();
            memoire.DescriptionMemoire = txtDescription.Text;
            memoire.SujetMemoire = txtSujet.Text;

            if (service.UpdateMemoire(memoire))
            {
                MessageBox.Show("Mémoire modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Effacer();
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification du mémoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgMemoire.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgMemoire.CurrentRow.Cells["IdMemoire"].Value);
                
                var result = MessageBox.Show("Voulez-vous vraiment supprimer ce mémoire ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (service.DeleteMemoire(id))
                    {
                        MessageBox.Show("Mémoire supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Effacer();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression du mémoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un mémoire à supprimer.", "Sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (dgMemoire.CurrentRow != null)
            {
                txtSujet.Text = dgMemoire.CurrentRow.Cells["SujetMemoire"].Value?.ToString();
                txtDescription.Text = dgMemoire.CurrentRow.Cells["DescriptionMemoire"].Value?.ToString();
                txtAnneeMemoire.Text = dgMemoire.CurrentRow.Cells["AnneeMemoire"].Value?.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.", "Sélection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            ServiceMemoire.Memoire memoire = new ServiceMemoire.Memoire();
            memoire.SujetMemoire = txtSujet.Text;
            memoire.DescriptionMemoire = txtDescription.Text;

            if (!string.IsNullOrWhiteSpace(txtAnneeMemoire.Text))
            {
                int annee;
                if (int.TryParse(txtAnneeMemoire.Text, out annee))
                {
                    memoire.AnneeMemoire = annee.ToString();
                }
                else
                {
                    MessageBox.Show("Si vous spécifiez une année pour la recherche, elle doit être valide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                var result = service.GetMemoireList(memoire);
                dgMemoire.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de recherche : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgMemoire_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelectionner_Click(sender, e);
        }
    }
}
