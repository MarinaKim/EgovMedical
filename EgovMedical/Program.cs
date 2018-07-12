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
    public enum TypeMenu { type1, type2}
    class Program
    {
        static void Main(string[] args)
        {
            ServiseUser.GetAllUsers();
            PrintMenu();
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Autorisation();
                    }
                    break;

                case 2:
                    {
                        if (ServiseUser.Registration(GetUserInfoForRegistration()))
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

        static public void PrintMenu(TypeMenu typeMenu=TypeMenu.type1)
        { switch (typeMenu) {
                case TypeMenu.type1:
                    {
                        Console.WriteLine("1. Enter\n2.Registration");
                    }break;
                case TypeMenu.type2:
                    {
                        Console.WriteLine("1. Список организаций. ");
                        Console.WriteLine("2. Добавить организацию. ");
                    }
                    break;
            }
    }

        static public int getPunctMenu()
        {
            return Int32.Parse(Console.ReadLine());
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

        static public void Autorisation()
        {
            User user = new User();
            int count = 1;
            do
            {
                user = new User();
                Console.WriteLine("Enter login: ");
                user.login = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                user.password = Console.ReadLine();

                if (ServiseUser.UserIsExist(user.login))
                {
                    StatusAutorisation status = ServiseUser.LoginOn(user.login, user.password, out user);
                    if (status == StatusAutorisation.status02)
                    {
                        Console.Clear();
                        Console.WriteLine("у вас осталось {0} попыток.", 3 - count);
                        count++;
                    }
                    else if (status == StatusAutorisation.status01)
                    {
                        Console.Clear();
                        SetConsoleColor(string.Format("Welcome, {0}", user.FIO), ConsoleColor.Green);
                        PrintMenu(TypeMenu.type2);
                        switch (getPunctMenu())
                        {
                            case 1:
                                {

                                }break;
                            case 2:
                                {

                                }break;
                        }

                        break;
                    }
                    else
                    {
                        Console.Clear();
                        SetConsoleColor("Error authorization.", ConsoleColor.Red);
                        break;
                    }
                }
                else
                {
                    SetConsoleColor(" такого логина не существует.", ConsoleColor.Red);
                }
                } while (count <= 3) ;

                if (count > 3)
                {
                    ServiseUser.BlockUser(user.login);
                    Console.Clear();
                    SetConsoleColor("You blocked. ", ConsoleColor.Red);
                }
            }

        private static void SetConsoleColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
