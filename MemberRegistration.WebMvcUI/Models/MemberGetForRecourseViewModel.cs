using MemberRegistration.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberRegistration.WebMvcUI.Models
{
    public class MemberGetForRecourseViewModel
    {
        public List<MemberForRecourseDto> MemberForRecourseDtos { get; set; }
    }
}