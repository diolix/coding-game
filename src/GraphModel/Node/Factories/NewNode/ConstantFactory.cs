using GraphModel.Node.NodeBuilder.NewNode.Pure;

namespace GraphModel.Node.Factories.NewNode;

public class ConstantFactory
{
    public INewNode CreateHelloWorldConstant() => new PureNodeBuildable.PureNodeBuilder()
        .SetName("HelloWorldConstant")
        .AddOutputValue("Value", ValueType.String)
        .SetExecution((_, outputManager) =>
        {
            outputManager.CacheValue("Value", "Hello World");
        })
        .Build();
}