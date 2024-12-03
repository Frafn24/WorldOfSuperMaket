using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfSuperMaket.data;

namespace WorldOfSuperMaket
{
    internal class CsvReader
    {
        public void csvTest()
        {

            List<Items> value = File.ReadAllLines(GetPlacement("Mappe1.csv")).Skip(1).Select(x => Value(x)).ToList();
            //string filename = "Mappe1.csv";

            foreach (var item in value)
            {
                Console.WriteLine(item.Name);
            }
        }
        public Items Value(string csvLine)
        {
            string[] lines = csvLine.Split(';');
            var name = Convert.ToString(lines[0]);
            var description = Convert.ToString(lines[1]);
            var type = Convert.ToString(lines[2]);
            var Calorie = Convert.ToDouble(lines[3]);
            var Carbo = Convert.ToDouble(lines[4]);
            var Protien = Convert.ToDouble(lines[5]);
            var Fat = Convert.ToDouble(lines[6]);
            var C02 = Convert.ToDouble(lines[7]);
            var Price = Convert.ToDouble(lines[8]);

            Items items = new Items(name, description, type, Calorie, Carbo, Protien, Fat, C02, Price);
            return items;

        }
        public string GetPlacement(string filename)
        {
            string placement = Path.GetFullPath(filename);
            var update = placement.Replace(@"bin\Debug", "data");
            return update;
        }
    }

}
