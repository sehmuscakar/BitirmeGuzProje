using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.AdminDtos
{
    public class HeroListDto:AdminBaseDto
    {
        public string Title1 { get; set; }
        public string Title2 { get; set; }

        public string Description { get; set; }
    }
}
