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
        public int Software_houseId { get; set; }
        public virtual Sofware_houses software_house { get; set; }
        
        public Videogame() { }
        public Videogame(int id , string name, string overview, string descrizione, int software_house_id)
        {
            this.id = id;
            this.Name = name;
            this.Overview = overview;
            this.Descrizione = descrizione;
            this.Software_houseId = software_house_id;
        }
        
    }

    public class Sofware_houses
    {

        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<Videogame> Videogamens { get; set; }
        
        public Sofware_houses() { }
        Sofware_houses(int id, string name, string city)
        {
            this.Id = id;
            this.Name = name;
            this.City = city;
        }
        

    }

    }