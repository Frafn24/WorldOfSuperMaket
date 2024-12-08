/* Command for transitioning between spaces
 */

using WorldOfSuperMaket;
using WorldOfSuperMaket.Readers;

class CommandGo : BaseCommand, ICommand {
  public CommandGo () {
    description = "Følg en udgang";
  }
  
  public void Execute (Context context, string command, string[] parameters) {
    if (GuardEq(parameters, 1)) {
      Console.WriteLine(Translate.Instance.GetTranslation("Wrong Input"));
      return;
    }
    context.Transition(parameters[0]);
  }
}
