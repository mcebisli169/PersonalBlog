using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("A7DAB329-8F34-4BE7-BDFE-FCCF7DF783D1"),
                name = "ASP.NET Core",
                CreatedBy = "Admin test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category
            {
                Id = Guid.Parse("BF6C8898-1DC7-49D3-AE3F-EFCF099B8D15"),
                name = "Visual Studio",
                CreatedBy = "Admin test",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            });
        }
    }
}
