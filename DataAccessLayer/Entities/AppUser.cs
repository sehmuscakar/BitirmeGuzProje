using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities
{
    public class AppUser:IdentityUser<int> 
 
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int ConfirmCode { get; set; }//onay kodu,mail doğrulama işlemi için kullanılacak ,migration olduğunda migration da nullable yi true yaptık ayrıntı
     
       public List<ContactCompany> contactCompanies { get; set; }
       public List<Hero> Heroes { get; set; }
       public List<BusinessModule> BusinessModules { get; set; }
        public List<Menu> Menus { get; set; }
        public List<MenuCategory> MenuCategories { get; set; }
        public List<Service> Services { get; set; }
        public List<Gallery> Galleries { get; set; }
        public List<Team> Teams { get; set; }


    }
}
