using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using News.Core.Services;
using News.Data.EntityFramework;
using Optional;

namespace News.Business.Services
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public NewsService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        private async Task<bool> ExistsById(int id)
            => await _applicationDbContext
                .News
                .Where(news => news.Id == id)
                .AnyAsync();

        private async Task<bool> ExistsByTitle(string title)
            => await _applicationDbContext
                .News
                .Where(news => news.Title == title)
                .AnyAsync();
    }
}