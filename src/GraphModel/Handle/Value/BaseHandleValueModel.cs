using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value;

public class BaseHandleValueModel : BaseHandleModel, IHandleValue
{
    public override ColorHex Color { get;}
    public ValueType Type { get; }
    private BaseHandleValueModel(string label, int index, INode node, ValueType type) : base(label, index, node)
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

        public override BaseHandleModel Build()
        {
            return new BaseHandleValueModel(Label, Index, Node, _type);
        }
    }
}