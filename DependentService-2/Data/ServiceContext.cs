using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DependentService_2.Model;

namespace DependentService_2.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext (DbContextOptions<ServiceContext> options)
            : base(options)
        {
        }

        public DbSet<DependentService_2.Model.Inventory> Inventory { get; set; }
    }
}
