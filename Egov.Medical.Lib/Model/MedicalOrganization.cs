using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egov.Medical.Lib.Model
{
   public class MedicalOrganization
    {
        public int MedOrganizationId { get; set; }
        public  string NameOfOrganization { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Pacient> Pacients = new List<Pacient>();
    }
}
