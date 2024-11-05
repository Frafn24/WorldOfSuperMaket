using System;
using System.Collections.Generic;
using System.IO;

namespace WorldOfSuperMaket;

public class Items
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public double Calorie { get; set; }
    public double Carbo { get; set; }
    public double Protien { get; set; }
    public double Fat { get; set; }
    public double C02 { get; set; }

    public Items(string x_Name, string x_Description, string x_Type, double x_Calorie, double x_Carbo, double x_Protien, double x_Fat, double x_C02)
    {
        Name = x_Name;
        Description = x_Description;
        Type = x_Type;
        Calorie = x_Calorie;
        Carbo = x_Carbo;
        Protien = x_Protien;
        Fat = x_Fat;
        C02 = x_C02;
    }

    public string GetName()
    {
        return Name;
        
    }
    public string GEtDescription()
    {
        return Description;
    }
    public double[] GetMacros()
    {
        double[] Macros = {Calorie, Carbo, Protien, Fat};
        return Macros;
    }
    public double GetC02()
    {
        return C02;
    }



}