using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GestionEtudiantWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Autoriser les protocoles sécurisés et contourner la validation des certificats SSL auto-signés locaux (localhost)
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            InitializeComponent();
            ChargerEtudiant();
        }

        private async void ChargerEtudiant()
        {
            /*
                Utilisation de try-catch pour gérer les exceptions potentielles lors de la connexion à l'API 
                et lors de la désérialisation des données reçues de l'API.
                Cela permet d'afficher des messages d'erreur appropriés
                à l'utilisateur en cas de problème de connexion ou de données invalides.
             */


            try
            {
                HttpClient client = new HttpClient();
                string url = "https://localhost:44300/api/etudiants";
                var response = await client.GetStringAsync(url);
                var liste = JsonConvert.DeserializeObject<List<Etudiant>>(response);
                dgEtudiant.DataSource = liste;
            }
            catch (HttpRequestException ex){  
                MessageBox.Show("Erreur de connexion à l'API : " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue : " + ex.Message);
            }
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var Etudiant = new Etudiant
            {
                NomEtudiant = txtNom.Text,
                PrenomEtudiant = txtPrenom.Text,
                EmailEtudiant = txtEmail.Text,
            };

            var json = JsonConvert.SerializeObject(Etudiant);
            var content = new StringContent(
                json, 
                Encoding.UTF8, 
                "application/json"
                );

            await client.PostAsync("https://localhost:44300/api/etudiants", content);
            ChargerEtudiant();

        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            int id = Convert.ToInt32(dgEtudiant.CurrentRow.Cells[0].Value);
            var Etudiant = new Etudiant
            {
                IdEtudiant = id,
                NomEtudiant = txtNom.Text,
                PrenomEtudiant = txtPrenom.Text,
                EmailEtudiant = txtEmail.Text,
            };
            var json = JsonConvert.SerializeObject(Etudiant);
            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
                );
            await client.PutAsync($"https://localhost:44300/api/etudiants/{id}", content);
            ChargerEtudiant();
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            int id = Convert.ToInt32(dgEtudiant.CurrentRow.Cells[0].Value);
            await client.DeleteAsync($"https://localhost:44300/api/etudiants/{id}");
            ChargerEtudiant();

        }

        private void dgEtudiant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNom.Text = dgEtudiant.CurrentRow.Cells[1].Value.ToString();
            txtPrenom.Text = dgEtudiant.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dgEtudiant.CurrentRow.Cells[3].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
