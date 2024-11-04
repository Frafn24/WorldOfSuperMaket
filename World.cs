/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  
  public World () {
    //Space entry    = new Space("Entry");
    //Space corridor = new Space("Corridor");
    //Space cave     = new Space("Cave");
    //Space pit      = new Space("Darkest Pit");
    //Space outside  = new Space("Outside");
        Space refrigerator = new Space("Refrigerator");
        Space meats = new Space("Meats");
        Space frozen = new Space("Frozen");
        Space groceries = new Space("Groceries");
        Space bakery = new Space("Bakery");
        Space preserves = new Space("Preserves");

    
    //entry.AddEdge("door", corridor);
    //corridor.AddEdge("door", cave);
    //cave.AddEdge("north", pit);
    //cave.AddEdge("south", outside);
    //pit.AddEdge("door", cave);
    //outside.AddEdge("door", cave);
        refrigerator.AddEdge("Refrigerator", refrigerator);
        meats.AddEdge("Meats", meats);
        frozen.AddEdge("Frozen", frozen);
        groceries.AddEdge("Groceries", groceries);
        bakery.AddEdge("Bakery", bakery);
        preserves.AddEdge("Preserves", preserves);

    
    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

