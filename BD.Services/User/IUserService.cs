using BD.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Services.User
{
    public interface IUserService
    {
        public UserInfo getUser(int userId);
    }
}
