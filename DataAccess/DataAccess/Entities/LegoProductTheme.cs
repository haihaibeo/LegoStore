using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    public class LegoProductTheme
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string ProductThemeID { get; set; }

        [ForeignKey(nameof(Product))]
        [Required]
        [StringLength(50)]
        public string ProductID { get; set; }

        [ForeignKey(nameof(Theme))]
        [Required]
        public int ThemeID { get; set; }

        public virtual LegoProduct Product { get; set; }

        public virtual Theme Theme { get; set; }
    }
}
