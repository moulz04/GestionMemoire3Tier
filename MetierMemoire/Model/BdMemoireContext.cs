
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MetierMemoire.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdMemoireContext:DbContext
    {


        public BdMemoireContext() : base("name=connMemoire")
        {
        }

        public DbSet<Memoire> Memoires { get; set; }
    }
}