using GraphModel.Handle.Value.Input;
using GraphModel.Node.HandleBuilder.Value;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.Pure;

public class PureNodeBuildable : BaseNodeBuildable
{
    private InputValueManager _inputValueManager = null!;
    private PureOutputManager _outputManager = null!;
    private Execution _execution = null!;
    protected override void ExecuteWithHandlesContext()
    {
        _execution(_outputManager, _inputValueManager);
    }
    
    public delegate void Execution(PureOutputManager outputManager, InputValueManager inputValueManager);
    
    public class Builder : Builder<Builder>
    {
        private Execution? _execution;
        private readonly PureOutputValueHandleBuilder _outputHandlesBuilder = new();
        
        public Builder AddOutputValue(string label, ValueType type)
        {
            _outputHandlesBuilder.AddValueHandle(label, type);
            return this;
        }
        
        public Builder SetExecution(Execution? execution)
        {
            _execution = execution;
            return this;
        }

        public override INode Build()
        {
            var node = BaseBuild(new PureNodeBuildable());
            node.Outputs = _outputHandlesBuilder.Build(node);
            
            node._inputValueManager = new InputValueManager(node.Inputs.OfType<InputValueHandle>());
            node._outputManager = new PureOutputManager(node.Outputs);
            
            if (_execution == null)
                throw new Exception("Execution is required");
            
            node._execution = _execution;
            
            return node;
        }
    }
}