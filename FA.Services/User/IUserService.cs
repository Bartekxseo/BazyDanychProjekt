using FA.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.Services.User
{
    public interface IUserService
    {
        public UserInfo getUser(int userId);
    }
}
