using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.VieModels
{
    public class ViewUser
    {
        public User User { get; set; }

        public ICollection<ViewMessage> Messages { get; set; }

        public ICollection<string> UsersNames { get; set; }

        public int Id { get; set; }
    }
}