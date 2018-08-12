﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Api.Controllers._Base;
using News.Core;
using News.Core.Models;
using News.Core.Services;

namespace News.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/News")]
    public class NewsController : ApiController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        /// <summary>
        /// Creates a news item by given title, content and publish date.
        /// </summary>
        /// <param name="model">The news model.</param>
        /// <returns>A news model.</returns>
        /// <response code="201">A news was created.</response>
        /// <response code="400">Already existing news.</response>
        [HttpPost]
        [ProducesResponseType(typeof(NewsServiceModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] NewsModel model)
            => (await _newsService.Create(model))
                    .Match(news => CreatedAtAction(nameof(Post), news), Error);

        /// <summary>
        /// returns all news ordered by publish date (from the latest).
        /// </summary>
        /// <returns>A collection of news model.</returns>
        /// <response code="200">A collection of all news.</response>
        /// <response code="404">No News available.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NewsServiceModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
            => (await _newsService.GetAll())
                    .Match(Ok, Error);
    }
}