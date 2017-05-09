using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.VieModels
{
    public class ViewMessage
    {
        public string UserName { get; set; }

        public string MessageText { get; set; }

        public DateTime MessageDate { get; set; }

        public int Id { get; set; }
    }
}