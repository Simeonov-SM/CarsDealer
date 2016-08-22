using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CARS_DEALER.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int brand_Id { get; set; }
        [ForeignKey("brand_Id")]
        Brand brand { get; set;  }

        public string modelName { get; set; }

        [Required]
        public int yearOfProduct { get; set; }

        [Required]
        public decimal price { get; set; }
        public int kilometers { get; set; }
        public int engine_Id { get; set; }
        [ForeignKey("engine_Id")]
        public Engine engineType { get; set; }

        public int area_Id { get; set; }
        [ForeignKey("area_Id")]
        public Area areaName { get; set; }


        public int engineVolume { get; set; }

        public int power { get; set; }

        public int coupe_Id { get; set; }
        [ForeignKey("coupe_Id")]
        public Coupe coupeType { get; set; }

        public int doors_Id { get; set; }
        [ForeignKey("doors_Id")]
        public Doors doorsType { get; set; }

        public int gears_Id { get; set; }
        [ForeignKey("gears_Id")]
        public GearBox gearBox { get; set; }
        public bool elWindows { get; set; }
        public bool airBagsFront { get; set; }
        public bool airBagsRear { get; set; }
        public bool airBagsSide { get; set; }
        public bool bordComputer { get; set; }
        public string email { get; set; }

        public string phone { get; set; }

        public bool clima { get; set; }

        public bool parktronic { get; set; }
        public bool ABS { get; set; }
        public bool leather { get; set; }
        public bool tempomat { get; set; }
        public bool GPS { get; set; }
        public bool DPF { get; set; }

        public bool ESP { get; set; }

        public bool LPG { get; set; }
        public bool isSold { get; set; }

        [DataType(DataType.MultilineText)]
        public string description { get; set; }


        [Required]
        
        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime EditDate { get; set; }

        public string Author_Id { get; set; }

        [ForeignKey("Author_Id")]
        public ApplicationUser Author { get; set; }

       
       public Post()
        {
            this.date = DateTime.Now;
        }

    }
}