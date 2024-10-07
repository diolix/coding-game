using GraphModel.Node;
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
    
    public class HandleValueBuilder : Builder<HandleValueBuilder>
    {
        private ValueType _type;
        protected override HandleValueBuilder This => this;
        public HandleValueBuilder SetType(ValueType type)
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