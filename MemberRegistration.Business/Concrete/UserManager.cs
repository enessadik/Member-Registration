using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using MemberRegistration.Business.Abstract;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;

        }



        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public void Add(User user)
        {
            _userDal.Add(user);
        }






        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public void Delete(User user)
        {
            _userDal.Delete(user);
        }
    }


}
