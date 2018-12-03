﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItResources.Core.Models
{
    [Table("Keyword")]
    public class Keyword
    {
        public int KeywordId { get; set; }
        [Required]
        public string KeywordName { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
