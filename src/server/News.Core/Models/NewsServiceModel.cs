using System;
using System.ComponentModel.DataAnnotations;

namespace News.Core.Models
{
    public class NewsServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}