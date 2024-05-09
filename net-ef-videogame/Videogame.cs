using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_ef_videogame
{
    [Table("videogames")]
    public class Videogame
    {
        [Key]public int id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string Descrizione { get; set; }
        public int Software_house_id { get; set; }
        public Software_house software_House { get; set; }

        public Videogame(int id , string name, string overview, string descrizione, int software_house_id)
        {
            this.id = id;
            this.Name = name;
            this.Overview = overview;
            this.Descrizione = descrizione;
            this.Software_house_id = software_house_id;
        }
    }     
}