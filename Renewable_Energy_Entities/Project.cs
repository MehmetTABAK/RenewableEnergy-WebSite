using Renewable_Energy_Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewable_Energy_Entities
{
    public class Project : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public int? ReferenceId { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<ProjectBlogRelation> Blogs { get; set; }
        public virtual ProjectCategory Category {  get; set; }
        public virtual Reference Reference { get; set; }
    }
}
