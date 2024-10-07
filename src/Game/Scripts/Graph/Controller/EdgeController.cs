using System.Collections.Generic;
using CodingGame.Scripts.Graph.View.Controller.Handle;
using CodingGame.Scripts.Graph.View.Edge;
using Godot;
using GraphModel.Edge;
using GraphModel.Handle;
using GraphModel.Node;

namespace CodingGame.Scripts.Graph.View.Controller;

public partial class EdgeController : Godot.Node
{
    [Export] private HandleEventBus _handleEventBus;
    [Export] private PackedScene _controlLineScene;
    [Export] private PackedScene _edgeScene;

    private HandleEventBus.HandlePosition _currentOutputHandlePosition;
    private HandleEventBus.HandlePosition _currentInputHandlePosition;
    private ControlLine _edgePreview;
    private List<EdgeView> _edgeViews = new();

    public override void _Ready()
    {
        _handleEventBus.OnOutputDragStarted += HandleOutputDragStarted;
        _handleEventBus.OnOutputDragEnded += HandleOutputDragEnded;
        _handleEventBus.OnOutputEnteredInput += HandleOutputEnteredInput;
        _handleEventBus.OnOutputExitedInput += HandleOutputExitedInput;
        _handleEventBus.OnDeleteEdgeAtHandle += HandleDeleteEdgeAtHandle;
    }

    private void HandleDeleteEdgeAtHandle(IHandle handle)
    {
        for (int i = _edgeViews.Count - 1; i >= 0; i--)
        {
            var edgeView = _edgeViews[i];
            if (edgeView.Model.From != handle && edgeView.Model.To != handle) continue;
            _edgeViews[i].QueueFree();
            RemoveEdgeFromOutputHandle(_edgeViews[i].Model);
            _edgeViews.RemoveAt(i);
        }
    }

    private void CreateEdge()
    {
        var instantiatedEdgeScene = _edgeScene.Instantiate();
        var model = new EdgeModel(_currentOutputHandlePosition.Model,
            _currentInputHandlePosition.Model);
        _currentOutputHandlePosition.Model.Node.Output.AddEdge(model);
        
        AddChild(instantiatedEdgeScene);
        EdgeView edgeView = (EdgeView)instantiatedEdgeScene;
        edgeView.Model = model;
        edgeView.SetPosition(_currentOutputHandlePosition.Position, _currentInputHandlePosition.Position);
        _edgeViews.Add(edgeView);
    }

    private void RemoveEdgeFromOutputHandle(IEdge edge)
    {
        edge.From.Node.Output.RemoveEdge(edge);
    }

    public void RemoveEdges(INode selectedNode)
    {
        for (int i = _edgeViews.Count - 1; i >= 0; i--)
        {
            if (_edgeViews[i].Model.From.Node != selectedNode && _edgeViews[i].Model.To.Node != selectedNode) continue;
            _edgeViews[i].QueueFree();
            RemoveEdgeFromOutputHandle(_edgeViews[i].Model);
            _edgeViews.RemoveAt(i);
        }
    }

    private void HandleOutputExitedInput(HandleEventBus.HandlePosition handlePosition)
    {
        if (Equals(handlePosition, _currentInputHandlePosition)) _currentInputHandlePosition = null;
    }

    private void HandleOutputEnteredInput(HandleEventBus.HandlePosition handlePosition)
    {
        _currentInputHandlePosition = handlePosition;
    }

    private void HandleOutputDragEnded(HandleEventBus.HandlePosition handlePosition)
    {
        if (_currentInputHandlePosition != null && _currentOutputHandlePosition != null &&
            _currentInputHandlePosition.Model.IsCompatible(_currentOutputHandlePosition.Model))
        	CreateEdge();
        _currentInputHandlePosition = null;
        _edgePreview.QueueFree();
        _edgePreview = null;
    }

    private void HandleOutputDragStarted(HandleEventBus.HandlePosition handlePosition, Control draggable)
    {
        _currentOutputHandlePosition = handlePosition;
        var instantiatedControlLine = _controlLineScene.Instantiate();
        AddChild(instantiatedControlLine);
        _edgePreview = (ControlLine)instantiatedControlLine;
        _edgePreview.DefaultColor = Color.FromHtml(handlePosition.Model.Color.ToHex());
        _edgePreview.Set(handlePosition.Position, draggable);
    }
}