using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetierMemoire.Model
{
    public class Memoire
    {
        [Key]
        public int IdMemoire { get; set; }

        [Required, MaxLength(2000)]
        public string SujetMemoire { get; set; }
        [Required, MaxLength(100000)]
        public string DescriptionMemoire { get; set; }
        [Required] 
        public int AnneeMemoire { get; set; }
    }
    /// <summary>   
    /// DTO de la classe Memoire, pour le transfert des données entre les couches de l'application    
    /// </summary>
    public class MemoireModel
    {
        public string SujetMemoire { get; set; }

        public int AnneeMemoire { get; set; }
    }
}