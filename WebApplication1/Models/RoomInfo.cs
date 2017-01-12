using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RoomInfo
    {
        [Key]
        public int ID { get; set; }
        public int Master { get; set; }
        public string Roomname { get; set; }
        public Roomsort sort { get; set; }
    }
    public enum Roomsort
    {
        entertainment,
        study,
        Encyclopedias,
        outdoors
    }
   
}