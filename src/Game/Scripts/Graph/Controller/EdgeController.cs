using System.Collections.Generic;
using System.Linq;
using CodingGame.Scripts.Graph.View.Edge;
using Godot;
using GraphModel.Edge;
using GraphModel.Handle;
using GraphModel.Node;
using HandleEventBus = CodingGame.Scripts.Graph.Controller.Handle.HandleEventBus;

namespace CodingGame.Scripts.Graph.Controller;

public partial class EdgeController : Node
{
    [Export] private HandleEventBus _handleEventBus;
    [Export] private PackedScene _controlLineScene;
    [Export] private PackedScene _edgeScene;

    private HandleEventBus.HandlePosition _currentOutputHandlePosition;
    private HandleEventBus.HandlePosition _currentInputHandlePosition;
    private ControlLine _edgePreview;
    private List<EdgeView> _edgeViews = new();
    private EdgeFactory _edgeFactory = new();

    public override void _Ready()
    {
        _handleEventBus.OnOutputDragStarted += HandleOutputDragStarted;
        _handleEventBus.OnOutputDragEnded += HandleOutputDragEnded;
        _handleEventBus.OnOutputEnteredInput += HandleOutputEnteredInput;
        _handleEventBus.OnOutputExitedInput += HandleOutputExitedInput;
        _handleEventBus.OnDeleteEdgeAtHandle += HandleDeleteEdgeAtHandle;
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

    private void CreateEdge()
    {
        var instantiatedEdgeScene = _edgeScene.Instantiate();
        var model = _edgeFactory.CreateEdge(_currentOutputHandlePosition.Model, _currentInputHandlePosition.Model);
        AddChild(instantiatedEdgeScene);
        EdgeView edgeView = (EdgeView)instantiatedEdgeScene;
        edgeView.Model = model;
        edgeView.SetPosition(_currentOutputHandlePosition.Position, _currentInputHandlePosition.Position);
        _edgeViews.Add(edgeView);
    }
    
    private void HandleDeleteEdgeAtHandle(IHandle handle)
    {
        for (int i = _edgeViews.Count - 1; i >= 0; i--)
        {
            if (!_edgeViews[i].Contains(handle)) continue;
            _edgeViews[i].Remove();
            _edgeViews.RemoveAt(i);
        }
    }
    
    public void RemoveEdges(INewNode selectedNode)
    {
        selectedNode.Inputs.Concat(selectedNode.Outputs).ToList().ForEach(HandleDeleteEdgeAtHandle);
    }
}