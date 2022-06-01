using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ICollection<LegoProductTheme> ProductThemes { get; set; }
    }
}
