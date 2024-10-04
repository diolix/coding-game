using CodingGame.Script.Graph.Model.Node.BaseNodes;
using CodingGame.Script.Graph.Model.Node.Nodes;
using GraphModel.Node.BaseNodes;
using GraphModel.Node.Nodes;

namespace CodingGame.Script.Graph.Model.Node.Factory;

public class PrimitiveNodeFactory
{
    public INode CreatePrintHelloWorld() => Configure(new PrintHelloWorld());
    public INode CreatePrint() => Configure(new Print());
    public INode CreateIf() => Configure(new If());
    public INode CreateStart() => Configure(new Start());
    public INode CreateTrueConstante() => Configure(new TrueConstante());
    public INode CreateFalseConstante() => Configure(new FalseConstante());
    public INode CreateHelloWorldConstante() => Configure(new HelloWorldConstante());

    private INode Configure(BaseNodes.Node node)
    {
        node.Configure();
        return node;
    }
}