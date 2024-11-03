/* Space class for modeling spaces (rooms, caves, ...)
 */

using WorldOfSuperMaket;

class Space : Node
{
  private CheckOut checkOut = new CheckOut();
  public Space (String name) : base(name)
  {
  }
  
  public void Welcome () {
    Console.WriteLine("You are now at "+name);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
  }

  public void Checkout(CheckOut checkOut, double RequiredCal, double DailyFat, double DailyCarbs, double DailyProteins, double Klimaneutral)
  {
    double CaloriesInCart = inventory.Sum(i => i.Calories);
    
    bool EnoughCalories = CaloriesInCart >= RequiredCal;
    
    if (name.Equals("Checkout") && EnoughCalories)
    {
      checkOut.DoCheckout(inventory, DailyFat, DailyCarbs, DailyProteins, Klimaneutral);
    }
    else
    {
      Console.WriteLine("You do not have enough calories to go to checkout");
    }
  }
    public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }
}
