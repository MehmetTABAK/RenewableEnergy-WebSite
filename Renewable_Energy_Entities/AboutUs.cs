using Renewable_Energy_Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewable_Energy_Entities
{
    public class AboutUs : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
        public string Email { get; set; }
        public long Number { get; set; }
        public string WorkingTimes { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
    }
}
