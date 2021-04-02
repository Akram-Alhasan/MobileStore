using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileStore.Services.Catalog.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileStore.Services.Catalog.Infrastructure.FluentConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Name)
                    .IsRequired();
    }
    }
}
