using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique =true)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Pasword { get; set; }
    }
}