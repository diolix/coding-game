using System;
using System.Linq;
using CodingGame.Scripts.Src.Graph.Controller;
using CodingGame.Scripts.Src.Graph.Controller.Handle;
using CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;
using CodingGame.Scripts.Src.Util;
using GdUnit4;
using Godot;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value.Input;
using GraphModel.Handle.Value.Output;
using GraphModel.Node;
using GraphModel.Values;
using Moq;
using NUnit.Framework;
using static GdUnit4.Assertions;
using static NUnit.Framework.Assert;
using ControlLine = CodingGame.Scripts.Src.Graph.View.Edge.ControlLine;
using EdgeView = CodingGame.Scripts.Src.Graph.View.Edge.EdgeView;

namespace CodingGame.Scripts.Test;

[TestSuite]
public class EdgeControllerTestSuite
{
    private static EdgeController _edgeController;
    private static HandleEventBus _handleEventBus;

    [BeforeTest]
    public void CreateEdgeControllerWithMocks()
    {
        _handleEventBus = AutoFree(new HandleEventBus());
        if (_handleEventBus == null) throw new NullReferenceException();
        var controlLineScene = new Mock<PackedSceneWrapper>();
        controlLineScene.Setup(scene => scene.Instantiate<ControlLine>()).Returns(() => AutoFree(new ControlLine()));
        var edgeScene = new Mock<PackedSceneWrapper>();
        edgeScene.Setup(scene => scene.Instantiate<EdgeView>())
            .Returns(() => AutoFree(new EdgeView(AutoFree(new ControlLine()))));

        _edgeController = AutoFree(new EdgeController(_handleEventBus, controlLineScene.Object, edgeScene.Object));
        _edgeController!._Ready();
    }
    
    #region Helper

    private void SimulateEdgeCreation(OutputHandleView from, InputHandleView to)
    {
        _handleEventBus.InvokeOutputDragStarted(from, AutoFree(new Control()));
        _handleEventBus.InvokeOutputEnteredInput(to);
        _handleEventBus.InvokeOutputDragEnded();
    }

    private EdgeView GetFirstOrDefaultEdgeView() =>
        _edgeController.GetChildren().FirstOrDefault(node => node is EdgeView) as EdgeView;

    private OutputHandleView CreateOutputFlowHandleView(string name, INode node) =>
        AutoFree(new OutputHandleView(new OutputFlowHandle(name, node), AutoFree(new ColorRect())));

    private OutputHandleView CreateOutputFlowHandleView(string name) =>
        AutoFree(new OutputHandleView(new OutputFlowHandle(name, Mock.Of<INode>()), AutoFree(new ColorRect())));

    private InputHandleView CreateInputFlowHandleView(string name, INode node) =>
        AutoFree(new InputHandleView(new InputFlowHandle(name, node), AutoFree(new ColorRect())!));

    private InputHandleView CreateInputFlowHandleView(string name) =>
        AutoFree(new InputHandleView(new InputFlowHandle(name, Mock.Of<INode>()), AutoFree(new ColorRect())!));

    private OutputHandleView CreateOutputValueHandleView(string name, ValueTypeEnum valueType,
        INode node) =>
         AutoFree(new OutputHandleView(new PureOutputValueHandle(name, valueType, node), AutoFree(new ColorRect())));

    private OutputHandleView CreateOutputValueHandleView(string name, ValueTypeEnum valueType) =>
        AutoFree(new OutputHandleView(new PureOutputValueHandle(name, valueType, Mock.Of<INode>()), AutoFree(new ColorRect())));

    private InputHandleView CreateInputValueHandleView(string name, ValueTypeEnum valueType,
        INode node) =>
        AutoFree(new InputHandleView(new InputValueHandle(name, valueType, node), AutoFree(new ColorRect())!));

    private InputHandleView CreateInputValueHandleView(string name, ValueTypeEnum valueType) =>
        AutoFree(new InputHandleView(new InputValueHandle(name, valueType, Mock.Of<INode>()), AutoFree(new ColorRect())!));
    
    #endregion

    [GdUnit4.TestCase]
    public void Ready()
    {
        AssertObject(_handleEventBus).IsNotNull();
    }

    [GdUnit4.TestCase]
    public void CreateFlowEdge()
    {
        var outputHandleView = CreateOutputFlowHandleView("test");
        var inputHandleView = CreateInputFlowHandleView("test");

        // Act
        SimulateEdgeCreation(outputHandleView, inputHandleView);

        // Assert
        var edgeView = GetFirstOrDefaultEdgeView();
        That(edgeView, Is.Not.Null);
        That(edgeView.Contains(outputHandleView.Model) && edgeView.Contains(inputHandleView.Model),
            Is.True);
        edgeView.Free();
    }

    [GdUnit4.TestCase]
    public void CreateValueEdge()
    {
        // Arrange

        var outputHandleView = CreateOutputValueHandleView("test", ValueTypeEnum.String);
        var inputHandleView = CreateInputValueHandleView("test", ValueTypeEnum.String);

        // Act
        SimulateEdgeCreation(outputHandleView, inputHandleView);

        // Assert
        var edgeView = GetFirstOrDefaultEdgeView();
        That(edgeView, Is.Not.Null);
        That(edgeView.Contains(outputHandleView.Model) && edgeView.Contains(inputHandleView.Model),
            Is.True);
    }

    [GdUnit4.TestCase]
    public void ImpossibleToCreateEdgeBetweenSameNode()
    {
        // Arrange
        var node = Mock.Of<INode>();
        var outputHandleView = CreateOutputValueHandleView("test", ValueTypeEnum.String, node);
        var inputHandleView = CreateInputValueHandleView("test", ValueTypeEnum.String, node);

        // Act
        SimulateEdgeCreation(outputHandleView, inputHandleView);

        // Assert
        That(GetFirstOrDefaultEdgeView(), Is.Null);
    }

    [GdUnit4.TestCase]
    public void ImpossibleToCreateEdgeBetweenValueAndFlow()
    {
        // Arrange
        var outputHandleView = CreateOutputFlowHandleView("test");
        var inputHandleView = CreateInputValueHandleView("test", ValueTypeEnum.String);

        // Act
        SimulateEdgeCreation(outputHandleView, inputHandleView);

        // Assert
        That(GetFirstOrDefaultEdgeView(), Is.Null);
    }

    [GdUnit4.TestCase]
    public void ImpossibleToCreateEdgeBetweenDifferentValueTypeEnum()
    {
        // Arrange
        var outputHandleView = CreateOutputValueHandleView("test", ValueTypeEnum.String);
        var inputHandleView = CreateInputValueHandleView("test", ValueTypeEnum.Bool);

        // Act
        SimulateEdgeCreation(outputHandleView, inputHandleView);

        // Assert
        That(GetFirstOrDefaultEdgeView(), Is.Null);
    }

    [GdUnit4.TestCase]
    public void DeleteEveryEdgesOfHandle()
    {
        // Arrange

        var outputHandleView = CreateOutputValueHandleView("test", ValueTypeEnum.String);
        var inputHandleView = CreateInputValueHandleView("test", ValueTypeEnum.String);

        SimulateEdgeCreation(outputHandleView, inputHandleView);
        var edgeView = GetFirstOrDefaultEdgeView();
        That(edgeView, Is.Not.Null);

        // Act
        _handleEventBus.InvokeDeleteEdgeAtHandle(outputHandleView.Model);

        // Assert
        That(GetFirstOrDefaultEdgeView().IsQueuedForDeletion(), Is.True);
    }

    [GdUnit4.TestCase]
    public void DeleteEveryEdgeOfNode()
    {
        // Arrange
        var mockNode1 = new Mock<INode>();
        var node2 = Mock.Of<INode>();

        var outputHandleView1 =
            CreateOutputValueHandleView("testValue", ValueTypeEnum.String, mockNode1.Object);
        var inputHandleView1 = CreateInputValueHandleView("testValue", ValueTypeEnum.String, node2);

        var outputHandleView2 = CreateOutputFlowHandleView("testFlow", mockNode1.Object);
        var inputHandleView2 = CreateInputFlowHandleView("testFlow", node2);

        mockNode1.Setup(node => node.Inputs).Returns([outputHandleView1.Model, outputHandleView2.Model]);

        // Act
        SimulateEdgeCreation(outputHandleView1, inputHandleView1);
        SimulateEdgeCreation(outputHandleView2, inputHandleView2);
        var nbEdge = _edgeController.GetChildren().Count(godotNode => godotNode is EdgeView);
        That(nbEdge, Is.EqualTo(2));
        _edgeController.RemoveEdgesAtNode(mockNode1.Object);
        var edgeViews = _edgeController.GetChildren().OfType<EdgeView>();

        // Assert
        var edgeViewsArray = edgeViews as EdgeView[] ?? edgeViews.ToArray();
        That(edgeViewsArray.Length, Is.EqualTo(2));
        That(edgeViewsArray.All(edgeView => edgeView.IsQueuedForDeletion()), Is.True);
    }
}