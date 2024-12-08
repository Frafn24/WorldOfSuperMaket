using System;
using System.Collections.Generic;
using System.IO;

namespace WorldOfSuperMaket.Models;

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
    public double Price { get; set; }

    public Items(string x_Name, string x_Description, string x_Type, double x_Calorie, double x_Carbo, double x_Protien, double x_Fat, double x_C02, double X_Price)
    {
        Name = x_Name;
        Description = x_Description;
        Type = x_Type;
        Calorie = x_Calorie;
        Carbo = x_Carbo;
        Protien = x_Protien;
        Fat = x_Fat;
        C02 = x_C02;
        Price = X_Price;
    }

    public string GetName()
    {
        return Name;
    }

    public double GetPrice()
    {
        return Price;
    }
    public double GetCO2()
    {
        return C02;
    }
    public string GetDescription()
    {
        return Description;
    }
    public double[] GetMacros()
    {
        double[] Macros = { Calorie,Price, Carbo, Protien, Fat,C02 };
        return Macros;
    }

    



}