using System.Collections.Generic;
using CodingGame.Scripts.Graph.Controller.Handle;
using CodingGame.Scripts.Graph.View.Edge;
using Godot;

namespace CodingGame.Scripts.Graph.Controller.New;

public partial class NewEdgeController : Node
{
    [Export] private HandleEventBus _handleEventBus;
    [Export] private PackedScene _controlLineScene;
    [Export] private PackedScene _edgeScene;

    private HandleEventBus.HandlePosition _currentOutputHandlePosition;
    private HandleEventBus.HandlePosition _currentInputHandlePosition;
    private ControlLine _edgePreview;
    private List<EdgeView> _edgeViews = new();
}