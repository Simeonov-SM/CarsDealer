using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CARS_DEALER.Models
{
    
  public  class Brand
    {
        public int id { get; set; }
        public string brandName { get; set; }
        
    }
    public class BrandModel
    {
        
        public int id { get; set; }
        
        public string modelName { get; set; }
        public int brand_Id { get; set; }
        [ForeignKey("brand_Id")]
        public Brand brand { get; set; }

    }
    
    public class Area
    {
        public int id { get; set; }
        [Required]
        public string area { get; set; }
    }
    public class Engine
        {
            public int id { get; set; }
            public string engineType { get; set; }
        }
        public class Coupe
        {
            public int id { get; set; }
            public string coupeType { get; set; }
        }
        public class GearBox
        {
            public int id { get; set; }
            public string gearType { get; set; }
        }
        public class Doors
        {
            public int id { get; set; }
            public string doors { get; set; }
        }
       
    
    }
   
