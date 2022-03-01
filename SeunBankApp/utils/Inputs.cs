using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeunBankApp
{
    public class Inputs
    {
        public static void Instruction(string instruct)
        {
            Console.WriteLine(instruct);
        }
        public static string Collect(string data)
        {
            var runing = true;
            while (runing)
            {
                data = Console.ReadLine();
                if (!Validations.VerifyNumberInputType(data))
                {
                    Inputs.Instruction("please correct your input");
                    continue;
                }
                runing = false;
            }
            return data;
        }
    }
}
