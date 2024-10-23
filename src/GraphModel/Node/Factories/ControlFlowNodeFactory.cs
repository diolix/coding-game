using GraphModel.Node.NodeBuilder.NewNode.Impure;

namespace GraphModel.Node.Factories;

public class ControlFlowNodeFactory
{
    public INode CreateIf() => new ImpureNodeBuildable.Builder()
        .SetName("if")
        .AddInputFlow("")
        .AddInputValue("condition", ValueType.Bool)
        .AddOutputFlow("true")
        .AddOutputFlow("false")
        .SetExecution((outputManager, inputManager) =>
        {
            if(inputManager.GetBoolValue("condition"))
                outputManager.Execute("true");
            else outputManager.Execute("false");
        }).Build();
    
    public INode CreateWhile() => new ImpureNodeBuildable.Builder()
        .SetName("while")
        .AddInputFlow("")
        .AddInputValue("condition", ValueType.Bool)
        .AddOutputFlow("exit")
        .AddOutputFlow("body")
        .SetExecution((outputManager, inputManager) =>
        {
            while(inputManager.GetBoolValue("condition"))
                outputManager.Execute("body");
            outputManager.Execute("exit");
        }).Build();
}