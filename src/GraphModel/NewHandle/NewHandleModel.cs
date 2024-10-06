using GraphModel.Handle;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.NewHandle;

public abstract class NewHandleModel : IHandle
{
    public string Label { get; }
    public int Index { get; }
    public INode Node { get; }
    public abstract ColorHex Color { get; }
    public bool IsCompatible(IHandle handle)
    {
        return true;
    }

    public NewHandleModel(string label, int index, INode node)
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

        public abstract NewHandleModel Build();
    }
}