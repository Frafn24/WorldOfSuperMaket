using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfSuperMaket.Models
{
    public class UserInfo
    {
        public string Username { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public int Weaght { get; set; }
        public string Gender { get; set; }
        public int DaliyCalo { get; set; }
        public int DaliyKullhydrat { get; set; }
        public int DaliyProtien { get; set; }
        public int DaliyFat { get; set; }

        public UserInfo(string x_Username)
        {
            Username = x_Username;
            Age = 22;
            Height = 1.65;
            Weaght = 70;
            Gender = "none";
            DaliyCalo = Convert.ToInt32(Math.Round(calcCalo(1.65, 70), 0));

            //if (Gender.Length > 4)
            //{
            //    DaliyCalo = calcCalo(true, x_Height, x_Weaght);

            //}
            //else
            //{
            //    DaliyCalo = calcCalo(false, x_Height, x_Weaght);
            //}
            DaliyKullhydrat = Convert.ToInt32(Math.Round(caleKulhydrat(DaliyCalo, 70),0));
            DaliyProtien = Convert.ToInt32(Math.Round(caleProtien(DaliyCalo),0));
            DaliyFat = Convert.ToInt32(Math.Round(caleFat(DaliyCalo),0));

        }

        double calcCalo(double Height, int Weaght)
        {
            double calo = 0;
            calo = Weaght * 30.43 + Height * 1.97 + (67 - Age * 6.8);
            return calo;
            //if (gender == true)
            //{
            //    calo = Weaght * 30.43 + Height * 1.97 + (67 - Age * 6.8);
            //    return calo;
            //}
            //else
            //{
            //    calo = Weaght * 21.17 + Height * 0.71 + (655 - Age * 4.7);
            //    return calo;
            //}
        }
        double caleKulhydrat(double daliyCalo, int weaght)
        {
            var inventory = daliyCalo / 100 * 30 / 4.2;
            return inventory;
        }
        double caleProtien(double daliyCalo)
        {
            var inventory = daliyCalo / 100 * 55 / 4.2;
            return inventory;
        }
        double caleFat(double daliyCalo)
        {
            var inventory = daliyCalo / 100 * 10 / 9.1;
            return inventory;
        }
    }
}
