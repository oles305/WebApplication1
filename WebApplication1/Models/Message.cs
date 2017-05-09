using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int Id_user { get; set; }

        [MaxLength(500)]
        public string MessageText { get; set; }

        public DateTime MessageDate { get; set; }
    }
}