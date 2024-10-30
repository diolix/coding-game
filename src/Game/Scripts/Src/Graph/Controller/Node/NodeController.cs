#nullable enable
using CodingGame.Scripts.Src.Util;
using Godot;
using GraphModel.Node;
using GraphModel.Node.Factories;
using CreateNodeContextMenu = CodingGame.Scripts.Src.Graph.View.Ui.CreateNodeContextMenu;
using NodeView = CodingGame.Scripts.Src.Graph.View.Node.NodeView;

namespace CodingGame.Scripts.Src.Graph.Controller.Node;

public partial class NodeController : Godot.Node
{
    [Export] private Control _startNodePosition = null!;
    [Export] private PackedSceneWrapper _nodeViewScene = null!;
    [Export] private NodeSelectionEventBus _nodeSelectionEventBus = null!;
    [Export] private CreateNodeContextMenu _createNodeContextMenu = null!;
    [Export] private Button _startButton = null!;
    [Export] private EdgeController _edgeController = null!;
    [Export] private VariableController _variableController = null!;

    private NodeView? _selectedNode;
    
    public override void _Ready()
    {
        var start = LevelFactory.CreateStart();
        InstantiateNodeView(start, _startNodePosition.GlobalPosition);
        _startButton.Pressed += () => start.Execute();
        _createNodeContextMenu.OnNodeSelected += (node) =>
            InstantiateNodeView(node, _createNodeContextMenu.GetGlobalMousePosition());
        _nodeSelectionEventBus.OnNodeSelected += HandleNodeSelect;
    }
    
    private void InstantiateNodeView(INode baseNode, Vector2 position)
    {
        var nodeView = _nodeViewScene.Instantiate<NodeView>();
        AddChild(nodeView);
        nodeView.GlobalPosition = position;
        nodeView.BuildVisual(baseNode);
    }

    private void HandleNodeSelect(NodeView nodeView)
    {
            _selectedNode?.Deselect();
            _selectedNode = nodeView;
            nodeView.Select();
    }
    
    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("delete") && _selectedNode != null)
        {
            _edgeController.RemoveEdgesAtNode(_selectedNode.Model);
            _selectedNode?.QueueFree();
        }

        if (@event.IsActionPressed("left_click"))
        {
            _selectedNode?.Deselect();
            _selectedNode = null;
        }
    }
}