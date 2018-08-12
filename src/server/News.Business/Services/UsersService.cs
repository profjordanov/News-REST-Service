﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Optional;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using News.Business.Extensions;
using News.Core;
using News.Core.Identity;
using News.Core.Models;
using News.Core.Services;
using News.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Optional;

namespace News.Business.Services
{
    public class UsersService : IUsersService
    {
        public UsersService(
            UserManager<User> userManager,
            IJwtFactory jwtFactory,
            IMapper mapper)
        {
            UserManager = userManager;
            JwtFactory = jwtFactory;
            Mapper = mapper;
        }

        protected UserManager<User> UserManager { get; }
        protected IJwtFactory JwtFactory { get; }
        protected IMapper Mapper { get; }

        public async Task<Option<JwtModel, Error>> Login(LoginUserModel model)
        {
            var loginResult = await (await UserManager.FindByEmailAsync(model.Email))
                .SomeNotNull()
                .FilterAsync(async user => await UserManager.CheckPasswordAsync(user, model.Password));

            return loginResult.Match(
                user =>
                {
                    return new JwtModel
                    {
                        TokenString = JwtFactory.GenerateEncodedToken(user.Id, user.Email, new List<Claim>())
                    }.Some<JwtModel, Error>();
                },
                () => Option.None<JwtModel, Error>(new Error("Invalid credentials.")));
        }

        public async Task<Option<UserModel, Error>> Register(RegisterUserModel model)
        {
            var user = Mapper.Map<User>(model);

            var creationResult = await UserManager.CreateAsync(user, model.Password);

            return creationResult.Succeeded ?
                Mapper.Map<UserModel>(user).Some<UserModel, Error>() :
                Option.None<UserModel, Error>(new Error(creationResult.Errors.Select(e => e.Description)));
        }
    }
}
