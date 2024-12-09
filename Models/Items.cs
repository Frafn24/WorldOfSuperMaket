using System;
using System.Collections.Generic;
using System.IO;

namespace WorldOfSuperMaket.Models;

public class Items
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public decimal Calorie { get; set; }
    public decimal Carbo { get; set; }
    public decimal Protien { get; set; }
    public decimal Fat { get; set; }
    public decimal C02 { get; set; }
    public decimal Price { get; set; }

    public Items(string x_Name, string x_Description, string x_Type, decimal x_Calorie, decimal x_Carbo, decimal x_Protien, decimal x_Fat, decimal x_C02, decimal X_Price)
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

    public decimal GetPrice()
    {
        return Price;
    }
    public decimal GetCO2()
    {
        return C02;
    }
    public string GetDescription()
    {
        return Description;
    }
    public decimal[] GetMacros()
    {
        decimal[] Macros = { Calorie,Price, Carbo, Protien, Fat, C02 };
        return Macros;
    }

    



}