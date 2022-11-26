using Blog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class AppUser :IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("998B5CE9-CE74-4646-BCF6-1F6631231F6B");
        public Image Image { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
