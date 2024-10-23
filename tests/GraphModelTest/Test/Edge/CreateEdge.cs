using GraphModel.Edge;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Edge;

public class CreateEdge : BaseEdgeTest
{
    [Test]
    public void ImpossibleToCreateEdgeBetweenValueAndFlow()
    {
        var boolOutput = MockNodeFactory.CreatePureBoolOutput(null);
        var flowInput = MockNodeFactory.CreateFlowInput(null);
        
        Throws<EdgeFactory.HandlesNotCompatibleException>(() => EdgeFactory.CreateEdge(boolOutput, "", flowInput, ""));
    }

    [Test]
    public void ImpossibleToCreateEdgeBetweenHandleOfSameNode()
    {
        var flowInputOutputNode = MockNodeFactory.CreateFlowInputOutput(null);
        
        Throws<EdgeFactory.HandlesNotCompatibleException>(() => EdgeFactory.CreateEdge(flowInputOutputNode, "", flowInputOutputNode, ""));
    }
}