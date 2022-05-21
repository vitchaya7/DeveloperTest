using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDB;

namespace Test5
{
    public class Test5
    {
        public static void Main(string[] args)
        {
            int NameYear = 0;
            List<string> resultName = new List<string>();
            int check = 0;
            var db = new DBContext();

            Console.Write("Search Name: ");
            var name = Console.ReadLine();
            var DBindex = from item in db.NameIndexs
                          orderby item.Name, item.Day, item.Year, item.Month
                          select item;
            foreach (var item in DBindex)
            {
                if (item.Name.Equals(name))
                {
                    NameYear = (int)item.Year;
                }
            }
            Console.Write("Older to Younger [1] or Younger to Older [2] : ");
            var Choose = Console.ReadLine();
            if (Choose.Equals("1"))
            {
                foreach (var item in DBindex)
                {
                    if (item.Year > NameYear)
                    {
                        resultName.Add(item.Name);
                    }
                }
                Console.Write("Result:  ");
                if (resultName.Count == 0)
                {
                    Console.Write(" Not Found");
                }
                else if (resultName.Count > 0)
                {
                    resultName.Reverse();
                    foreach (var item in resultName)
                    {
                        Console.Write(item);
                        if (check == 0 && resultName.Count != 1)
                        {
                            Console.Write(" > ");
                        }
                        check++;
                    }
                }
            }
            else if (Choose.Equals("2"))
            {
                foreach (var item in DBindex)
                {
                    if (item.Year < NameYear)
                    {
                        resultName.Add(item.Name);
                    }
                }
                Console.Write("Result:  ");
                if (resultName.Count == 0)
                {
                    Console.Write(" Not Found");
                }
                else if (resultName.Count > 0)
                {
                    resultName.Reverse();
                    foreach (var item in resultName)
                    {
                        Console.Write(item);
                        if (check == 0 && resultName.Count != 1)
                        {
                            Console.Write(" < ");
                        }
                        check++;
                    }
                }
            }                     
        }
    }
}
