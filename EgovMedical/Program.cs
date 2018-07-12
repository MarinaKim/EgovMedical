using Egov.Medical.Lib.Model;
using EgovMedical.Model;
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
            ServiseProgramm.PrintMenu();

            switch(ServiseProgramm.getPunctMenu())

                case 1: {
                    ServiseProgramm.Autorisation();
                }
                break;

                case 2:
                    {
                        if (ServiseUser.Registration(ServiseProgramm.GetUserInfoForRegistration()))
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

        
    }
}
