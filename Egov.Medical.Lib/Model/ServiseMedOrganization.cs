using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Egov.Medical.Lib.Model
{
 public   class ServiseMedOrganization
    {
        public static  List<MedicalOrganization> GetMedOrganizations()
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db")) //using для безопасного использования БД, не надо следить за открытием и закрытием
            {
                List<MedicalOrganization> ogs= db.GetCollection<MedicalOrganization>("MedicalOrganization").FindAll().ToList();
                for (int i = 0; i < ogs.Count; i++)
                {
                    ogs[i].Pacients = db.GetCollection<Pacient>("Pacient").FindAll(). Where(f=>f.MedOrganizationId==ogs[i].MedOrganizationId).ToList();

                }
                return ogs;
            }
        }

        public static bool AddMedOrganization (MedicalOrganization med)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db"))
                {
                    var collection = db.GetCollection<MedicalOrganization>("MedicalOrganization");
                    collection.Insert(med);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
              
    }
}
