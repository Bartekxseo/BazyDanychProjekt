using AutoMapper;
using FA.DataAccess;
using FA.Domain.Entities;
using FA.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FA.Services.User
{
    public class UserService : IUserService
    {
        private readonly FADbContext faDbContext;
        private readonly Mapper mapper;
        public UserService(FADbContext _faDbContext)
        {
            faDbContext = _faDbContext;
        }
        public UserInfo getUser(int userId)
        {
            var dbUser = faDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            var user = new UserInfo();
            mapper.Map(dbUser, user); ;
            return user;
        }
    }
}
