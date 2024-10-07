using GraphModel.Node;

namespace GraphModel.Graph;

public class GraphModel
{
    public event Action OnGraphEnd;
    private Stack<INode> _callStack;
    
    public void RegisterNode(INode node)
    {
        
    }
}