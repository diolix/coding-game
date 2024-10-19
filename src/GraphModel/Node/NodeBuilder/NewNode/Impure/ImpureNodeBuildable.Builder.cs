using GraphModel.Node.HandleBuilder;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.NewNode.Impure;

public partial class ImpureNodeBuildable
{
    public class Builder : Builder<Builder>
    {
        private Execution? _execution;
        private ImpureOutputHandlesBuilder _outputHandlesBuilder;

        public Builder()
        {
            _outputHandlesBuilder = new ImpureOutputHandlesBuilder();
        }
        
        public Builder AddOutputValue(string label, ValueType type)
        {
            _outputHandlesBuilder.AddOutputValueHandle(label, type);
            return this;
        }
        
        public Builder AddOutputFlow(string label)
        {
            _outputHandlesBuilder.AddOutputFlowHandle(label);
            return this;
        }

        public Builder AddInputFlow(string label)
        {
            InputsHandlesConstructor.AddInputFlowHandle(label);
            return this;
        }

        public Builder SetExecution(Execution? execution)
        {
            _execution = execution;
            return this;
        }

        public override INewNode Build()
        {
            var node = BaseBuild(new ImpureNodeBuildable());
            node.Outputs = _outputHandlesBuilder.OutputHandles.ToList();
            node._outputManager = new NewImpureOutputManager(node.Outputs);
            node._inputManager = new NewInputManager(node.Inputs);
            
            if (_execution == null)
                throw new Exception("Execution is required");
            
            node._execution = _execution;
            
            return node;
        }
    }
}