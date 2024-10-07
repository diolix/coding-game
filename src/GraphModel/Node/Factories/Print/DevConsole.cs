namespace GraphModel.Node.NodeBuilder.Factories.Print;

public class DevConsole : IConsole
{
    public void WriteLine(string value)
    {
        Console.WriteLine(value);
    }

    public void Write(string value)
    {
        Console.Write(value);
    }
}