using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DataAccess.Entities
{
    public class LegoProductStatus
    {
        [Key]
        [Required]
        public int ProductStatusID { get; set; }

        [StringLength(100)]
        public string ProductStatusName { get; set; }
    }
}
