using WorldOfSuperMaket.Readers;

namespace WorldOfSuperMaket
{
    public class CommandPickUp : BaseCommand, ICommand
    {
        public CommandPickUp()
        {
            description = "Læg en vare i kurven.";

        }

        void ICommand.Execute(Context context, string command, string[] parameters)
        {
            if (GuardEq(parameters, 1))
            {
                Console.WriteLine(Translate.Instance.GetTranslation("Wrong Input"));
                return;
            }
            context.Transition(parameters[0]);
        }

    }
}
