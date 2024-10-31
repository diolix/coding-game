using GraphModel.Node.NodeBuilder.Pure;
using GraphModel.Values;

namespace GraphModel.Node.Factories;

public static class LiteralFactory
{
    public static INode CreateBoolLiteralNode() => CreateLiteralNode(ValueTypeEnum.Bool);
    public static INode CreateStringLiteralNode() => CreateLiteralNode(ValueTypeEnum.String);
    public static INode CreateIntLiteralNode() => CreateLiteralNode(ValueTypeEnum.Int);
    private static INode CreateLiteralNode(ValueTypeEnum valueType) => new PureNodeBuildable.Builder()
        .SetName(valueType + " Literal")
        .AddInputValueWithField("", valueType)
        .AddOutputValue("", valueType)
        .SetExecution((output, input) => output.Cache("", input.GetValue("", valueType)))
        .Build();
}