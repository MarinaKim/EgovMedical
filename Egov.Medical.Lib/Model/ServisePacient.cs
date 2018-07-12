using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Egov.Medical.Lib.Model
{
    public class ServisePacient
    {
        public static List<Pacient> GetPacients()
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db")) //using для безопасного использования БД, не надо следить за открытием и закрытием
            {
                return db.GetCollection<Pacient>("Pacient").FindAll().ToList();
            }
        }

        public static bool AddPacient(Pacient pacient)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db"))
                {
                    var collection = db.GetCollection<Pacient>("Pacient");
                    collection.Insert(pacient);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void AddMedOrgToPacient( int userId, int MedOrganizationId)
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db"))
            {
                var collection = db.GetCollection<Pacient>("Pacient");
                Pacient p = collection.FindOne(f => f.PacientId == userId);
                p.MedOrganizationId = MedOrganizationId;
                collection.Update(p);
            }
        }
    }
}
