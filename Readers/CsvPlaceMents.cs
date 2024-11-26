using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfSuperMaket.Readers
{
    public class CsvPlaceMents
    {
        public string getPlaceMent(string filename)
        {
            string placement = Path.GetFullPath(filename);
            var update = placement.Replace(@"bin\Debug", "data");
            return update;
        }
    }
}
