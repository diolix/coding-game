using GraphModel.Node.HandleBuilder;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.NewNode.Impure;

public partial class ImpureNodeBuildable
{
    public class Builder : Builder<Builder>
    {
        private Execution? _execution;
        private readonly ImpureOutputHandlesBuilder _outputHandlesBuilder = new();
        private readonly ImpureInputHandlesBuilder _impureInputHandlesBuilder = new();
        
        public Builder AddOutputValue(string label, ValueType type)
        {
            _outputHandlesBuilder.AddValueHandle(label, type);
            return this;
        }
        
        public Builder AddOutputFlow(string label)
        {
            _outputHandlesBuilder.AddFlowHanlde(label);
            return this;
        }

        public Builder AddInputValue(string label, ValueType type)
        {
            _impureInputHandlesBuilder.AddValueHandle(label, type);
            return this;
        }
        
        public Builder AddInputFlow(string label)
        {
            _impureInputHandlesBuilder.AddFlowHanlde(label);
            return this;
        }

        public Builder SetExecution(Execution? execution)
        {
            _execution = execution;
            return this;
        }

        public override INode Build()
        {
            var node = BaseBuild(new ImpureNodeBuildable());
            node.Outputs = _outputHandlesBuilder.Build(node);
            node.Inputs = _impureInputHandlesBuilder.Build(node);
            
            node._outputManager = new ImpureOutputManager(node.Outputs);
            node._inputManager = new InputManager(node.Inputs);
            
            if (_execution == null)
                throw new Exception("Execution is required");
            
            node._execution = _execution;
            
            return node;
        }
    }
}