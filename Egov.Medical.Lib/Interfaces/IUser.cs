using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egov.Medical.Lib.Interfaces
{
    public interface IUser
    {
      
        string login { get; set; }
        string password { get; set; }
        int role { get; set; }

        DateTime CreateDate { get; set; }
        string CreatedBy { get; set; }

        bool IsBlock { get; set; }
        void BlockUser(bool status);


    }
}
