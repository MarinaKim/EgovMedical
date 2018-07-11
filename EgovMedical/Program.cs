using Egov.Medical.Lib.Model;
using GeneratorName;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgovMedical
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllUsers();
            PrintMenu();
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {

                    }
                    break;

                case 2:
                    {
                        if(ServiseUser.Registration(GetUserInfoForRegistration()))
                        {
                            Console.WriteLine("OK");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    break;
            }

        }

        static public void PrintMenu()
        {
            Console.WriteLine("1. Enter\n2.Registration");
        }

        static public User GetUserInfoForRegistration()
        {
            User user = new User();
            Console.Write("{0,-20}","Enter FIO:\t");
            user.FIO = Console.ReadLine();

            Console.Write("{0,-20}", "Enter IIN:\t");
            user.IIN = Console.ReadLine();

            Console.Write("{0,-20}", "Enter Date of Birth:\t");
            user.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("{0,-20}", "Enter gender: 0-W, 1=M\t");
            user.gen =(Gender)(Int32.Parse(Console.ReadLine()));
            Console.WriteLine("--------------------------------------------------------------");
            Console.Write("{0,-20}", "Enter login:\t");
            user.login = Console.ReadLine();
            Console.Write("{0,-20}", "Enter password:\t");
            user.password = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------------");

            user.CreateDate = DateTime.Now;
            user.IsBlock = false;

            return user;
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
    }
}
