using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace net_ef_videogame
{
    public class VideogamesContext : DbContext
    {
        public DbSet<Videogame> videogames {  get; set; }
        public DbSet<Sofware_houses> sofware_Houses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=videogames;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
