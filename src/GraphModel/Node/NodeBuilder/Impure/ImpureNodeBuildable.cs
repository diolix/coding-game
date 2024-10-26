using GraphModel.Node.ExecutionManager.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.Impure;

public partial class ImpureNodeBuildable : BaseNodeBuildable
{
    private ImpureOutputManager _outputManager = null!;
    private InputValueManager _inputValueManager = null!;
    private Execution _execution = null!;
    protected override void ExecuteWithHandlesContext()
    {
        _execution(_outputManager, _inputValueManager);
    }
    
    public delegate void Execution(ImpureOutputManager outputManager, InputValueManager inputValueManager);
}