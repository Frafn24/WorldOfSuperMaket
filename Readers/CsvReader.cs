using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfSuperMaket.Models;

namespace WorldOfSuperMaket
{
    internal class CsvReader
    {
        public List<Items> csvTest()
        {
            List<Items> value = new List<Items>();
            try
            {
                value = File.ReadAllLines(getPlaceMent("Items.csv")).Skip(1).Select(x => Value(x)).ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            return value;
            //string filename = "Mappe1.csv";

        }
        public Items Value(string csvLine)
        {
            string[] lines = csvLine.Split(',');
            var name = Convert.ToString(lines[0]);
            var description = Convert.ToString(lines[1]);
            var type = Convert.ToString(lines[2]);
            var Calorie = Convert.ToDouble(lines[3]);
            var Carbo = Convert.ToDouble(lines[4]);
            var Protien = Convert.ToDouble(lines[5]);
            var Fat = Convert.ToDouble(lines[6]);
            var C02 = Convert.ToDouble(lines[7]);
            //var Price = Convert.ToDouble(lines[8]);

            Items items = new Items(name, description, type, Calorie, Carbo, Protien, Fat, C02,0);
            return items;

        }
        public string getPlaceMent(string filename)
        {
            string update = "";
            string placement = Path.GetFullPath(filename);
            if (placement.Contains(@"\\data\\net8.0\"))
            {
                update = placement.Replace(@"bin\Debug", "data");
            }
            update = placement.Replace(@"bin\Debug\net8.0", "data");
            return update;
        }
    }

}
