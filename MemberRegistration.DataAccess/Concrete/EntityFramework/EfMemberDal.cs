using DevFramework.Core.DataAccess.EntityFramework;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using MemberRegistration.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.DataAccess.Concrete.EntityFramework
{
    public class EfMemberDal : EfEntityRepositoryBase<Member, MembershipContext>, IMemberDal
    {
        public List<MemberForRecourseDto> GetRecourseList()
        {

            using (MembershipContext context = new MembershipContext())
            {
                var result = from r in context.Recourses
                             join m in context.Members
                             on r.Id equals m.RecoursesId
                             select new MemberForRecourseDto
                             {
                                 Id = m.Id,
                                 Name = m.FirstName,
                                 LastName = m.LastName,
                                 Email = m.Email,
                                 RecourseType = r.RecourseType

                             };

                return result.ToList();
            }
        }
    }
}