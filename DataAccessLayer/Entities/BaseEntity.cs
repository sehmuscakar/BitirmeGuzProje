


using CoreLayer.Entities;

namespace DataAccessLayer.Entities
{
    public class BaseEntity:IEntity 
    {
        public int Id { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public int RowOrder { get; set; }
        public int? AppUserId { get; set; } 
        public virtual AppUser AppUser { get; set; }  

    }
}
