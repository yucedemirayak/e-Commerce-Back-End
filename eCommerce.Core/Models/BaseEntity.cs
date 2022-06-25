
namespace eCommerce.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime UpdatedTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}