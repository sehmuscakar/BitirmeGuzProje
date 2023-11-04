using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
   public class BusinessModule:BaseEntity
    {
        public string ImageUrl { get; set; }
        public string AboutTitle { get; set; }
        public string About { get; set; }
        public string MissionTitle { get; set; }
        public string Mission { get; set; }
        public string VisionTitle { get; set; }
        public string Vision { get; set; }
    }
}
