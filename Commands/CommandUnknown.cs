/* Fallback for when a command is not implemented
 */

using WorldOfSuperMaket;

class CommandUnknown : BaseCommand, ICommand {
  public void Execute (Context context, string command, string[] parameters) {
      Console.WriteLine(Translate.Instance.GetTranslation("CommandUnknown"));
  }
}
