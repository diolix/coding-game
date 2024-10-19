using GraphModel.Node.HandleBuilder;
using ExecutionContext = GraphModel.NewHandle.ExecutionContext;

namespace GraphModel.Node.NodeBuilder.NewNode;

public abstract partial class BaseNodeBuildable
{
    public abstract class Builder<T> where T : Builder<T>
    {
        private string? _name;
        protected readonly NewInputHandlesBuilder InputsHandlesConstructor;
        protected readonly ExecutionContext ExecutionContext;
        private T _thisAsT;

        public Builder()
        {
            ExecutionContext = new ExecutionContext();
            InputsHandlesConstructor = new NewInputHandlesBuilder(ExecutionContext);
            _thisAsT = (this as T)!;
        }

        public T AddInputValue(string label, ValueType type)
        {
            InputsHandlesConstructor.AddInputValueHandle(label, type);
            return _thisAsT;
        }

        public T SetName(string? name)
        {
            _name = name;
            return _thisAsT;
        }

        public abstract INewNode Build();
        
        protected N BaseBuild<N>(N node) where N : BaseNodeBuildable
        {
            node.InputHandles = InputsHandlesConstructor.InputHandles.ToList();

            if (_name == null)
                throw new Exception("Name is required");

            node.Name = _name;

            ExecutionContext.OnExecute += node.Execute;

            return node;
        }
    }
}