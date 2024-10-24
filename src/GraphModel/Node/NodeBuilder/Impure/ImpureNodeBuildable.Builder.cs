using GraphModel.Handle;
using GraphModel.Handle.Value.Input;
using GraphModel.Node.HandleBuilder.Flow;
using GraphModel.Node.HandleBuilder.Value;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.Impure;

public partial class ImpureNodeBuildable
{
    public class Builder : Builder<Builder>
    {
        private Execution? _execution;
        private readonly FlowInputHandleBuilder _flowInputHandleBuilder = new();
        private readonly FlowOutputHandleBuilder _outputFlowHandleBuilder = new();
        private readonly ImpureOutputValueHandleBuilder _outputValueHandlesBuilder = new();
        
        public Builder AddOutputValue(string label, ValueType type)
        {
            _outputValueHandlesBuilder.AddValueHandle(label, type);
            return this;
        }
        
        public Builder AddOutputFlow(string label)
        {
            _outputFlowHandleBuilder.AddFlowHandle(label);
            return this;
        }
        
        public Builder AddInputFlow(string label)
        {
            _flowInputHandleBuilder.AddFlowHandle(label);
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
            node.Outputs = _outputFlowHandleBuilder.Build(node).Concat<IHandle>(_outputValueHandlesBuilder.Build(node)).ToList();
            node.Inputs = _flowInputHandleBuilder.Build(node).Concat(node.Inputs).ToList();
            
            node._outputManager = new ImpureOutputManager(node.Outputs);
            node._inputValueManager = new InputValueManager(node.Inputs.OfType<InputValueHandle>());
            
            if (_execution == null)
                throw new Exception("Execution is required");
            
            node._execution = _execution;
            
            return node;
        }
    }
}