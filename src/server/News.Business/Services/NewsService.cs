using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using News.Core;
using News.Core.Models;
using News.Core.Services;
using News.Data.EntityFramework;
using Optional;
using static AutoMapper.Mapper;

namespace News.Business.Services
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public NewsService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Option<NewsServiceModel, Error>> Create(NewsModel model)
        {
            if (await ExistsByTitle(model.Title))
            {
                return Option.None<NewsServiceModel, Error>(new Error($"News with title '{model.Title}' already exists!"));
            }

            var news = new Data.Entities.News
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = model.PublishDate
            };

            await _applicationDbContext.News.AddAsync(news);
            await _applicationDbContext.SaveChangesAsync();

            return Map<NewsServiceModel>(news).Some<NewsServiceModel, Error>();
        }

        public async Task<IEnumerable<NewsServiceModel>> GetAll()
            => await _applicationDbContext
                .News
                .ProjectTo<NewsServiceModel>()
                .ToListAsync();

        public async Task<NewsServiceModel> GetSingleById(int id)
            => await _applicationDbContext
                .News
                .Where(news => news.Id == id)
                .ProjectTo<NewsServiceModel>()
                .FirstOrDefaultAsync();


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