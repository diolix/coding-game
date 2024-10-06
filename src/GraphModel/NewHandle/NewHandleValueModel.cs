using CodingGame.Script.Graph.Model.Handle.HandleValue;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.NewHandle;

public class NewHandleValueModel : NewHandleModel, IHandleValue
{
    public override ColorHex Color { get;}
    public ValueType Type { get; }
    private NewHandleValueModel(string label, int index, INode node, ValueType type) : base(label, index, node)
    {
        Type = type;
        Color = type.GetColor();
    }
    
    public class Builder : NewHandleModel.Builder
    {
        public Builder SetType(ValueType type)
        {
            _type = type;
            return this;
        }

        public override NewHandleModel Build()
        {
            return new NewHandleValueModel(Label, Index, Node, _type);
        }
    }
}