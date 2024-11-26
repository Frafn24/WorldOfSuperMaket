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
        public int Height { get; set; }
        public int Weaght { get; set; }
        public string Gender { get; set; }
        public double DaliyCalo { get; set; }
        public double DaliyKullhydrat { get; set; }
        public double DaliyProtien { get; set; }
        public double DaliyFat { get; set; }

        public UserInfo(string x_Username, int x_Age, int x_Height, int x_Weaght, string x_Gender)
        {
            Username = x_Username;
            Age = x_Age;
            Height = x_Height;
            Weaght = x_Weaght;
            Gender = x_Gender;
            if (Gender.Length > 4)
            {
                DaliyCalo = calcCalo(true, x_Height, x_Weaght);

            }
            else
            {
                DaliyCalo = calcCalo(false, x_Height, x_Weaght);
            }
            DaliyKullhydrat = caleKulhydrat(DaliyCalo, x_Weaght);
            DaliyProtien = caleProtien(DaliyCalo);
            DaliyFat = caleFat(DaliyCalo);

        }

        double calcCalo(bool gender, int Height, int Weaght)
        {
            double calo = 0;
            if (gender == true)
            {
                calo = Weaght * 30.43 + Height * 1.97 + (67 - Age * 6.8);
                return calo;
            }
            else
            {
                calo = Weaght * 21.17 + Height * 0.71 + (655 - Age * 4.7);
                return calo;
            }
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
