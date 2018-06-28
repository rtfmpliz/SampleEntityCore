using Microsoft.EntityFrameworkCore;
using SampleEntityCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEntityCore.Data
{
    public class POSDataContext : DbContext
    {
        public POSDataContext(DbContextOptions<POSDataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } //Categories = nama Tabel
        public DbSet<Product> Products { get; set; }
    }
}
