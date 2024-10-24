using CodingGame.Scripts.Src.Util;
using Godot;
using GraphModel.Node;
using GraphModel.Node.Factories;
using CreateNodeContextMenu = CodingGame.Scripts.Src.Graph.View.Ui.CreateNodeContextMenu;
using NodeView = CodingGame.Scripts.Src.Graph.View.Node.NodeView;

namespace CodingGame.Scripts.Src.Graph.Controller;

public partial class NodeController : Node
{
    [Export] private Control _startNodePosition;
    [Export] private PackedSceneWrapper _nodeViewScene;
    [Export] private CreateNodeContextMenu _createNodeContextMenu;
    [Export] private Button _startButton;
    [Export] private EdgeController _edgeController;
    [Export] private VariableController _variableController;

    private NodeView _selectedNode;
    
    public override void _Ready()
    {
        var start = LevelFactory.CreateStart();
        InstantiateNodeView(start, _startNodePosition.GlobalPosition);
        _startButton.Pressed += () => start.Execute();
        _createNodeContextMenu.OnNodeSelected += (node) =>
            InstantiateNodeView(node, _createNodeContextMenu.GetGlobalMousePosition());
    }
    
    private void InstantiateNodeView(INode baseNode, Vector2 position)
    {
        var nodeView = _nodeViewScene.Instantiate<NodeView>();
        AddChild(nodeView);
        nodeView.GlobalPosition = position;
        nodeView.BuildVisual(baseNode);
        nodeView.OnSelectChanged += selected => HandleNodeSelectedChanged(nodeView, selected);
    }
    
    private void HandleNodeSelectedChanged(NodeView nodeView, bool selected)
    {
        _selectedNode = selected ? nodeView : null;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (!@event.IsActionPressed("delete")) return;
        _edgeController.RemoveEdgesAtNode(_selectedNode.Model);
        _selectedNode?.QueueFree();
    }
}