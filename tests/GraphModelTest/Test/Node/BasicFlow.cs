using GraphModel.Values;
using static GraphModel.Edge.EdgeFactory;
using static GraphModelTest.Mocks.MockNodeFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Node;

public class BasicFlow
{
    [Test]
    public void BasicFlowTest()
    {
        var flowInputOutput = CreateFlowInputOutput((output, _) => output.Execute(""));
        bool mockExecuted = false;
        var mockedNode = CreateFlowInput((_, _) => { mockExecuted = true; });

        CreateEdge(flowInputOutput, "", mockedNode, "");
        flowInputOutput.Execute();

        IsTrue(mockExecuted);
    }

    [Test]
    public void BasicPureNodeTest()
    {
        var helloWorldConstant =
            CreateOutputValue(ValueTypeEnum.String, (output, _) => output.CacheString("", "Hello World"));
        var inputStringValue = string.Empty;
        var inputString = CreateInputValue(ValueTypeEnum.String, (_, input) => inputStringValue = input.GetStringValue(""));
        CreateEdge(helloWorldConstant, "", inputString, "");

        inputString.Execute();
        That(inputStringValue, Is.EqualTo("Hello World"));
    }
}