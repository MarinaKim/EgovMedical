using Egov.Medical.Lib.Model;
using GeneratorName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgovMedical.Model
{
    class ServiseProgramm
    {
        private static User user;
        public ServiseProgramm() { }
        public ServiseProgramm(User u)
        {
           user = u;
        }
        public static void PrintMenu(TypeMenu typeMenu = TypeMenu.type1)
        {
            switch (typeMenu)
            {
                case TypeMenu.type1:
                    {
                        Console.WriteLine("1. Enter\n2.Registration");
                    }
                    break;
                case TypeMenu.type2:
                    {
                        Console.WriteLine("1. Список организаций. ");
                        Console.WriteLine("2. Добавить организацию. ");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("3. Список пациентов. ");
                        Console.WriteLine("4. Добавить пациента. ");
                    }
                    break;
            }
        }

        public static int getPunctMenu()
        {
            return Int32.Parse(Console.ReadLine());
        }

        public static User GetUserInfoForRegistration()
        {
            User user = new User();
            Console.Write("{0,-20}", "Enter FIO:\t");
            user.FIO = Console.ReadLine();

            Console.Write("{0,-20}", "Enter IIN:\t");
            user.IIN = Console.ReadLine();

            Console.Write("{0,-20}", "Enter Date of Birth:\t");
            user.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("{0,-20}", "Enter gender: 0-W, 1=M\t");
            user.gen = (Gender)(Int32.Parse(Console.ReadLine()));
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

        public static void Autorisation()
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

                        do
                        {
                            Console.Clear();
                            PrintMenu(TypeMenu.type2);
                            switch (getPunctMenu())
                            {
                                case 1:
                                    {
                                        PrintMedOrg();
                                    }
                                    break;
                                case 2:
                                    {
                                        AddMedOrg();

                                    }
                                    break;
                            }
                        } while (Console.ReadLine() != "back");

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
            } while (count <= 3);

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

        public static void PrintMedOrg()
        {
            foreach (MedicalOrganization item in ServiseMedOrganization.GetMedOrganizations())
            {
                Console.WriteLine("{0} ({1})", item.NameOfOrganization, item.PhoneNumber);
            }
        }

        private static void AddMedOrg()
        {
            MedicalOrganization newMedOrg = new MedicalOrganization();
            Console.WriteLine("Enter name of org:");
            newMedOrg.NameOfOrganization = Console.ReadLine();
            Console.WriteLine("Enter name of address:");
            newMedOrg.Address = Console.ReadLine();
            Console.WriteLine("Enter name of phone:");
            newMedOrg.PhoneNumber = Console.ReadLine();

            if (ServiseMedOrganization.AddMedOrganization(newMedOrg))
            {
                SetConsoleColor(string.Format(" organization {0} added/", newMedOrg.NameOfOrganization), ConsoleColor.Green);
            }
            else
                SetConsoleColor(string.Format(" organization {0} not added/", newMedOrg.NameOfOrganization), ConsoleColor.Red);
      }

        public static void PrintPatients()
        {
            foreach (Pacient item in ServisePacient.GetPacients())
            {
                Console.WriteLine("{0} ({1})\t {3}", item.FIO, item.gen, item.IIN);
            }
        }
        public static void AddPacient()
        {
            Pacient newPacient = new Pacient();
            Console.WriteLine("Enter FIO: ");
            newPacient.FIO = Console.ReadLine();
            Console.WriteLine("Enter DAte of Birth: ");
            newPacient.DateOfBirth= DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter gender: ");
            newPacient.gen = (Gender)(Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Enter IIN: ");
            newPacient.IIN = Console.ReadLine();
            
            if (ServisePacient.AddPacient(newPacient))
            {
                SetConsoleColor(string.Format("pacient {0} added.", newPacient.FIO), ConsoleColor.Green);
            }
            else
            {
                SetConsoleColor(string.Format("pacient {0} not added.", newPacient.FIO), ConsoleColor.Red);
            }

        }
    }
}
