using Renewable_Energy_Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewable_Energy_Entities
{
    public class ProjectBlogRelation : Entity
    {
        public int BlogId { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
