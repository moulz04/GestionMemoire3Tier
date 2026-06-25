using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIText.Models
{
    public class Etudiant
    {
        [Key]
        public int IdEtudiant { get; set; }
        [Required,MaxLength(40)]
        public string NomEtudiant { get; set; }
        [Required,MaxLength(50)]
        public string PrenomEtudiant { get; set; }
        [Required ,MaxLength(60)]
        public string EmailEtudiant { get; set; }
    }
}