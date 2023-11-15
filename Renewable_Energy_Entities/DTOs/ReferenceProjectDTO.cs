using Renewable_Energy_Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewable_Energy_Entities.DTOs
{
    public class ReferenceProjectDTO : Entity
    {
        public string ReferenceName { get; set; }
        public string ReferenceImageUrl { get; set; }
        public string ProjectName {  get; set; }
    }
}
