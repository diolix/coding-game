using GraphModel.Node;
using GraphModel.Node.NodeBuilder.Pure;
using GraphModel.Values;
using ImpureNodeBuildable = GraphModel.Node.NodeBuilder.Impure.ImpureNodeBuildable;

namespace GraphModelTest.Mocks;

public static class MockNodeFactory
{
    public static INode CreateFlowInput(ImpureNodeBuildable.Execution? callback = null)
        => new ImpureNodeBuildable.Builder()
            .SetName("MockFlowInput")
            .AddInputFlow("")
            .SetExecution(callback ?? ((_, _) => { }))
            .Build();


    public static INode CreateFlowOutput(ImpureNodeBuildable.Execution? callback = null)
        => new ImpureNodeBuildable.Builder()
            .SetName("MockFlowInput")
            .AddOutputFlow("")
            .SetExecution(callback ?? ((_, _) => { }))
            .Build();


    public static INode CreateFlowInputOutput(ImpureNodeBuildable.Execution? callback = null)
        => new ImpureNodeBuildable.Builder()
            .SetName("MockFlowInputOutput")
            .AddInputFlow("")
            .AddOutputFlow("")
            .SetExecution(callback ?? ((_, _) => { }))
            .Build();

    public static INode CreateOutputValue(ValueTypeEnum fieldType, PureNodeBuildable.Execution? callback = null)
        => new PureNodeBuildable.Builder()
            .SetName("MockOutputValue")
            .AddOutputValue("", fieldType)
            .SetExecution(callback ?? ((_, _) => { }))
            .Build();

    public static INode CreateInputValue(ValueTypeEnum fieldType, PureNodeBuildable.Execution? callback = null)
        => new PureNodeBuildable.Builder()
            .SetName("MockInputValue")
            .AddInputValue("", fieldType)
            .SetExecution(callback ?? ((_, _) => { }))
            .Build();

    public static INode CreateInputValueWithField(ValueTypeEnum fieldType, PureNodeBuildable.Execution? callback = null)
        => new PureNodeBuildable.Builder()
            .SetName("MockInputValueWithField")
            .AddInputValueWithField("", fieldType)
            .SetExecution(callback ?? ((_, _) => { }))
            .Build();
}