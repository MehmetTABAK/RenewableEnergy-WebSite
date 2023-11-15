using Renewable_Energy_Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewable_Energy_Entities
{
    public class ProjectCategory : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Project> Projects { get; set;}
    }
}
