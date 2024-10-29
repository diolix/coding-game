using GraphModel.Node.NodeBuilder.Pure;
using GraphModel.Values;

namespace GraphModel.Node.Factories;

public static class Literal
{
    public static INode CreateBoolLiteralNode() => CreateLiteralNode(ValueTypeEnum.Bool);
    public static INode CreateStringLiteralNode() => CreateLiteralNode(ValueTypeEnum.String);
    private static INode CreateLiteralNode(ValueTypeEnum valueType) => new PureNodeBuildable.Builder()
        .SetName(valueType + " Literal")
        .AddInputValueWithField("", valueType)
        .AddOutputValue("", valueType)
        .Build();
}