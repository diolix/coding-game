using CodingGame.Script.Graph.Model.Node.BaseNodes;
using GraphModel.Node.BaseNodes;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder;

public partial class NodeBuildable : INode
{
    public string Name { get; private set; }
    public bool IsPure { get; private set; }
    public event Action OnLastExecution;
    public IOutputManager Output { get; private set; }
    public IInputManager Input { get; private set; }
    private HandlesExecution _handlesExecution;
    private Action<HandlesExecution> _execution;
    
    private NodeBuildable(){}
    
    public void Configure() { }
    public void Execute() => _execution(_handlesExecution);
}