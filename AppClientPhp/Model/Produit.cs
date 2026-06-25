using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClientPhp.Model
{
    public class Produit
    {
        [JsonProperty("id")] 
        public int Id { get; set; }
        [JsonProperty("nom")] 
        public string Nom { get; set; }
        [JsonProperty("prix")] 
        public decimal Prix { get; set; }
        [JsonProperty("quantite")] 
        public int Quantite { get; set; }
    }
}
