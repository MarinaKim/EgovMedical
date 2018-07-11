using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egov.Medical.Lib.Model
{
    public class ServiseUser
    {
        public static bool Registration(User user)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db")) //using для безопасного использования БД, не надо следить за открытием и закрытием
                {
                    LiteCollection<User> users = db.GetCollection<User>("User");
                    users.Insert(user);
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;

            }
        }

       
    }
}
