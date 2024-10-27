using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingGame.Scripts.Graph.View.Edge;
using CodingGame.Scripts.Src.Graph.Controller;
using CodingGame.Scripts.Src.Graph.Controller.Handle;
using CodingGame.Scripts.Src.Util;
using GdUnit4;
using Godot;
using GraphModel.Edge;
using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value.Input;
using GraphModel.Handle.Value.Output;
using GraphModel.NewValueTypes;
using GraphModel.Node;
using GraphModel.Values;
using Moq;
using NUnit.Framework;
using static GdUnit4.Assertions;
using static NUnit.Framework.Assert;
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

    private void SimulateEdgeCreation(HandleEventBus.HandlePosition from, HandleEventBus.HandlePosition to)
    {
        _handleEventBus.InvokeOutputDragStarted(from, AutoFree(new Control()));
        _handleEventBus.InvokeOutputEnteredInput(to);
        _handleEventBus.InvokeOutputDragEnded(from);
    }

    private EdgeView GetFirstOrDefaultEdgeView() =>
        _edgeController.GetChildren().FirstOrDefault(node => node is EdgeView) as EdgeView;

    private HandleEventBus.HandlePosition CreateHandlePosition(IHandle handle) => new()
    {
        Model = handle,
        Position = AutoFree(new Control())
    };

    private HandleEventBus.HandlePosition CreateOutputFlowHandlePosition(string name, INode node) =>
        CreateHandlePosition(new OutputFlowHandle(name, node));

    private HandleEventBus.HandlePosition CreateOutputFlowHandlePosition(string name) =>
        CreateHandlePosition(new OutputFlowHandle(name, Mock.Of<INode>()));

    private HandleEventBus.HandlePosition CreateInputFlowHandlePosition(string name, INode node) =>
        CreateHandlePosition(new InputFlowHandle(name, node));

    private HandleEventBus.HandlePosition CreateInputFlowHandlePosition(string name) =>
        CreateHandlePosition(new InputFlowHandle(name, Mock.Of<INode>()));

    private HandleEventBus.HandlePosition CreateOutputValueHandlePosition(string name, ValueTypeEnum valueType,
        INode node) =>
        CreateHandlePosition(new PureOutputValueHandle(name, valueType, node));

    private HandleEventBus.HandlePosition CreateOutputValueHandlePosition(string name, ValueTypeEnum valueType) =>
        CreateHandlePosition(new PureOutputValueHandle(name, valueType, Mock.Of<INode>()));

    private HandleEventBus.HandlePosition CreateInputValueHandlePosition(string name, ValueTypeEnum valueType,
        INode node) =>
        CreateHandlePosition(new InputValueHandle(name, valueType, node));

    private HandleEventBus.HandlePosition CreateInputValueHandlePosition(string name, ValueTypeEnum valueType) =>
        CreateHandlePosition(new InputValueHandle(name, valueType, Mock.Of<INode>()));

    #endregion

    [GdUnit4.TestCase]
    public void Ready()
    {
        AssertObject(_handleEventBus).IsNotNull();
    }

    [GdUnit4.TestCase]
    public void CreateFlowEdge()
    {
        var outputHandlePosition = CreateOutputFlowHandlePosition("test");
        var inputHandlePosition = CreateInputFlowHandlePosition("test");

        // Act
        SimulateEdgeCreation(outputHandlePosition, inputHandlePosition);

        // Assert
        var edgeView = GetFirstOrDefaultEdgeView();
        That(edgeView, Is.Not.Null);
        That(edgeView.Model, Is.InstanceOf<FlowEdge>());
        That(edgeView.Model.Contains(outputHandlePosition.Model) && edgeView.Model.Contains(inputHandlePosition.Model),
            Is.True);
        edgeView.Free();
    }

    [GdUnit4.TestCase]
    public void CreateValueEdge()
    {
        // Arrange

        var outputHandlePosition = CreateOutputValueHandlePosition("test", ValueTypeEnum.String);
        var inputHandlePosition = CreateInputValueHandlePosition("test", ValueTypeEnum.String);

        // Act
        SimulateEdgeCreation(outputHandlePosition, inputHandlePosition);

        // Assert
        var edgeView = GetFirstOrDefaultEdgeView();
        That(edgeView, Is.Not.Null);
        That(edgeView.Model, Is.InstanceOf<ValueEdge>());
        That(edgeView.Model.Contains(outputHandlePosition.Model) && edgeView.Model.Contains(inputHandlePosition.Model),
            Is.True);
    }

    [GdUnit4.TestCase]
    public void ImpossibleToCreateEdgeBetweenSameNode()
    {
        // Arrange
        var node = Mock.Of<INode>();
        var outputHandlePosition = CreateOutputValueHandlePosition("test", ValueTypeEnum.String, node);
        var inputHandlePosition = CreateInputValueHandlePosition("test", ValueTypeEnum.String, node);

        // Act
        SimulateEdgeCreation(outputHandlePosition, inputHandlePosition);

        // Assert
        That(GetFirstOrDefaultEdgeView(), Is.Null);
    }

    [GdUnit4.TestCase]
    public void ImpossibleToCreateEdgeBetweenValueAndFlow()
    {
        // Arrange
        var outputHandlePosition = CreateOutputFlowHandlePosition("test");
        var inputHandlePosition = CreateInputValueHandlePosition("test", ValueTypeEnum.String);

        // Act
        SimulateEdgeCreation(outputHandlePosition, inputHandlePosition);

        // Assert
        That(GetFirstOrDefaultEdgeView(), Is.Null);
    }

    [GdUnit4.TestCase]
    public void ImpossibleToCreateEdgeBetweenDifferentValueTypeEnum()
    {
        // Arrange
        var outputHandlePosition = CreateOutputValueHandlePosition("test", ValueTypeEnum.String);
        var inputHandlePosition = CreateInputValueHandlePosition("test", ValueTypeEnum.Bool);

        // Act
        SimulateEdgeCreation(outputHandlePosition, inputHandlePosition);

        // Assert
        That(GetFirstOrDefaultEdgeView(), Is.Null);
    }

    [GdUnit4.TestCase]
    public void DeleteEveryEdgesOfHandle()
    {
        // Arrange

        var outputHandlePosition = CreateOutputValueHandlePosition("test", ValueTypeEnum.String);
        var inputHandlePosition = CreateInputValueHandlePosition("test", ValueTypeEnum.String);

        SimulateEdgeCreation(outputHandlePosition, inputHandlePosition);
        var edgeView = GetFirstOrDefaultEdgeView();
        That(edgeView, Is.Not.Null);

        // Act
        _handleEventBus.InvokeDeleteEdgeAtHandle(outputHandlePosition.Model);

        // Assert
        That(GetFirstOrDefaultEdgeView().IsQueuedForDeletion(), Is.True);
    }

    [GdUnit4.TestCase]
    public void DeleteEveryEdgeOfNode()
    {
        // Arrange
        var mockNode1 = new Mock<INode>();
        var node2 = Mock.Of<INode>();

        var outputHandlePosition1 = CreateOutputValueHandlePosition("testValue", ValueTypeEnum.String, mockNode1.Object);
        var inputHandlePosition1 = CreateInputValueHandlePosition("testValue", ValueTypeEnum.String, node2);

        var outputHandlePosition2 = CreateOutputFlowHandlePosition("testFlow", mockNode1.Object);
        var inputHandlePosition2 = CreateInputFlowHandlePosition("testFlow", node2);

        mockNode1.Setup(node => node.Inputs).Returns([outputHandlePosition1.Model, outputHandlePosition2.Model]);

        // Act
        SimulateEdgeCreation(outputHandlePosition1, inputHandlePosition1);
        SimulateEdgeCreation(outputHandlePosition2, inputHandlePosition2);
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