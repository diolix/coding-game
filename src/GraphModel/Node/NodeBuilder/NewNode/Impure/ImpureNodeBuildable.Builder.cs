using GraphModel.Node.HandleBuilder;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.NewNode.Impure;

public partial class ImpureNodeBuildable
{
    public class ImpureNodeBuilder : Builder<ImpureNodeBuilder>
    {
        private ImpureExecution? _execution;
        private ImpureOutputHandlesBuilder _outputHandlesBuilder;

        public ImpureNodeBuilder()
        {
            _outputHandlesBuilder = new ImpureOutputHandlesBuilder();
        }
        
        public ImpureNodeBuilder AddOutputValue(string label, ValueType type)
        {
            _outputHandlesBuilder.AddOutputValueHandle(label, type);
            return this;
        }
        
        public ImpureNodeBuilder AddOutputFlow(string label)
        {
            _outputHandlesBuilder.AddOutputFlowHandle(label);
            return this;
        }

        public ImpureNodeBuilder AddInputFlow(string label)
        {
            InputsHandlesConstructor.AddInputFlowHandle(label);
            return this;
        }

        public ImpureNodeBuilder SetExecution(ImpureExecution? execution)
        {
            _execution = execution;
            return this;
        }

        public override INewNode Build()
        {
            var node = BaseBuild(new ImpureNodeBuildable());
            node.OutputHandles = _outputHandlesBuilder.OutputHandles.ToList();
            node._outputManager = new NewImpureOutputManager(node.OutputHandles);
            node._inputManager = new NewInputManager(node.InputHandles);
            
            if (_execution == null)
                throw new Exception("Execution is required");
            
            node._execution = _execution;
            
            return node;
        }
    }
}