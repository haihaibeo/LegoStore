using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Entities
{
    public class Theme
    {
        public Theme()
        {
            ProductThemes = new HashSet<LegoProductTheme>();
        }

        [Key]
        [Required]
        public int ThemeID { get; set; }

        [StringLength(100)]
        public string ThemeName { get; set; }
        public ICollection<LegoProductTheme> ProductThemes { get; set; }
    }
}
