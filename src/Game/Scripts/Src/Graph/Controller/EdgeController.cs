#nullable enable
using System.Collections.Generic;
using System.Linq;
using CodingGame.Scripts.Graph.View.Edge;
using CodingGame.Scripts.Src.Util;
using Godot;
using GraphModel.Edge;
using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value.Input;
using GraphModel.Node;
using EdgeView = CodingGame.Scripts.Src.Graph.View.Edge.EdgeView;
using HandleEventBus = CodingGame.Scripts.Src.Graph.Controller.Handle.HandleEventBus;

namespace CodingGame.Scripts.Src.Graph.Controller;

public partial class EdgeController : Node
{
    [Export] private HandleEventBus HandleEventBus = null!;
    [Export] private PackedSceneWrapper ControlLineScene = null!;
    [Export] private PackedSceneWrapper EdgeScene = null!;

    private HandleEventBus.HandlePosition? _currentOutputHandlePosition;
    private HandleEventBus.HandlePosition? _currentInputHandlePosition;
    private ControlLine? _edgePreview;
    private readonly List<EdgeView> _edgeViews = new();

    public EdgeController(){}
    public EdgeController(HandleEventBus handleEventBus, PackedSceneWrapper controlLineScene, PackedSceneWrapper edgeScene)
    {
        HandleEventBus = handleEventBus;
        ControlLineScene = controlLineScene;
        EdgeScene = edgeScene;
    }
    
    public override void _Ready()
    {
        HandleEventBus.OutputDragStarted += HandleOutputDragStarted;
        HandleEventBus.OutputDragEnded += HandleOutputDragEnded;
        HandleEventBus.OutputEnteredInput += (handlePosition) => _currentInputHandlePosition = handlePosition;
        
        HandleEventBus.OutputExitedInput += (handlePosition) => _currentInputHandlePosition =
            Equals(handlePosition, _currentInputHandlePosition) ? null : _currentInputHandlePosition;
        
        HandleEventBus.DeleteEdgeAtHandle += RemoveEdgesAtHandle;
    }

    public void RemoveEdgesAtNode(INode selectedNode) =>
        selectedNode.Inputs.Concat(selectedNode.Outputs).ToList().ForEach(RemoveEdgesAtHandle);
    
    
    private void HandleOutputDragEnded(HandleEventBus.HandlePosition handlePosition)
    {
        if (_currentInputHandlePosition != null && _currentOutputHandlePosition != null &&
            _currentInputHandlePosition.Model.IsCompatible(_currentOutputHandlePosition.Model))
            TryCreateEdge(_currentOutputHandlePosition, _currentInputHandlePosition);
        _currentInputHandlePosition = null;
        _edgePreview?.QueueFree();
        _edgePreview = null;
    }

    private void HandleOutputDragStarted(HandleEventBus.HandlePosition handlePosition, Control draggable)
    {
        _currentOutputHandlePosition = handlePosition;
        _edgePreview = ControlLineScene.Instantiate<ControlLine>();
        AddChild(_edgePreview);
        _edgePreview.DefaultColor = Color.FromHtml(handlePosition.Model.Color.ToHex());
        _edgePreview.Set(handlePosition.Position, draggable);
    }

    private void TryCreateEdge(HandleEventBus.HandlePosition from, HandleEventBus.HandlePosition to)
    {
        var model = SafeCreateModelEdge(from.Model, to.Model);
        if (model is not null) CreateEdge(model, from.Position, to.Position);
    }

    private void CreateEdge(IEdge edgeModel, Control fromPosition, Control toPosition)
    {
        var edgeView = EdgeScene.Instantiate<EdgeView>();
        AddChild(edgeView);
        edgeView.Model = edgeModel;
        edgeView.SetPosition(fromPosition, toPosition);
        _edgeViews.Add(edgeView);
    }

    private IEdge? SafeCreateModelEdge(IHandle from, IHandle to)
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