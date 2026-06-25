using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace MetierMemoire.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdMemoireContext : DbContext
    {
        public BdMemoireContext() : base("connMemoire")
        {
            Database.SetInitializer<BdMemoireContext>(null);
        }
        public DbSet<Memoire> Memoires { get; set; }

    }
}