using GraphModel.Node.HandleBuilder;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.NewNode.Pure;

public class PureNodeBuildable : BaseNodeBuildable
{
    private NewInputManager _inputManager = null!;
    private NewPureOutputManager _outputManager = null!;
    private Execution _execution = null!;
    protected override void ExecuteWithHandlesContext()
    {
        _execution(_outputManager, _inputManager);
    }
    
    public delegate void Execution(NewPureOutputManager outputManager, NewInputManager inputManager);
    
    public class Builder : Builder<Builder>
    {
        private Execution? _execution;
        private PureOutputHandlesBuilder _outputHandlesBuilder;

        public Builder()
        {
            _outputHandlesBuilder = new PureOutputHandlesBuilder(ExecutionContext);
        }
        
        public Builder AddOutputValue(string label, ValueType type)
        {
            _outputHandlesBuilder.AddOutputValueHandle(label, type);
            return this;
        }
        
        public Builder SetExecution(Execution? execution)
        {
            _execution = execution;
            return this;
        }

        public override INewNode Build()
        {
            var node = BaseBuild(new PureNodeBuildable());
            node.Outputs = _outputHandlesBuilder.OutputHandles.ToList();
            node._inputManager = new NewInputManager(node.Inputs);
            node._outputManager = new NewPureOutputManager(node.Outputs);
            
            if (_execution == null)
                throw new Exception("Execution is required");
            
            node._execution = _execution;
            
            return node;
        }
    }
}