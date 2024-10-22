using CodingGame.Scripts.Graph.View.Node;
using CodingGame.Scripts.Graph.View.Ui;
using Godot;
using GraphModel.Node;
using GraphModel.Node.Factories;

namespace CodingGame.Scripts.Graph.Controller;

public partial class NodeController : Node
{
    [Export] private Control _startNodePosition;
    [Export] private PackedScene _nodeViewScene;
    [Export] private CreateNodeContextMenu _createNodeContextMenu;
    [Export] private Button _startButton;
    [Export] private Controller.EdgeController _edgeController;
    [Export] private VariableController _variableController;

    private NodeView _selectedNode;
    private LevelNodeFactory _levelNodeFactory = new();
    
    public override void _Ready()
    {
        var start = _levelNodeFactory.CreateStart();
        InstantiateNodeView(start, _startNodePosition.GlobalPosition);
        _startButton.Pressed += () => start.Execute();
        _createNodeContextMenu.OnNodeSelected += (node) =>
            InstantiateNodeView(node, _createNodeContextMenu.GetGlobalMousePosition());
    }
    
    private void InstantiateNodeView(INewNode baseNode, Vector2 position)
    {
        var instantiatedNodeView = _nodeViewScene.Instantiate();
        AddChild(instantiatedNodeView);
        NodeView nodeView = (NodeView)instantiatedNodeView;
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
        GD.Print("delete");
        _edgeController.RemoveEdges(_selectedNode.Model);
        _selectedNode?.QueueFree();
    }
}