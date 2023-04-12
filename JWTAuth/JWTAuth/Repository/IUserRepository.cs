﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWTAuth.Models;

namespace JWTAuth.Repository
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User GetDataUser(User user);
    }
}
