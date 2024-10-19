using GraphModel.Node.HandleBuilder;
using GraphModel.Node.Input;
using GraphModel.Node.Output;
using ExecutionContext = GraphModel.NewHandle.Flow.ExecutionContext;

namespace GraphModel.Node.NodeBuilder.NewNode;

public partial class NewNodeBuildable
{
    public class Builder
    {
        private string? _name;
        private Action<NewHandlesExecution>? _execution;
        private readonly NewInputHandlesBuilder _inputsHandlesConstructor;
        private readonly NewOutputHandlesBuilder _outputsHandlesConstructor;
        private readonly ExecutionContext _executionContext;

        public Builder()
        {
            _executionContext = new ExecutionContext();
            _inputsHandlesConstructor = new NewInputHandlesBuilder(_executionContext);
            _outputsHandlesConstructor = new NewOutputHandlesBuilder();
        }

        public Builder AddOutputFlow(string label)
        {
            _outputsHandlesConstructor.AddOutputFlowHandle(label);
            return this;
        }

        public Builder AddOutputValue(string label, ValueType type)
        {
            _outputsHandlesConstructor.AddOutputValueHandle(label, type);
            return this;
        }

        public Builder AddInputFlow(string label)
        {
            _inputsHandlesConstructor.AddInputFlowHandle(label);
            return this;
        }

        public Builder AddInputValue(string label, ValueType type)
        {
            _inputsHandlesConstructor.AddInputValueHandle(label, type);
            return this;
        }

        public Builder SetName(string? name)
        {
            _name = name;
            return this;
        }

        public Builder SetExecution(Action<NewHandlesExecution>? execution)
        {
            _execution = execution;
            return this;
        }

        public NewNodeBuildable Build()
        {
            var node = new NewNodeBuildable();
            var inputManager = new NewInputManager(_inputsHandlesConstructor.InputHandles);
            var outputManager = new NewOutputManager(_outputsHandlesConstructor.OutputHandles);

            node.InputHandles = inputManager.Handles.ToList();
            node.OutputHandles = outputManager.Handles.ToList();
            
            if (_name == null)
                throw new Exception("Name is required");
            
            node.Name = _name;
            node._handlesExecution = new NewHandlesExecution(inputManager, outputManager);
            
            if (_execution == null)
                throw new Exception("Execution is required");
            
            node._execution = _execution;
            
            _executionContext.OnExecute += node.Execute;
            
            return node;
        }
    }
}