/* World class for modeling the entire in-game world
 */

class World
{

    Space entry = new Space("Indgang");
    Space refrigerator = new Space("Køleafdeling");
    Space meats = new Space("Kødafdeling");
    Space frozen = new Space("Frostafdeling");
    Space groceries = new Space("Grøntafdeling");
    Space bakery = new Space("Brød");
    Space preserves = new Space("Konserves");
    Space checkout = new Space("Kassen");
    
    private Dictionary<string, Space> spaces;
    
    public World()
    {
        
        spaces = new Dictionary<string, Space>
        {
            { "Indgang", entry },
            { "Køleafdeling", refrigerator },
            { "Kødafdeling", meats },
            { "Frostafdeling", frozen },
            { "Grøntafdeling", groceries },
            { "Brød", bakery },
            { "Konserves", preserves },
            { "Kassen", checkout }
        };



        entry.AddEdge("Indgang", refrigerator);


        //refrigerator's tildeling af rum man kan g� til n�r man er i refrigerator

        refrigerator.AddEdge("Kødafdeling", meats);
        refrigerator.AddEdge("Grøntafdeling", groceries);
        refrigerator.AddEdge("Frostafdeling", frozen);
        refrigerator.AddEdge("Konserves", preserves);
        refrigerator.AddEdge("Brød", bakery);
        refrigerator.AddEdge("Kassen", checkout);

        //meats's tildeling af rum man kan g� til n�r man er i meats

        meats.AddEdge("Køleafdeling", refrigerator);
        meats.AddEdge("Grøntafdeling", groceries);
        meats.AddEdge("Frostafdeling", frozen);
        meats.AddEdge("Konserves", preserves);
        meats.AddEdge("Bager", bakery);
        meats.AddEdge("Kassen", checkout);


        //groceries's tildeling af rum man kan g� til n�r man er i groceries

        groceries.AddEdge("Køleafdeling", refrigerator);
        groceries.AddEdge("Kødafdeling", meats);
        groceries.AddEdge("Frostafdeling", frozen);
        groceries.AddEdge("Konserves", preserves);
        groceries.AddEdge("Food", bakery);
        groceries.AddEdge("Kassen", checkout);


        //frozen's tildeling af rum man kan g� til n�r man er i frozen

        frozen.AddEdge("Køleafdeling", refrigerator);
        frozen.AddEdge("Kødafdeling", meats);
        frozen.AddEdge("Grøntafdeling", groceries);
        frozen.AddEdge("Konserves", preserves);
        frozen.AddEdge("Brød", bakery);
        frozen.AddEdge("Kassen", checkout);

        //preserves's tildeling af rum man kan g� til n�r man er i preserves

        preserves.AddEdge("Køleafdeling", refrigerator);
        preserves.AddEdge("Kødafdeling", meats);
        preserves.AddEdge("Grøntafdeling", groceries);
        preserves.AddEdge("Frostafdeling", frozen);
        preserves.AddEdge("Brød", bakery);
        preserves.AddEdge("Kassen", checkout);

        //bakery's tildeling af rum man kan g� til n�r man er i bakery

        bakery.AddEdge("Køleafdeling", refrigerator);
        bakery.AddEdge("Kødafdeling", meats);
        bakery.AddEdge("Grøntafdeling", groceries);
        bakery.AddEdge("Frostafdeling", frozen);
        bakery.AddEdge("Konserves", preserves);
        bakery.AddEdge("Kassen", checkout);

        //Checkout's tildeling af rum man kan g� til n�r man er i Checkout
        checkout.AddEdge("Køleafdeling", refrigerator);
        checkout.AddEdge("Kødafdeling", meats);
        checkout.AddEdge("Grøntafdeling", groceries);
        checkout.AddEdge("Frostafdeling", frozen);
        checkout.AddEdge("Konserves", preserves);
        checkout.AddEdge("Brød", bakery);

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

