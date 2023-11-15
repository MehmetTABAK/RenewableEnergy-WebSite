using Renewable_Energy_Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewable_Energy_Entities.DTOs
{
    public class ProjectCategoryDTO : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public int? ReferenceId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
