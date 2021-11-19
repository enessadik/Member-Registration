using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member { Email = "enessasddikk@gmail.com",
                FirstName = "Enes", LastName = "Sadık", 
                DateOfBirth = new DateTime(1997, 1, 1), TcNo = "15409708464" });
            Console.WriteLine("Eklendi");
            Console.ReadLine();
        }
    }
}
