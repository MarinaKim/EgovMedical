using Egov.Medical.Lib.Model;
using GeneratorName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EgovMedical.Model;

namespace Egov.Medical
{

    
  
    class Program
    {
        Discount d = Discount.name;
        //enum
        Console.WriteLine(Enum.GetUnderlyingType();
       


        static void Main(string[] args)
        {
            ServiseProgramm.PrintMenu();

            switch (ServiseProgramm.getPunctMenu())
            {
                case 1:
                    {
                        ServiseProgramm.Autorisation();
                    }
                    break;
                case 2:
                    {
                        if (ServiseUser.Registration(ServiseProgramm.GetUserInfoForRegistration()))
                        {
                            Console.Clear();
                            Console.WriteLine("register ok");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("register error");
                        }
                    }
                    break;
            }
        }
    }
}