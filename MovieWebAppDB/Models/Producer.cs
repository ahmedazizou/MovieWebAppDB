using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieWebAppDB.Models
{
    public class Producer
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
 
        //Relationships
        public List<Movie> Movies { get; set; }
    }
}