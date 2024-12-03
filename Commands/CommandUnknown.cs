/* Fallback for when a command is not implemented
 */

class CommandUnknown : BaseCommand, ICommand {
  public void Execute (Context context, string command, string[] parameters) {
      
      try {
            Console.WriteLine($"Woopsie, det forstår jeg ikke '{command}' 😕");
            Thread.Sleep(500);
      }
      catch (Exception)
      {
          Console.WriteLine("Hov, der var vist en fejl");
          Thread.Sleep(500);
          throw;
      }
    
  }
}
