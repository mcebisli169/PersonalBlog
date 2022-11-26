using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "ASP .NET CORE Deneme Makalesi",
                Content = "Asp .net core ......",
                ViewCount = 15,
                CategoryId = Guid.Parse("A7DAB329-8F34-4BE7-BDFE-FCCF7DF783D1"),
                ImageId = Guid.Parse("998B5CE9-CE74-4646-BCF6-1F6631231F6B"),
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false 
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi",
                Content = "Visual Studio ......",
                ViewCount = 15,
                CategoryId = Guid.Parse("BF6C8898-1DC7-49D3-AE3F-EFCF099B8D15"),
                ImageId = Guid.Parse("EBE68FDD-4371-4A0F-860E-6755343F52EA"),
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }
            );
        }
    }
}
