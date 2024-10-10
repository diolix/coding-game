using GraphModel.Edge;
using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle;

public abstract class BaseHandleModel : IHandle
{
    private Action _onExecute;
    public string Label { get; }
    Action IHandle.OnExecute => _onExecute;

    public int Index { get; }
    public INode Node { get; }
    public event Action OnExecute;
    public void Execute(){}
    public abstract ColorHex Color { get; }
    public bool IsCompatible(IHandle handle)
    {
        return true;
    }

    public void AddEdge(IEdge edge)
    {
        return;
    }

    public void RemoveEdge(IEdge edge)
    {
        throw new NotImplementedException();
    }

    public void SetInputValue(object value)
    {
        throw new NotImplementedException();
    }

    public BaseHandleModel(string label, int index, INode node)
    {
        Label = label;
        Index = index;
        Node = node;
    }
    
    public abstract class Builder<T> where T : Builder<T>
    {
        protected string Label;
        protected int Index;
        protected INode Node;
        protected abstract T This { get; }
        
        public T SetLabel(string label)
        {
            Label = label;
            return This;
        }

        public T SetIndex(int index)
        {
            Index = index;
            return This;
        }

        public T SetNode(INode node)
        {
            Node = node;
            return This;
        }

        public abstract BaseHandleModel Build();
    }
}