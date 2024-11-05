namespace WorldOfSuperMaket
{
    public class CommandPickUp : BaseCommand
    {
        private Inventory.Inventory inventory;

        public void CommandPickup(Inventory.Inventory inventory)
        {
            this.inventory = inventory;
            description = "Put an item into your cart";
        }
        
        public void execute(Items[] items, Context context, string command, string[] parameters)
        {
            if (parameters.Length == 0)
            {
                Console.WriteLine("Please specify the item you want to put in your cart.");
                return;
            }

            string itemName = parameters[0];
            
            foreach (var item in CurrentLocation)
            {
                
                Items itemToPickUp = context.CurrentLocation.item.Getname(itemName);


                if (itemToPickUp != null)
                {
                    inventory.Add(itemToPickUp);
                    Console.WriteLine($"You have put {itemName} into your cart.");
                }
                else
                {
                    Console.WriteLine($"The item '{itemName}' is not available.");
                }
            }
        }
    }
}
