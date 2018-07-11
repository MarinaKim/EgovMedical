using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egov.Medical.Lib.Interfaces;
using GeneratorName;

namespace Egov.Medical.Lib.Model
{
   public class User : IPacient, IUser
    {
        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FIO { get; set; }

        public Gender gen { get; set; }

        public string IIN { get; set; }
        public bool IsBlock { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public int role { get; set; }

        public int UserId { get; set; }

        public int Age()
        {
            return (DateTime.Now.Year - DateOfBirth.Year);
        }

        public void BlockUser(bool status)
        {

        }
    }
}