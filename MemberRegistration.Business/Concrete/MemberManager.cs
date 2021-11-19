using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.Business.ValidationRules.FluentValidation;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using MemberRegistration.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;
        private IKpsService _kpsService;
        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }


        [FluentValidationAspect(typeof(MemberValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public void Add(Member member)
        {
            CheckIfMemberExists(member);
            CheckIfUserValidFromKps(member);
            _memberDal.Add(member);
        }



        private void CheckIfUserValidFromKps(Member member)
        {
            if (_kpsService.ValidateUser(member) == false)
            {
                throw new Exception("Kullanıcı doğrulaması geçerli değil.");
            }

        }

        private void CheckIfMemberExists(Member member)
        {
            if (_memberDal.Get(m => m.TcNo == member.TcNo) != null)
            {
                throw new Exception("Bu kullanıcı daha önce kayıt olmuştur");
            }
        }


        //Tümünü listelesin
        public List<Member> GetList()
        {
            return _memberDal.GetList();
        }





        //istenilen property lere göre listelesin...
        public List<MemberForRecourseDto> GetRecourseList()
        {
            return _memberDal.GetRecourseList();
        }



        //Başvuruları getir.
        public List<Recourse> GetListRecourse()
        {
            throw new NotImplementedException();
        }
    }
}
