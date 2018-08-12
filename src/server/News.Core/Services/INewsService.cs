using System.Threading.Tasks;
using News.Core.Models;
using Optional;

namespace News.Core.Services
{
    public interface INewsService
    {
        Task<Option<NewsServiceModel, Error>> Create(NewsModel model);
    }
}