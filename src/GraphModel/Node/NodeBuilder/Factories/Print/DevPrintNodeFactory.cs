namespace GraphModel.Node.NodeBuilder.Factories.Print;

public class DevPrintNodeFactory : PrintNodeFactory
{
    public DevPrintNodeFactory() : base(new DevConsole()) { }
}