using GraphModel.Edge;
using GraphModel.Values;
using static GraphModel.Edge.EdgeFactory;
using static GraphModelTest.Mocks.MockNodeFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Edge;

public class CreateEdge
{
    [Test]
    public void ImpossibleToCreateEdgeBetweenValueAndFlow()
    {
        var boolOutput = CreateOutputValue(ValueTypeEnum.Bool);
        var flowInput = CreateFlowInput();

        Throws<HandlesNotCompatibleException>(() => CreateEdge(boolOutput, "", flowInput, ""));
    }

    [Test]
    public void ImpossibleToCreateEdgeBetweenHandleOfSameNode()
    {
        var flowInputOutputNode = CreateFlowInputOutput();

        Throws<HandlesNotCompatibleException>(() =>
            CreateEdge(flowInputOutputNode, "", flowInputOutputNode, ""));
    }

    [Test]
    public void ImpossibleToCreateEdgeBetweenValueWithDifferentType()
    {
        var stringInput = CreateInputValue(ValueTypeEnum.String);
        var boolOutput = CreateOutputValue(ValueTypeEnum.Bool);

        Throws<HandlesNotCompatibleException>(() =>
            CreateEdge(boolOutput, "", stringInput, ""));
    }

    [Test]
    public void ImpossibleToCreateMultipleEdgesToInputHandleValue()
    {
        var stringOutput = CreateOutputValue(ValueTypeEnum.String);
        var stringInput = CreateInputValue(ValueTypeEnum.String);
        
        CreateEdge(stringOutput, "", stringInput, "");
        Throws<MultipleValueEdgesToSameInputException>(() => CreateEdge(stringOutput, "", stringInput, ""));
    }

    [Test]
    public void ImpossibleToCreateMultipleEdgesFromOutputHandleFlow()
    {
        var flowOutput = CreateFlowOutput();
        var flowInput = CreateFlowInput();
        
        CreateEdge(flowOutput, "", flowInput, "");
        Throws<MultipleFlowEdgesFromSameOutputException>(() => CreateEdge(flowOutput, "", flowInput, ""));
    }
}