using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItResources.Core.Models
{
    [Table("Resource")]
    public class Resource
    {
        public int ResourceId { get; set; }
        [MaxLength(255)]
        [Required]
        public string ResourceName { get; set; }
        [Required]
        public string URL { get; set; }
        public DateTime RefreshDate { get; set; }
        public string Description { get; set; }
        [MaxLength(255)]
        public string Contacts { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        [Required]
        public virtual Category Category { get; set; }

    }
}
