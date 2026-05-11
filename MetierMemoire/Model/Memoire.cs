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
        public int IDMemoire { get; set; }


        [Required, MaxLength(2000)]
        public string SujetMemoire { get; set; }


        [Required, MaxLength(100000)]
        public string DescriptionMemoire { get; set; }


        [Required]
        public int AnneeMemoire { get; set; }

    }

    public class MemoireModel
    {
        [Required, MaxLength(2000)]
        public string SujetMemoire { get; set; }


        [Required, MaxLength(100000)]
        public string DescriptionMemoire { get; set; }


        [Required]
        public int AnneeMemoire { get; set; }
    }
}