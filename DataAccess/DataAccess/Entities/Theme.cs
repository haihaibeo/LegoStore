using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DataAccess.Entities
{
    public class Theme
    {
        public Theme()
        {
            Products = new HashSet<LegoProduct>();
        }

        [Key]
        [Required]
        public int ThemeID { get; set; }

        [StringLength(100)]
        public string ThemeName { get; set; }

        public virtual ICollection<LegoProductTheme> ProductThemes { get; set; }

        public virtual ICollection<LegoProduct> Products { get; set; }
    }
}
