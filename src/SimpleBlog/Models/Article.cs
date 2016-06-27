using System;
using SimpleBlog.Entity;

namespace SimpleBlog.Models
{
    public class Article : EntityObject
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public ApplicationUser Author { get; set; }
        public DateTime PostDate { get; set; }
    }
}