using GraphModel.Handle;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.Node.NodeBuilder;

public class NewHandleModel : IHandle
{
    public string Label { get; }
    public int Index { get; }
    public INode Node { get; }
    public ColorHex Color { get; }
    public bool IsCompatible(IHandle handle)
    {
        return true;
    }

    private NewHandleModel(string label, int index, INode node, ColorHex color)
    {
        Label = label;
        Index = index;
        Node = node;
        Color = color;
    }
    
    public class Builder
    {
        private string _label;
        private int _index;
        private INode _node;
        private ColorHex _color;

        public Builder SetLabel(string label)
        {
            _label = label;
            return this;
        }

        public Builder SetIndex(int index)
        {
            _index = index;
            return this;
        }

        public Builder SetNode(INode node)
        {
            _node = node;
            return this;
        }

        public Builder SetColor(ColorHex color)
        {
            _color = color;
            return this;
        }

        public NewHandleModel Build()
        {
            return new NewHandleModel(_label, _index, _node, _color);
        }        
    }
}