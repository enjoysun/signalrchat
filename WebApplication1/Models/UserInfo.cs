using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserInfo
    {
        [Key]
        public int ID { get; set; }
        public string Nickname { get;set;}
        public string Realname { get; set; }

    }
}