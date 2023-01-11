using AutoMapper;
using BD.DataAccess;
using BD.Domain.Entities;
using BD.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BD.Services.User
{
    public class UserService : IUserService
    {
        private readonly BDDbContext BDDbContext;
        private readonly Mapper mapper;
        public UserService(BDDbContext _faDbContext)
        {
            BDDbContext = _faDbContext;
        }
        public UserInfo getUser(int userId)
        {
            var dbUser = BDDbContext.Set<Domain.Entities.User>().Where(x => x.Id == userId).FirstOrDefault();
            var user = new UserInfo();
            mapper.Map(dbUser, user); ;
            return user;
        }
    }
}
