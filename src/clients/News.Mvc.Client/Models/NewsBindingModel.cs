using System.ComponentModel.DataAnnotations;

namespace News.Mvc.Client.Models
{
    public class NewsBindingModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}