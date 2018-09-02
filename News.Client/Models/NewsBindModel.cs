using System;

namespace News.Client.Models
{
    public class NewsBindModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}