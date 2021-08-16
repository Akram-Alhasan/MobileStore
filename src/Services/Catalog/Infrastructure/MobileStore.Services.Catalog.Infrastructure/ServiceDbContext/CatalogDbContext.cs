using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobileStore.BuildingBlocks.Shared.Shared.Interfaces;
using MobileStore.Services.Catalog.Domain.Entities.Category;
using MobileStore.Services.Catalog.Domain.Entities.Mobile;
using MobileStore.Services.Catalog.Infrastructure.FluentConfigurations;
using MobileStore.Services.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileStore.Services.Catalog.Infrastructure.ServiceDbContext
{
    public class CatalogDbContext : DbContext , IUnitOfWork
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<MobileAttribute> MobileAttributes { get; set; }
    }
}
