using System.Collections.Generic;
using System.Linq;
using CodingGame.Scripts.Graph.Controller.Handle;
using CodingGame.Scripts.Graph.Controller.Handle.New;
using CodingGame.Scripts.Graph.View.Edge;
using Godot;
using GraphModel.NewEdge;
using GraphModel.NewHandle;
using GraphModel.Node;

namespace CodingGame.Scripts.Graph.Controller.New;

public partial class NewEdgeController : Node
{
    [Export] private NewHandleEventBus _handleEventBus;
    [Export] private PackedScene _controlLineScene;
    [Export] private PackedScene _edgeScene;

    private NewHandleEventBus.HandlePosition _currentOutputHandlePosition;
    private NewHandleEventBus.HandlePosition _currentInputHandlePosition;
    private ControlLine _edgePreview;
    private List<NewEdgeView> _edgeViews = new();
    private EdgeFactory _edgeFactory = new();

    public override void _Ready()
    {
        _handleEventBus.OnOutputDragStarted += HandleOutputDragStarted;
        _handleEventBus.OnOutputDragEnded += HandleOutputDragEnded;
        _handleEventBus.OnOutputEnteredInput += HandleOutputEnteredInput;
        _handleEventBus.OnOutputExitedInput += HandleOutputExitedInput;
        _handleEventBus.OnDeleteEdgeAtHandle += HandleDeleteEdgeAtHandle;
    }

    private void HandleOutputExitedInput(NewHandleEventBus.HandlePosition handlePosition)
    {
        if (Equals(handlePosition, _currentInputHandlePosition)) _currentInputHandlePosition = null;
    }

    private void HandleOutputEnteredInput(NewHandleEventBus.HandlePosition handlePosition)
    {
        _currentInputHandlePosition = handlePosition;
    }

    private void HandleOutputDragEnded(NewHandleEventBus.HandlePosition handlePosition)
    {
        if (_currentInputHandlePosition != null && _currentOutputHandlePosition != null &&
            _currentInputHandlePosition.Model.IsCompatible(_currentOutputHandlePosition.Model))
            CreateEdge();
        _currentInputHandlePosition = null;
        _edgePreview.QueueFree();
        _edgePreview = null;
    }

    private void HandleOutputDragStarted(NewHandleEventBus.HandlePosition handlePosition, Control draggable)
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
        NewEdgeView edgeView = (NewEdgeView)instantiatedEdgeScene;
        edgeView.Model = model;
        edgeView.SetPosition(_currentOutputHandlePosition.Position, _currentInputHandlePosition.Position);
        _edgeViews.Add(edgeView);
    }
    
    private void HandleDeleteEdgeAtHandle(INewHandle handle)
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