using Renewable_Energy_Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewable_Energy_Entities
{
    public class Blog : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public DateTime Time { get; set; }
        public string Writer {  get; set; }
        public ICollection<ProjectBlogRelation> Projects { get; set; }
        public virtual BlogCategory Category { get; set; }
    }
}
