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
    
    public abstract class Builder
    {
        protected string Label;
        protected int Index;
        protected INode Node;

        public Builder SetLabel(string label)
        {
            Label = label;
            return this;
        }

        public Builder SetIndex(int index)
        {
            Index = index;
            return this;
        }

        public Builder SetNode(INode node)
        {
            Node = node;
            return this;
        }

        public abstract NewHandleModel Build();
    }
}