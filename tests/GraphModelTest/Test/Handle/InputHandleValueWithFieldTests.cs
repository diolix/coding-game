using GraphModel.Handle.Value.Input;
using GraphModel.Values;
using static GraphModel.Edge.EdgeFactory;
using static GraphModel.Node.Factories.ConstantFactory;
using static GraphModelTest.Mocks.MockNodeFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Handle;

public class InputHandleValueWithFieldTests
{
    [Test]
    public void ShouldTakeEdgeValueWhenHandleHasEdge()
    {
        // arrange
        string mockNodeValue = "";
        var mockNodeWithHandleField = CreateInputValueWithField(ValueTypeEnum.String,
            (_, input) => mockNodeValue = input.GetStringValue(""));
        (mockNodeWithHandleField.GetInputHandle("") as InputValueHandleWithField)?.SetValue("test");
        var helloWorldConstant = CreatePureHelloWorldConstant();
        CreateEdge(helloWorldConstant, "", mockNodeWithHandleField, "");

        // act
        mockNodeWithHandleField.Execute();

        // assert
        That(mockNodeValue, Is.EqualTo("Hello World"));
    }

    [Test]
    public void ShouldTakeFieldValueWhenHandleHasNoEdge()
    {
        // arrange
        string mockNodeValue = "";
        var mockNodeWithHandleField = CreateInputValueWithField(ValueTypeEnum.String,
            (_, input) => mockNodeValue = input.GetStringValue(""));
        (mockNodeWithHandleField.GetInputHandle("") as InputValueHandleWithField)?.SetValue("test");

        // act
        mockNodeWithHandleField.Execute();

        // assert
        That(mockNodeValue, Is.EqualTo("test"));
    }

    [Test]
    public void ShouldThrowExceptionWhenTryingToAddFieldValueWhenHandleHasEdge()
    {
        // arrange
        var mockNodeWithHandleField = CreateInputValueWithField(ValueTypeEnum.String);
        var helloWorldConstant = CreatePureHelloWorldConstant();
        CreateEdge(helloWorldConstant, "", mockNodeWithHandleField, "");

        // act & assert
        Throws<InvalidSetValueInputStringException>(() =>
            (mockNodeWithHandleField.GetInputHandle("") as InputValueHandleWithField)?.SetValue("test"));
    }
}