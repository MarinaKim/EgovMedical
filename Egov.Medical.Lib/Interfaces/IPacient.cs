using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;
namespace Egov.Medical.Lib.Interfaces
{
    public interface IPacient
    {
        int UserId { get; set; }
        string FIO { get; set; }
        Gender gen { get; set; }
        int Age();
        DateTime DateOfBirth { get; set; }
        string IIN { get; set; }

    }
}
