using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        IUserDal _userDal;

        public LoginManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUser(string userName, string password)
        {
            return _userDal.Get(x => x.UserName == userName && x.UserPassword == password);
        }
    }
}