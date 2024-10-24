using System;
using System.Linq;
using CodingGame.Scripts.Graph.View.Edge;
using CodingGame.Scripts.Src.Graph.Controller;
using CodingGame.Scripts.Src.Graph.Controller.Handle;
using CodingGame.Scripts.Src.Util;
using GdUnit4;
using Godot;
using GraphModel.Handle.Flow;
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
        HandleEventBus HandleEventBus,
        Mock<PackedSceneWrapper> ControlLineScene,
        Mock<PackedSceneWrapper> EdgeScene);

    private EdgeControllerWithMocks CreateEdgeControllerWithMocks()
    {
        var handleEventBus = new HandleEventBus();
        var controlLineScene = new Mock<PackedSceneWrapper>();
        controlLineScene.Setup(scene => scene.Instantiate<ControlLine>()).Returns(Mock.Of<ControlLine>());
        var edgeScene = new Mock<PackedSceneWrapper>();
        edgeScene.Setup(scene => scene.Instantiate<EdgeView>()).Returns(new EdgeView(Mock.Of<ControlLine>()));
        var edgeController = new EdgeController(handleEventBus, controlLineScene.Object, edgeScene.Object);
        return new EdgeControllerWithMocks(edgeController, handleEventBus, controlLineScene, edgeScene);
    }
        
    
    [GdUnit4.TestCase]
    public void Ready()
    {
        var (edgeController,
            _, 
            _, 
            _) = CreateEdgeControllerWithMocks();

        AssertObject(edgeController).IsNotNull();
        edgeController._Ready();
    }

    [GdUnit4.TestCase]
    public void CreateEdge()
    {
        // Arrange
        var (edgeController,
            handleEventBus, 
            _, 
            _) = CreateEdgeControllerWithMocks();
        
        edgeController._Ready();
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
        handleEventBus.InvokeOutputDragStarted(outputHandlePosition, Mock.Of<Control>());
        handleEventBus.InvokeOutputEnteredInput(inputHandlePosition);
        handleEventBus.InvokeOutputDragEnded(outputHandlePosition);
        
        // Assert
        var edgeView = edgeController.GetChildren().First((node => node is EdgeView)) as EdgeView;
        That(edgeView, Is.Not.Null);
        That(edgeView.Model.Contains(outputHandlePosition.Model) && edgeView.Model.Contains(inputHandlePosition.Model), Is.True);
    }
}