using ItResources.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItResources.DataAccess.SQL
{
    public class DataContext: DbContext
    {
        public DataContext()
            : base("ItResources")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Resource> Resources { get; set; }
    }
}
