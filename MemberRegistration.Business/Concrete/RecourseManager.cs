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
    public class RecourseManager : IRecourseService
    {
        private IRecourseDal _recourseDal;

        public RecourseManager(IRecourseDal recourseDal)
        {
            _recourseDal = recourseDal;

        }
        public List<Recourse> GetListRecourse()
        {
            return _recourseDal.GetList();
        }
    }
}
