using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder;

public partial class NodeBuildable
{
    public class Builder
    {
        private string _name;
        private bool _isPure;
        private Action<HandlesExecution> _execution;
        private NewHandlesBuilder _inputsHandlesConstructor;
        private NewHandlesBuilder _outputsHandlesConstructor;
        
        public Builder()
        {
            _inputsHandlesConstructor = new NewHandlesBuilder();
            _outputsHandlesConstructor = new NewHandlesBuilder();
        }

        public Builder AddOutputFlow(string label)
        {
            _outputsHandlesConstructor.AddFlow(label);
            return this;
        }

        public Builder AddOutputValue(string label, ValueType type)
        {
            _outputsHandlesConstructor.AddValue(label, type);
            return this;
        }
        
        public Builder AddInputFlow(string label)
        {
            _inputsHandlesConstructor.AddFlow(label);
            return this;
        }
        
        public Builder AddInputValue(string label, ValueType type)
        {
            _inputsHandlesConstructor.AddValue(label, type);
            return this;
        }
        
        public Builder SetName(string name)
        {
            _name = name;
            return this;
        }

        public Builder SetIsPure(bool isPure)
        {
            _isPure = isPure;
            return this;
        }

        public Builder SetExecution(Action<HandlesExecution> execution)
        {
            _execution = execution;
            return this;
        }

        public NodeBuildable Build()
        {
            var node = new NodeBuildable();
            var inputManager = new InputManager(_inputsHandlesConstructor.BuildHandles(node));
            var outputManager = new OutputManager(_outputsHandlesConstructor.BuildHandles(node));
            
            node.Name = _name;
            node.IsPure = _isPure;
            node.Output = outputManager;
            node.Input = inputManager;
            node._handlesExecution = new HandlesExecution(inputManager, outputManager, node.OnLastExecution);
            node._execution = _execution;
            return node;
        }
    }
}