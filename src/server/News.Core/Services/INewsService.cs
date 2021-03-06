﻿using System.Collections.Generic;
using System.Threading.Tasks;
using News.Core.Models;
using Optional;

namespace News.Core.Services
{
    public interface INewsService
    {
        Task<Option<NewsServiceModel, Error>> Create(NewsModel model);

        Task<Option<IEnumerable<NewsServiceModel>, Error>> GetAll();

        Task<Option<NewsServiceModel, Error>> GetSingleById(int id);

        Task<Option<Success, Error>> DeleteById(int id);

        Task<Option<NewsServiceModel, Error>> Update(int id, NewsModel model);
    }
}