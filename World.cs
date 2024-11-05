/* World class for modeling the entire in-game world
 */

class World
{

    Space entry = new Space("Ingang");
    Space refrigerator = new Space("Refrigerator");
    Space meats = new Space("Meats");
    Space frozen = new Space("Frozen");
    Space groceries = new Space("Groceries");
    Space bakery = new Space("Bakery");
    Space preserves = new Space("Preserves");
    Space checkout = new Space("CheckOut");
    
    private Dictionary<string, Space> spaces;
    
    public World()
    {
        
        spaces = new Dictionary<string, Space>
        {
            { "Ingang", entry },
            { "Refrigerator", refrigerator },
            { "Meats", meats },
            { "Frozen", frozen },
            { "Groceries", groceries },
            { "Bakery", bakery },
            { "Preserves", preserves },
            { "CheckOut", checkout }
        };



        entry.AddEdge("Indgang", refrigerator);


        //refrigerator's tildeling af rum man kan g� til n�r man er i refrigerator

        refrigerator.AddEdge("Meats", meats);
        refrigerator.AddEdge("Groceries", groceries);
        refrigerator.AddEdge("Frozen", frozen);
        refrigerator.AddEdge("Preserves", preserves);
        refrigerator.AddEdge("Bakery", bakery);
        refrigerator.AddEdge("Checkout", checkout);

        //meats's tildeling af rum man kan g� til n�r man er i meats

        meats.AddEdge("Refrigerator", refrigerator);
        meats.AddEdge("Groceries", groceries);
        meats.AddEdge("Frozen", frozen);
        meats.AddEdge("Preserves", preserves);
        meats.AddEdge("Bakery", bakery);
        meats.AddEdge("Checkout", checkout);


        //groceries's tildeling af rum man kan g� til n�r man er i groceries

        groceries.AddEdge("Refrigerator", refrigerator);
        groceries.AddEdge("Meats", meats);
        groceries.AddEdge("Frozen", frozen);
        groceries.AddEdge("Preserves", preserves);
        groceries.AddEdge("Bakery", bakery);
        groceries.AddEdge("Checkout", checkout);


        //frozen's tildeling af rum man kan g� til n�r man er i frozen

        frozen.AddEdge("Refrigerator", refrigerator);
        frozen.AddEdge("Meats", meats);
        frozen.AddEdge("Groceries", groceries);
        frozen.AddEdge("Preserves", preserves);
        frozen.AddEdge("Bakery", bakery);
        frozen.AddEdge("Checkout", checkout);

        //preserves's tildeling af rum man kan g� til n�r man er i preserves

        preserves.AddEdge("Refrigerator", refrigerator);
        preserves.AddEdge("Meats", meats);
        preserves.AddEdge("Groceries", groceries);
        preserves.AddEdge("Frozen", frozen);
        preserves.AddEdge("Bakery", bakery);
        preserves.AddEdge("Checkout", checkout);

        //bakery's tildeling af rum man kan g� til n�r man er i bakery

        bakery.AddEdge("Refrigerator", refrigerator);
        bakery.AddEdge("Meats", meats);
        bakery.AddEdge("Groceries", groceries);
        bakery.AddEdge("Frozen", frozen);
        bakery.AddEdge("Preserves", preserves);
        bakery.AddEdge("Checkout", checkout);

        //Checkout's tildeling af rum man kan g� til n�r man er i Checkout
        checkout.AddEdge("Refrigerator", refrigerator);
        checkout.AddEdge("Meats", meats);
        checkout.AddEdge("Groceries", groceries);
        checkout.AddEdge("Frozen", frozen);
        checkout.AddEdge("Preserves", preserves);
        checkout.AddEdge("Bakery", bakery);

        this.entry = entry;

    }
    
    //Gives the current space
    public Space GetSpaceType(string type)
    {
        spaces.TryGetValue(type, out Space target);
        return target;
    }

    public Space GetEntry()
    {
        return entry;
    }
    
}

