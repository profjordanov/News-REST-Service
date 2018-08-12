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

        public async Task<Option<IEnumerable<NewsServiceModel>, Error>> GetAll()
        {
            var result = (await _applicationDbContext
                    .News
                    .ProjectTo<NewsServiceModel>()
                    .ToListAsync())
                .NoneWhen(res => !res.Any());

            return result.Match(
                news => news.Some<IEnumerable<NewsServiceModel>, Error>(),
                () => Option.None<IEnumerable<NewsServiceModel>, Error>(new Error("There are no news!")));
        }

        public async Task<Option<NewsServiceModel, Error>> GetSingleById(int id)
        {
            var result = (await _applicationDbContext
                    .News
                    .Where(news => news.Id == id)
                    .ProjectTo<NewsServiceModel>()
                    .FirstOrDefaultAsync())
                .SomeNotNull();

            return result.Match(
                news => news.Some<NewsServiceModel, Error>(),
                () => Option.None<NewsServiceModel, Error>(new Error($"There are no news with ID:{id}.")));
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