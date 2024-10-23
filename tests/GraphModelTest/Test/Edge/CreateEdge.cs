using GraphModel.Edge;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Edge;

public class CreateEdge : BaseEdgeTest
{
    [Test]
    public void ImpossibleToCreateEdgeBetweenValueAndFlow()
    {
        var boolOutput = MockNodeFactory.CreatePureBoolOutput();
        var flowInput = MockNodeFactory.CreateFlowInput();

        Throws<HandlesNotCompatibleException>(() => EdgeFactory.CreateEdge(boolOutput, "", flowInput, ""));
    }

    [Test]
    public void ImpossibleToCreateEdgeBetweenHandleOfSameNode()
    {
        var flowInputOutputNode = MockNodeFactory.CreateFlowInputOutput();

        Throws<HandlesNotCompatibleException>(() =>
            EdgeFactory.CreateEdge(flowInputOutputNode, "", flowInputOutputNode, ""));
    }

    [Test]
    public void ImpossibleToCreateEdgeBetweenValueWithDifferentType()
    {
        var stringInput = MockNodeFactory.CreateStringInput();
        var boolOutput = MockNodeFactory.CreatePureBoolOutput();

        Throws<HandlesNotCompatibleException>(() =>
            EdgeFactory.CreateEdge(boolOutput, "", stringInput, ""));
    }

    [Test]
    public void ImpossibleToCreateMultipleEdgesToInputHandleValue()
    {
        var stringOutput = MockNodeFactory.CreatePureStringOutput();
        var stringInput = MockNodeFactory.CreateStringInput();
        
        EdgeFactory.CreateEdge(stringOutput, "", stringInput, "");
        Throws<MultipleValueEdgesToSameInputException>(() => EdgeFactory.CreateEdge(stringOutput, "", stringInput, ""));
    }

    [Test]
    public void ImpossibleToCreateMultipleEdgesFromOutputHandleFlow()
    {
        var flowOutput = MockNodeFactory.CreateFlowOutput();
        var flowInput = MockNodeFactory.CreateFlowInput();
        
        EdgeFactory.CreateEdge(flowOutput, "", flowInput, "");
        Throws<MultipleFlowEdgesFromSameOutputException>(() => EdgeFactory.CreateEdge(flowOutput, "", flowInput, ""));
    }
}