using GraphModel.Node.HandleBuilder.Value;
using GraphModel.Values;

namespace GraphModel.Node.NodeBuilder;

public abstract partial class BaseNodeBuildable
{
    public abstract class Builder<T> where T : Builder<T>
    {
        private string? _name;
        private readonly T _thisAsT;
        private InputValueHandleBuilder _inputValueHandleBuilder = new();

        public Builder()
        {
            _thisAsT = (this as T)!;
        }

        public T SetName(string? name)
        {
            _name = name;
            return _thisAsT;
        }

        public virtual T AddInputValue(string label, ValueTypeEnum valueType)
        {
            _inputValueHandleBuilder.AddValueHandle(label, valueType);
            return _thisAsT;
        }
        
        public virtual T AddInputValueWithField(string label, ValueTypeEnum valueType)
        {
            _inputValueHandleBuilder.AddInputHandleWithField(label, valueType);
            return _thisAsT;
        }
        
        public abstract INode Build();
        
        protected N BaseBuild<N>(N node) where N : BaseNodeBuildable
        {
            if (_name == null)
                throw new Exception("Name is required");

            node.Name = _name;
            node.Inputs = _inputValueHandleBuilder.Build(node).ToList();
            return node;
        }
    }
}