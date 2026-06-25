using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIText.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("connEtudiant")
        {
            
        }
        public DbSet<Etudiant> Etudiants { get; set; }
    }
}