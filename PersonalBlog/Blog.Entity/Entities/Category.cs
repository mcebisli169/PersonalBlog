﻿using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Category : BaseEntity
    {
        public string name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
