using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Library.Models
{
    public class Kid
    {
        public int KidID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsValidNew()
        {
                return (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email));
        }

        public bool IsValidUpdate()
        {
            return ((KidID > 0) && IsValidNew());
        }
    }
}
