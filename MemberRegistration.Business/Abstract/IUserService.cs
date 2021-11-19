using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Delete(User user);
    }
}
