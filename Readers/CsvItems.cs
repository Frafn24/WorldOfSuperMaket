﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfSuperMaket.Models;

namespace WorldOfSuperMaket
{
    public class CsvItems
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
            var Calorie = Convert.ToDecimal(lines[3]);
            var Carbo = Convert.ToDecimal(lines[4]);
            var Protien = Convert.ToDecimal(lines[5]);
            var Fat = Convert.ToDecimal(lines[6]);
            var C02 = Convert.ToDecimal(lines[7]);
            var Price = Convert.ToDecimal(lines[8]);

            Items items = new Items(name, description, type, Calorie, Carbo, Protien, Fat, C02, Price);
            return items;

        }
        public string getPlaceMent(string filename)
        {
            string update = "";
            string placement = Path.GetFullPath(filename);
            //string xmlFile = HostingEnvironment.MapPath("filename");
            if (placement.Contains(@"\\data\\net8.0\"))
            {
                update = placement.Replace(@"bin\Debug", "data");
            }
            update = placement.Replace(@"bin\Debug\net8.0", "data");
            return update;
        }
    }

}
