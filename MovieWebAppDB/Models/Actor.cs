using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieWebAppDB.Models
{
    public class Actor
    {

        [Key]
        public int Id { get; set; }


        public string Name { get; set; }
        public int Age { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
   
}