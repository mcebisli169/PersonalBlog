using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.DTOs.Articles
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCounte { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
