using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Node;

public class BasicFlow : BaseNodeTest
{
    [Test]
    public void BasicFlowTest()
    {
        var flowInputOutput = MockNodeFactory.CreateFlowInputOutput((output, _) => output.Execute(""));
        bool mockExecuted = false;
        var mockedNode = MockNodeFactory.CreateFlowInput((_, _) => { mockExecuted = true; });

        EdgeFactory.CreateEdge(flowInputOutput, "", mockedNode, "");
        flowInputOutput.Execute();

        IsTrue(mockExecuted);
    }

    [Test]
    public void BasicPureNodeTest()
    {
        var helloWorldConstant =
            MockNodeFactory.CreatePureStringOutput((output, _) => output.CacheValue("", "Hello World"));
        var inputStringValue = string.Empty;
        var inputString = MockNodeFactory.CreateStringInput((_, input) => inputStringValue = input.GetStringValue(""));
        EdgeFactory.CreateEdge(helloWorldConstant, "", inputString, "");

        inputString.Execute();
        That(inputStringValue, Is.EqualTo("Hello World"));
    }
}