using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BankAppUI
{
    public class PrintTable
    {
        public static int tableWidth = 100;

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += MakeTextCenter(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string MakeTextCenter(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        public void MakeDynamicTable(List<List<string>> savedCourses)
        {
            Console.Clear();
            Console.WriteLine("Spirit University GPA");
            PrintTable.PrintLine();
            PrintTable.PrintRow("COURSE & CODE", "COURSE UNIT", "GRADE", "GRADE-UNIT", "WEIGHT Pt.", "REMARK");
            PrintTable.PrintLine();
            int totalUnitsRegistered = 0;
            int totalWeightPoints = 0;
            int totalGradeUnits = 0;
            int totalUnitsPassed = 0;
            foreach (var course in savedCourses)
            {
                PrintTable.PrintRow(course[0], course[1], course[2], course[3], course[4], course[5]);

                totalUnitsRegistered += Convert.ToInt32(course[1]);
                totalWeightPoints += Convert.ToInt32(course[4]);
                totalGradeUnits += Convert.ToInt32(course[3]);
                if (Convert.ToInt32(course[3]) >= 1)
                {
                    totalUnitsPassed += Convert.ToInt32(course[1]);
                }
            }
            decimal GPA = Math.Round(totalWeightPoints / (decimal)totalGradeUnits, 2);
            PrintTable.PrintLine();
            Console.WriteLine($"Total Course Unit Registered is {totalGradeUnits}\n" +
                $"Total Course Unit Passed is {totalUnitsPassed}\n" +
                $"Total Weight Point is {totalWeightPoints}\n" +
                $"Your GPA is = {GPA}");
            PrintTable.PrintLine();


        }
    }
}
