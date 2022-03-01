﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeunBankAppCore
{
    public class Inputs
    {
        public static void Instruction(string instruct) => Console.WriteLine(instruct);
        public static string CollectText(string data) =>  Console.ReadLine();
        public static void Clean() => Console.Clear();
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
        public static string CollectEmail(string data)
        {
            var runing = true;
            while (runing)
            {
                data = Console.ReadLine();
                if (!Validations.VerifyEmail(data))
                {
                    Inputs.Instruction("please correct your input");
                    continue;
                }
                runing = false;
            }
            return data;
        }
        public static string CollectPassword(string data)
        {
            var runing = true;
            while (runing)
            {
                data = Console.ReadLine();
                if (!Validations.CheckPasswordInput(data))
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
