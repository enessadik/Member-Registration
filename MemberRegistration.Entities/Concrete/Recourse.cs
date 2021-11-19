using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Entities.Concrete
{
    public class Recourse : IEntity
    {
        public int Id { get; set; }
        public string RecourseType { get; set; }


    }
}
