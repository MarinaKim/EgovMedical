using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egov.Medical.Lib.Interfaces;
using GeneratorName;

namespace Egov.Medical.Lib.Model
{
  public class Pacient : IPacient
    {
        public DateTime DateOfBirth { get; set; }
        public string FIO { get; set; }

        public Gender gen { get; set; }
        public string IIN { get; set; }
        public int UserId { get; set; }

        public int Age()
        {
            return (DateTime.Now.Year - DateOfBirth.Year);
        }
    }
}
