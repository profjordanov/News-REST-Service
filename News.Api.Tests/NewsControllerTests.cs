using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using News.Data.Entities;

namespace News.Api.Tests
{
    public class NewsControllerTests
    {
        [Fact]
        public void NewsControllerTests()
        {
            // Arrange
            var controllerType = typeof(NewsController);
        }
    }

    private IEnumerable<News> GetTestData()
    => new List<News>
    {
    new News{
        Id = 1,
        Title = "Title1",
        Content = "Content1",
        PublishDate = DateTime.ParseExact("2017/12/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) },
    new News{
        Id = 2,
        Title = "Title2",
        Content = "Content2",
        PublishDate = DateTime.ParseExact("2017/09/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) },
    new News{
        Id = 3,
        Title = "Title3",
        Content = "Content3",
        PublishDate = DateTime.ParseExact("2016/09/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) },
    new News{
        Id = 4,
        Title = "Title4",
        Content = "Content4",
        PublishDate = DateTime.ParseExact("2016/06/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) },
    new News{
        Id = 5,
        Title = "Title5",
        Content = "Content5",
        PublishDate = DateTime.ParseExact("2016/01/09", "yyyy/MM/dd", CultureInfo.InvariantCulture) }
    };
}