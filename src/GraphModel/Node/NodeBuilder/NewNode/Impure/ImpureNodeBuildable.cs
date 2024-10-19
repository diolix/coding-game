using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.NewNode.Impure;

public partial class ImpureNodeBuildable : BaseNodeBuildable
{
    private NewImpureOutputManager _outputManager = null!;
    private NewInputManager _inputManager = null!;
    private ImpureExecution _execution = null!;
    protected override void ExecuteWithHandlesContext()
    {
        _execution(_outputManager, _inputManager);
    }
    
    public delegate void ImpureExecution(NewImpureOutputManager outputManager, NewInputManager inputManager);
}