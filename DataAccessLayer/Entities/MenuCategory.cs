using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class MenuCategory:BaseEntity
    {
        public string Name { get; set; }

        public List<Menu> Menus { get; set; }   
    }
}
