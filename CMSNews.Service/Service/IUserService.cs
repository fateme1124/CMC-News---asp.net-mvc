﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSNews.Models.Models;
namespace CMSNews.Service.Service
{
    public interface IUserService:IGenericService<User>
    {
        int GetUserId(string mobileNUmber);
    }
}
