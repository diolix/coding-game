namespace GraphModel.Node.NodeBuilder.NewNode;

public abstract partial class BaseNodeBuildable
{
    public abstract class Builder<T> where T : Builder<T>
    {
        private string? _name;
        private readonly T _thisAsT;

        public Builder()
        {
            _thisAsT = (this as T)!;
        }

        public T SetName(string? name)
        {
            _name = name;
            return _thisAsT;
        }

        public abstract INode Build();
        
        protected N BaseBuild<N>(N node) where N : BaseNodeBuildable
        {
            if (_name == null)
                throw new Exception("Name is required");

            node.Name = _name;
            return node;
        }
    }
}