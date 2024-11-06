/* Command for transitioning between spaces
 */

class CommandGo : BaseCommand, ICommand {
  public CommandGo () {
    description = "Følg en udgang";
  }
  
  public void Execute (Context context, string command, string[] parameters) {
    if (GuardEq(parameters, 1)) {
      Console.WriteLine("Jeg kan ikke finde ud af hvor det er henne? 🤔");
      return;
    }
    context.Transition(parameters[0]);
  }
}
