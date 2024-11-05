namespace WorldOfSuperMaket
{
    public class CommandPickUp : BaseCommand, ICommand
    {
        //private Inventory.Inventory inventory;
        public CommandPickUp()
        {
            description = "Put an item into your cart";

        }

        void ICommand.Execute(Context context, string command, string[] parameters)
        {
            if (GuardEq(parameters, 1))
            {
                Console.WriteLine("I don't seem to know where that is 🤔");
                return;
            }
            context.Transition(parameters[0]);
        }

        //public cl CommandPickup(Inventory.Inventory inventory)
        //{
        //    this.inventory = inventory;
        //}


        //if (parameters.Length == 0)
        //{
        //    Console.WriteLine("Please specify the item you want to put in your cart.");
        //    //return;
        //}

        //string itemName = parameters[0];

        //foreach (var item in CurrentLocation)
        //{

        //    Items itemToPickUp = context.CurrentLocation.item.Getname(itemName);


        //    if (itemToPickUp != null)
        //    {
        //        inventory.Add(itemToPickUp);
        //        Console.WriteLine($"You have put {itemName} into your cart.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"The item '{itemName}' is not available.");
        //    }
        //}

    }
}
