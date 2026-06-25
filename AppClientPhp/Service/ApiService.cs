using AppClientPhp.Model;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppClientPhp.Service
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "http://localhost/api/produits.php";
        public ApiService()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromSeconds(30);
            Log.Debug("ApiService initialise — BaseUrl: {BaseUrl}", BaseUrl);
        }
        public async Task<List<Produit>> GetAllAsync()
        {
            Log.Information("GET tous les produits");
            try
            {
                var response = await _client.GetStringAsync(BaseUrl);
                var produits = JsonConvert.DeserializeObject<List<Produit>>(response);
                Log.Information("{Count} produit(s) recupere(s)", produits.Count);
                return produits.ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de GetAllAsync");
                throw;
            }
        }
        public async Task<bool> CreateAsync(Produit produit)
        {
            Log.Information("POST creation: {@Produit}", produit);
            try
            {
                var json = JsonConvert.SerializeObject(produit);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(BaseUrl, content);
                if (response.IsSuccessStatusCode)
                    Log.Information("Produit cree avec succes");
                else Log.Warning("Creation echouee — StatusCode: {Code}", response.StatusCode);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur CreateAsync"); throw;
            }
        }     // ... UpdateAsync, DeleteAsync : meme pattern 
    }


}
