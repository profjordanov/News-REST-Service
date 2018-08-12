using System;
using System.ComponentModel.DataAnnotations;

namespace News.Core.Models
{
    public class NewsModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}