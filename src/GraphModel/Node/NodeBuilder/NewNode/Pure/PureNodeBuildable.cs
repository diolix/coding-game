using GraphModel.Node.HandleBuilder;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.NewNode.Pure;

public class PureNodeBuildable : BaseNodeBuildable
{
    private NewInputManager _inputManager = null!;
    private NewPureOutputManager _outputManager = null!;
    private PureNodeExecution _execution = null!;
    protected override void ExecuteWithHandlesContext()
    {
        _execution(_inputManager, _outputManager);
    }
    
    public delegate void PureNodeExecution(NewInputManager inputManager, NewPureOutputManager outputManager);
    
    public class PureNodeBuilder : Builder<PureNodeBuilder>
    {
        private PureNodeExecution? _execution;
        private PureOutputHandlesBuilder _outputHandlesBuilder;

        public PureNodeBuilder()
        {
            _outputHandlesBuilder = new PureOutputHandlesBuilder(ExecutionContext);
        }
        
        public PureNodeBuilder AddOutputValue(string label, ValueType type)
        {
            _outputHandlesBuilder.AddOutputValueHandle(label, type);
            return this;
        }
        
        public PureNodeBuilder SetExecution(PureNodeExecution? execution)
        {
            _execution = execution;
            return this;
        }

        public override INewNode Build()
        {
            var node = BaseBuild(new PureNodeBuildable());
            node.OutputHandles = _outputHandlesBuilder.OutputHandles.ToList();
            node._inputManager = new NewInputManager(node.InputHandles);
            node._outputManager = new NewPureOutputManager(node.OutputHandles);
            
            if (_execution == null)
                throw new Exception("Execution is required");
            
            node._execution = _execution;
            
            return node;
        }
    }
}