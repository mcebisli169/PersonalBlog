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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("E0017DBA-785B-4AA3-A1F3-AB1836EA2BF8"),
                RoleId = Guid.Parse("66E9DC72-B837-40E1-9C3C-D23F09D156BE")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("EAC66701-F7D0-4C0B-BF78-2B1680455606"),
                RoleId = Guid.Parse("608AFB2D-0457-4623-8632-0A24B944C705")
            });
        }
    }
}
