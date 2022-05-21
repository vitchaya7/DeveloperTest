using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestDB
{
    public class Data
    {
        private static void Main(string[] args)
        {
            using (var db = new DBContext())
            {
                //string[] name = new string[3];
                //name[0] = "Lee:7:5:1890";
                //name[1] = "Robert:10:7:1920";
                //name[2] = "Kris:26:10:1944";
                //foreach (string data in name)
                //{
                //    string[] nameSplit = data.Split(':');
                //    var NameFamily = new NameIndex
                //    {
                //        Name = nameSplit[0],
                //        Day = Int32.Parse(nameSplit[1]),
                //        Month = Int32.Parse(nameSplit[2]),
                //        Year = Int32.Parse(nameSplit[3])

                //    };
                //    db.NameIndexs.Add(NameFamily);
                //    db.SaveChanges();
                //}
                var query = from b in db.NameIndexs
                            orderby b.Name
                            select b;

                Console.WriteLine("List Name in Database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
    public class NameIndex
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }

    public class DBContext : DbContext
    {
        public DbSet<NameIndex> NameIndexs { get; set; }
    }
}