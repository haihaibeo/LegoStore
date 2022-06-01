using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DataAccess.Entities
{
    public class LegoProduct
    {
        public LegoProduct()
        {
            ProductThemes = new HashSet<LegoProductTheme>();
        }

        [Key]
        [Required]
        [StringLength(50)]
        public string ProductID { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string ProductDisplayName { get; set; }

        [Precision(10, 2)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public int ProductStatusID { get; set; }

        public virtual ICollection<LegoProductTheme> ProductThemes { get; set; }

        public virtual ICollection<Theme> Themes { get; set; }
    }
}
