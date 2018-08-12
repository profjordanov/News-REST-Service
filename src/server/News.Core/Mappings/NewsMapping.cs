using AutoMapper;
using News.Core.Models;

namespace News.Core.Mappings
{
    public class NewsMapping : Profile
    {
        public NewsMapping()
        {
            CreateMap<Data.Entities.News, NewsServiceModel>(MemberList.Destination);

            CreateMap<NewsModel, Data.Entities.News>(MemberList.Destination);
        }
    }
}