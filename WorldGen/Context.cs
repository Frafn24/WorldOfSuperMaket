/* Context class to hold all context relevant to a session.
 */

using WorldOfSuperMaket;
using WorldOfSuperMaket.Readers;

class Context {
  Space current;
  bool done = false;
  
  public Context (Space node) {
    current = node;
  }

  public Space GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) {
    Space next = current.FollowEdge(direction);
    if (next==null) {
      Console.WriteLine(Translate.Instance.GetTranslation("Direction_Confused"), direction);
    } else {
      current.Goodbye();
      current = next;
      current.Welcome();
    }
  }
  
  public void 
    MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

