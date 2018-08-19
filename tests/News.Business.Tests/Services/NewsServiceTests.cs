﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using News.Business.Services;
using News.Core;
using News.Core.Models;
using News.Core.Services;
using News.Data.EntityFramework;
using Xunit;

namespace News.Business.Tests.Services
{
    public class NewsServiceTests
    {
        private readonly NewsService _newsService;

        public NewsServiceTests()
        {
            _newsService = GetNewsServiceWithTestData();
        }

        [Fact]
        public async Task PostNewsWithCorrectData_ShouldReturnValidModel()
        {
            var testModel = GetTestData().First();

            // Act
            var result = await _newsService.Create(ProjectToNewsModel(testModel));

            // Assert
            result.Exists(n => n.Title == testModel.Title
                               && n.Content == testModel.Content
                               && n.PublishDate == testModel.PublishDate);
        }

        private NewsModel ProjectToNewsModel(Data.Entities.News model)
            => new NewsModel
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = model.PublishDate
            };

        private bool CompareNewsExact(Data.Entities.News thisNews, Data.Entities.News otherNews)
            => thisNews.Id == otherNews.Id
               && thisNews.Title == otherNews.Title
               && thisNews.Content == otherNews.Content
               && thisNews.PublishDate == otherNews.PublishDate;

        private INewsService GetNewsService()
            => new NewsService(DbContextProvider.GetInMemoryDbContext());

        private NewsService GetNewsServiceWithTestData()
        {
            var context = DbContextProvider.GetInMemoryDbContext();
            PopulateData(context);
            return new NewsService(context);
        }

        private void PopulateData(ApplicationDbContext dbContext)
        {
            dbContext.News.AddRange(GetTestData());
            dbContext.SaveChanges();
        }

        private IEnumerable<Data.Entities.News> GetTestData()
            => new List<Data.Entities.News>
            {
                new Data.Entities.News{
                    Id = 1,
                    Title = "Title1",
                    Content = "Content1",
                    PublishDate = DateTime.ParseExact("2017/12/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) },
                new Data.Entities.News{
                    Id = 2,
                    Title = "Title2",
                    Content = "Content2",
                    PublishDate = DateTime.ParseExact("2017/09/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) },
                new Data.Entities.News{
                    Id = 3,
                    Title = "Title3",
                    Content = "Content3",
                    PublishDate = DateTime.ParseExact("2016/09/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) },
                new Data.Entities.News{
                    Id = 4,
                    Title = "Title4",
                    Content = "Content4",
                    PublishDate = DateTime.ParseExact("2016/06/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) },
                new Data.Entities.News{
                    Id = 5,
                    Title = "Title5",
                    Content = "Content5",
                    PublishDate = DateTime.ParseExact("2016/01/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) }
            };
    }
}