using CodingGame.Script.Graph.Model.Handle.HandleValue;
using CodingGame.Script.Graph.Model.Node.BaseNodes;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.Handle.HandleValue;

public class HandleValueModel : HandleModel, IHandleValue
{
    public ValueType Type { get; }

    public HandleValueModel(string label, int index, INode node, ValueType type) : base(label, index, node)
    {
        Type = type;
    }

    public override ColorHex Color => Type.GetColor();

    public override bool IsCompatible(IHandle handle) =>
        handle is IHandleValue handleValue && handleValue.Type.Equals(Type);
}