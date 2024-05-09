using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class sofware_houses
    {
        
        [Key]public int Id { get; set; }
        public string Name { get; set; }
        public string  City { get; set; }
        public List<Videogamens> Videogamens { get; set; } = new List<string>();

        sofware_houses(int id, string name , string city)
        { 
            this.Id = id;
            this.Name = name;
            this.City = city;
        }
    }
}
