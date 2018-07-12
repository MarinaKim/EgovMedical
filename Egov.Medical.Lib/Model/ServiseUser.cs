using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egov.Medical.Lib.Model
{
    public enum StatusAutorisation { status01, status02, status03 }
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
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;

            }
        }
        public static StatusAutorisation LoginOn(string login, string password, out User newUser)
        {
            newUser = null;
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db")) //using для безопасного использования БД, не надо следить за открытием и закрытием
                {
                    LiteCollection<User> users = db.GetCollection<User>("User");
                    newUser = users.FindOne(f => f.login == login && f.password == password);
                    if (newUser != null)
                        return StatusAutorisation.status01;
                    else
                        return StatusAutorisation.status02;
                }
            }
            catch (Exception ex)
            {
                return StatusAutorisation.status03;
            }
        }

        public static void GetAllUsers()
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db")) //using для безопасного использования БД, не надо следить за открытием и закрытием
            {
                LiteCollection<User> users = db.GetCollection<User>("User");
                foreach (var item in users.FindAll())
                {
                    Console.WriteLine("FIO:{0}\t{1}", item.FIO, item.CreateDate);

                }
            }
        }

        public static void BlockUser(int UserId)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db")) //using для безопасного использования БД, не надо следить за открытием и закрытием
                {
                    LiteCollection<User> users = db.GetCollection<User>("User");
                    User user = users.FindOne(f => f.UserId == UserId);
                    user.IsBlock = true;
                    users.Update(user);
                }
            }
            catch (Exception ex) { }
        }

        public static void BlockUser(string login)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db")) //using для безопасного использования БД, не надо следить за открытием и закрытием
                {
                    LiteCollection<User> users = db.GetCollection<User>("User");
                    User user = users.FindOne(f => f.login == login);
                    user.IsBlock = true;
                    users.Update(user);
                }
            }
            catch (Exception ex) { }
        }

        public static bool UserIsExist(string login)
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db")) //using для безопасного использования БД, не надо следить за открытием и закрытием
            {
                LiteCollection<User> users = db.GetCollection<User>("User");
                User user = users.FindOne(f => f.login == login);
                if (user != null)
                    return true;
                else
                    return false;

            }
        }
    }
}
