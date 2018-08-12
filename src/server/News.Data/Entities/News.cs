using System;
using System.ComponentModel.DataAnnotations;

namespace News.Data.Entities
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}