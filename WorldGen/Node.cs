/* Node class for modeling graphs
 */

class Node {
  protected string name;
  protected Dictionary<string, Node> edges = new Dictionary<string, Node>();
  
  public Node (string name) {
    this.name = name;
  }
  
  public String GetName () {
    return name;
  }
  
  public void AddEdge (string name, Node node) {
    edges.Add(name, node);
  }
  
  public virtual Node FollowEdge (string direction) {
		try
		{

            return edges[direction];
        }
		catch (Exception)
		{
            Console.WriteLine("Tjek om du har skrevet forkert og prøv igen");
            return null;
		}
  }
}

