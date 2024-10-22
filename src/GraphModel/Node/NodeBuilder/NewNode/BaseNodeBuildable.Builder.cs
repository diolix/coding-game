using GraphModel.Node.HandleBuilder;

namespace GraphModel.Node.NodeBuilder.NewNode;

public abstract partial class BaseNodeBuildable
{
    public abstract class Builder<T> where T : Builder<T>
    {
        private string? _name;
        protected readonly InputHandlesBuilder InputsHandlesConstructor;
        private T _thisAsT;

        public Builder()
        {
            InputsHandlesConstructor = new InputHandlesBuilder();
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
            // very important to build inputs first and store them in a variable
            var inputsBuilt = InputsHandlesConstructor.Build(node);
            node.Inputs = inputsBuilt;

            if (_name == null)
                throw new Exception("Name is required");

            node.Name = _name;
            return node;
        }
    }
}