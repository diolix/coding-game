using System.Linq;
using CodingGame.Scripts.Graph.View.Edge;
using CodingGame.Scripts.Src.Graph.Controller;
using CodingGame.Scripts.Src.Graph.Controller.Handle;
using CodingGame.Scripts.Src.Util;
using GdUnit4;
using Godot;
using GraphModel;
using GraphModel.Edge;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value.Input;
using GraphModel.Handle.Value.Output;
using GraphModel.Node;
using Moq;
using NUnit.Framework;
using static GdUnit4.Assertions;
using static NUnit.Framework.Assert;
using EdgeView = CodingGame.Scripts.Src.Graph.View.Edge.EdgeView;

namespace CodingGame.Scripts.Test;

[TestSuite]
public class EdgeControllerTestSuite
{
    private record EdgeControllerWithMocks(
        EdgeController EdgeController,
        HandleEventBus HandleEventBus);

    private EdgeControllerWithMocks CreateEdgeControllerWithMocks()
    {
        var handleEventBus = new HandleEventBus();
        var controlLineScene = new Mock<PackedSceneWrapper>();
        controlLineScene.Setup(scene => scene.Instantiate<ControlLine>()).Returns(Mock.Of<ControlLine>());
        var edgeScene = new Mock<PackedSceneWrapper>();
        edgeScene.Setup(scene => scene.Instantiate<EdgeView>()).Returns(() => new EdgeView(Mock.Of<ControlLine>()));
        var edgeController = new EdgeController(handleEventBus, controlLineScene.Object, edgeScene.Object);
        return new EdgeControllerWithMocks(edgeController, handleEventBus);
    }

    private void SimulateEdgeCreation(HandleEventBus handleEventBus,
        HandleEventBus.HandlePosition from, HandleEventBus.HandlePosition to)
    {
        handleEventBus.InvokeOutputDragStarted(from, Mock.Of<Control>());
        handleEventBus.InvokeOutputEnteredInput(to);
        handleEventBus.InvokeOutputDragEnded(from);
    }

    private EdgeControllerWithMocks CreateAndInitializeEdgeController()
    {
        var res = CreateEdgeControllerWithMocks();
        res.EdgeController._Ready();
        return res;
    }

    [GdUnit4.TestCase]
    public void Ready()
    {
        var (edgeController, _) = CreateEdgeControllerWithMocks();

        AssertObject(edgeController).IsNotNull();
        edgeController._Ready();
    }

    [GdUnit4.TestCase]
    public void CreateFlowEdge()
    {
        // Arrange
        var (edgeController, handleEventBus) = CreateAndInitializeEdgeController();

        var outputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new OutputFlowHandle("test", Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        var inputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new InputFlowHandle("test", Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        // Act
        SimulateEdgeCreation(handleEventBus, outputHandlePosition, inputHandlePosition);

        // Assert
        var edgeView = edgeController.GetChildren().First(node => node is EdgeView) as EdgeView;
        That(edgeView, Is.Not.Null);
        That(edgeView.Model, Is.InstanceOf<FlowEdge>());
        That(edgeView.Model.Contains(outputHandlePosition.Model) && edgeView.Model.Contains(inputHandlePosition.Model),
            Is.True);
    }

    [GdUnit4.TestCase]
    public void CreateValueEdge()
    {
        // Arrange
        var (edgeController, handleEventBus) = CreateAndInitializeEdgeController();

        var outputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new PureOutputValueHandle("test", ValueType.String, Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        var inputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new InputValueHandle("test", ValueType.String, Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        // Act
        SimulateEdgeCreation(handleEventBus, outputHandlePosition, inputHandlePosition);

        // Assert
        var edgeView = edgeController.GetChildren().First(node => node is EdgeView) as EdgeView;
        That(edgeView, Is.Not.Null);
        That(edgeView.Model, Is.InstanceOf<ValueEdge>());
        That(edgeView.Model.Contains(outputHandlePosition.Model) && edgeView.Model.Contains(inputHandlePosition.Model),
            Is.True);
    }

    [GdUnit4.TestCase]
    public void ImpossibleToCreateEdgeBetweenSameNode()
    {
        // Arrange
        var (edgeController, handleEventBus) = CreateAndInitializeEdgeController();

        var node = Mock.Of<INode>();
        var outputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new PureOutputValueHandle("test", ValueType.String, node),
            Position = Mock.Of<Control>()
        };

        var inputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new InputValueHandle("test", ValueType.String, node),
            Position = Mock.Of<Control>()
        };

        // Act
        SimulateEdgeCreation(handleEventBus, outputHandlePosition, inputHandlePosition);

        // Assert
        var edgeView = edgeController.GetChildren().FirstOrDefault(godotNode => godotNode is EdgeView) as EdgeView;
        That(edgeView, Is.Null);
    }

    [GdUnit4.TestCase]
    public void ImpossibleToCreateEdgeBetweenValueAndFlow()
    {
        // Arrange
        var (edgeController, handleEventBus) = CreateAndInitializeEdgeController();

        var outputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new PureOutputValueHandle("test", ValueType.String, Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        var inputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new InputFlowHandle("test", Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        // Act
        SimulateEdgeCreation(handleEventBus, outputHandlePosition, inputHandlePosition);

        // Assert
        var edgeView = edgeController.GetChildren().FirstOrDefault(godotNode => godotNode is EdgeView) as EdgeView;
        That(edgeView, Is.Null);
    }

    [GdUnit4.TestCase]
    public void ImpossibleToCreateEdgeBetweenDifferentValueType()
    {
        // Arrange
        var (edgeController, handleEventBus) = CreateAndInitializeEdgeController();

        var outputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new PureOutputValueHandle("test", ValueType.String, Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        var inputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new InputValueHandle("test", ValueType.Bool, Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        // Act
        SimulateEdgeCreation(handleEventBus, outputHandlePosition, inputHandlePosition);

        // Assert
        var edgeView = edgeController.GetChildren().FirstOrDefault(godotNode => godotNode is EdgeView) as EdgeView;
        That(edgeView, Is.Null);
    }

    [GdUnit4.TestCase]
    public void DeleteEveryEdgesOfHandle()
    {
        // Arrange
        var (edgeController, handleEventBus) = CreateAndInitializeEdgeController();

        var outputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new PureOutputValueHandle("test", ValueType.String, Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        var inputHandlePosition = new HandleEventBus.HandlePosition
        {
            Model = new InputValueHandle("test", ValueType.String, Mock.Of<INode>()),
            Position = Mock.Of<Control>()
        };

        SimulateEdgeCreation(handleEventBus, outputHandlePosition, inputHandlePosition);
        var edgeView = edgeController.GetChildren().First(node => node is EdgeView) as EdgeView;
        That(edgeView, Is.Not.Null);

        // Act
        handleEventBus.InvokeDeleteEdgeAtHandle(outputHandlePosition.Model);

        // Assert
        ISceneRunner.SyncProcessFrame.OnCompleted(() =>
        {
            var deletedEdgeView = edgeController.GetChildren().FirstOrDefault(node => node is EdgeView);
            That(deletedEdgeView, Is.Null);
        });
    }

    [GdUnit4.TestCase]
    public void DeleteEveryEdgeOfNode()
    {
        // Arrange
        var (edgeController, handleEventBus) = CreateAndInitializeEdgeController();

        var mockNode1 = new Mock<INode>();
        var node2 = Mock.Of<INode>();
        var outputHandlePosition1 = new HandleEventBus.HandlePosition
        {
            Model = new PureOutputValueHandle("testValue", ValueType.String, mockNode1.Object),
            Position = Mock.Of<Control>()
        };

        var inputHandlePosition1 = new HandleEventBus.HandlePosition
        {
            Model = new InputValueHandle("testValue", ValueType.String, node2),
            Position = Mock.Of<Control>()
        };

        var outputHandlePosition2 = new HandleEventBus.HandlePosition
        {
            Model = new OutputFlowHandle("testFlow", mockNode1.Object),
            Position = Mock.Of<Control>()
        };

        var inputHandlePosition2 = new HandleEventBus.HandlePosition
        {
            Model = new InputFlowHandle("testFlow", node2),
            Position = Mock.Of<Control>()
        };
        
        mockNode1.Setup((node => node.Inputs)).Returns([outputHandlePosition1.Model, outputHandlePosition2.Model]);
        
        SimulateEdgeCreation(handleEventBus, outputHandlePosition1, inputHandlePosition1);
        SimulateEdgeCreation(handleEventBus, outputHandlePosition2, inputHandlePosition2);
        var nbEdge = edgeController.GetChildren().Count(godotNode => godotNode is EdgeView);
        That(nbEdge, Is.EqualTo(2));

        // Act
        edgeController.RemoveEdgesAtNode(mockNode1.Object);

        // Assert
        ISceneRunner.SyncProcessFrame.OnCompleted(() =>
        {
            var deletedEdgeView = edgeController.GetChildren().FirstOrDefault(node => node is EdgeView);
            That(deletedEdgeView, Is.Null);
        });
    }
}