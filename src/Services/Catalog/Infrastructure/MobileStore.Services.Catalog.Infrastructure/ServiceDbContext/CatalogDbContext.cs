using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobileStore.Services.Catalog.Domain.Entities.Category;
using MobileStore.Services.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileStore.Services.Catalog.Infrastructure.ServiceDbContext
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
