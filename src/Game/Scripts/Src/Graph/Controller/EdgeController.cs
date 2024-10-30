#nullable enable
using System.Collections.Generic;
using System.Linq;
using CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;
using CodingGame.Scripts.Src.Util;
using Godot;
using GraphModel.Edge;
using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value.Input;
using GraphModel.Node;
using ControlLine = CodingGame.Scripts.Src.Graph.View.Edge.ControlLine;
using EdgeView = CodingGame.Scripts.Src.Graph.View.Edge.EdgeView;
using HandleEventBus = CodingGame.Scripts.Src.Graph.Controller.Handle.HandleEventBus;

namespace CodingGame.Scripts.Src.Graph.Controller;

public partial class EdgeController : Godot.Node
{
    [Export] private HandleEventBus _handleEventBus = null!;
    [Export] private PackedSceneWrapper _controlLineScene = null!;
    [Export] private PackedSceneWrapper _edgeScene = null!;

    private OutputHandleView? _currentOutputHandleView;
    private InputHandleView? _currentInputHandleView;
    private ControlLine? _edgePreview;
    private readonly List<EdgeView> _edgeViews = new();

    public EdgeController(){}
    public EdgeController(HandleEventBus handleEventBus, PackedSceneWrapper controlLineScene, PackedSceneWrapper edgeScene)
    {
        _handleEventBus = handleEventBus;
        _controlLineScene = controlLineScene;
        _edgeScene = edgeScene;
    }
    
    public override void _Ready()
    {
        _handleEventBus.OutputDragStarted += HandleOutputDragStarted;
        _handleEventBus.OutputDragEnded += HandleOutputDragEnded;
        _handleEventBus.OutputEnteredInput += handlePosition => _currentInputHandleView = handlePosition;
        
        _handleEventBus.OutputExitedInput += handlePosition => _currentInputHandleView =
            Equals(handlePosition, _currentInputHandleView) ? null : _currentInputHandleView;
        
        _handleEventBus.DeleteEdgeAtHandle += RemoveEdgesAtHandle;
    }

    public void RemoveEdgesAtNode(INode selectedNode) =>
        selectedNode.Inputs.Concat(selectedNode.Outputs).ToList().ForEach(RemoveEdgesAtHandle);
    
    
    private void HandleOutputDragEnded()
    {
        if (_currentInputHandleView != null && _currentOutputHandleView != null)
        {
            var model = SafeCreateEdgeModel(_currentOutputHandleView.Model, _currentInputHandleView.Model);
            if (model is not null) CreateEdgeView(model, _currentOutputHandleView, _currentInputHandleView);
        }
        _currentInputHandleView = null;
        _currentOutputHandleView = null;
        _edgePreview?.QueueFree();
        _edgePreview = null;
    }

    private void HandleOutputDragStarted(OutputHandleView handleView, Control draggable)
    {
        _currentOutputHandleView = handleView;
        _edgePreview = _controlLineScene.Instantiate<ControlLine>();
        AddChild(_edgePreview);
        _edgePreview.DefaultColor = handleView.Color;
        _edgePreview.Set(handleView.Icon, draggable);
    }

    private void CreateEdgeView(IEdge edgeModel, OutputHandleView fromHandle, InputHandleView toPosition)
    {
        var edgeView = _edgeScene.Instantiate<EdgeView>();
        AddChild(edgeView);
        edgeView.Model = edgeModel;
        edgeView.SetPosition(fromHandle.Icon, toPosition.Icon);
        _edgeViews.Add(edgeView);
    }

    private IEdge? SafeCreateEdgeModel(IHandle from, IHandle to)
    {
        if (from is OutputFlowHandle { HasEdge: true })
        {
            RemoveEdgesAtHandle(from);
            return EdgeFactory.CreateEdge(from, to);
        }

        if (to is InputValueHandle { HasEdge: true })
        {
            RemoveEdgesAtHandle(to);
            return EdgeFactory.CreateEdge(from, to);
        }

        return EdgeFactory.SafeCreateEdge(from, to);
    }

    private void RemoveEdgesAtHandle(IHandle handle)
    {
        for (int i = _edgeViews.Count - 1; i >= 0; i--)
        {
            if (!_edgeViews[i].Contains(handle)) continue;
            _edgeViews[i].Remove();
            _edgeViews.RemoveAt(i);
        }
    }
}