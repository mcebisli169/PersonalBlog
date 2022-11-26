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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("998B5CE9-CE74-4646-BCF6-1F6631231F6B"),
                FileName = "images/testimage",
                FileType = "jpg",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Image
            {
                Id = Guid.Parse("EBE68FDD-4371-4A0F-860E-6755343F52EA"),
                FileName = "images/vstest",
                FileType = "png",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
