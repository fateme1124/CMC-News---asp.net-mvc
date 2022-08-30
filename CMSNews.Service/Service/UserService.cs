using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSNews.Models.Context;
using CMSNews.Models.Models;
using CMSNews.Repository.Repository;

namespace CMSNews.Service.Service
{
    public class UserService : GenericService<User>, IUserService
    {
        private IUserRepository _userRepository;
        public UserService(DbCMSNewsContext context) : base(context)
        {
            _userRepository=new UserRepository(context);
        }

        public int GetUserId(string mobileNUmber)
        {
            return _userRepository.GetAll().FirstOrDefault(t => t.MobileNumber == mobileNUmber).UserId;
        }
    }
}
