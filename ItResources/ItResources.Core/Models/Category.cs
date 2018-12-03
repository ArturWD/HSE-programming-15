using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItResources.Core.Models
{
    [Table("Category")]
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
    }
}
