using System.Collections.Generic;
using CodingGame.Scripts.Graph.View.Node;
using CodingGame.Scripts.Graph.View.Ui;
using Godot;
using GraphModel.Node;
using GraphModel.Node.NodeBuilder.Factories;

namespace CodingGame.Scripts.Graph.Controller;

public partial class NodeController : Node
{
	[Export] private Control _startNodePosition;
	[Export] private PackedScene _nodeViewScene;
	[Export] private CreateNodeContextMenu _createNodeContextMenu;
	[Export] private Button _startButton;
	[Export] private EdgeController _edgeController;
	[Export] private VariableController _variableController;
	private readonly IList<INode> _nodes = new List<INode>();

	private NodeView _selectedNode;
	private LevelNodeFactory _levelNodeFactory = new();
	
	public override void _Ready()
	{
		var start = _levelNodeFactory.CreateStart();
		InstantiateNodeView(start, _startNodePosition.GlobalPosition);
		_startButton.Pressed += () => start.Execute();
		start.OnFinishedExecution += HandleLastExecution;
		_createNodeContextMenu.OnNodeSelected += (node) =>
		{
			_nodes.Add(node);
			InstantiateNodeView(node, _createNodeContextMenu.GetGlobalMousePosition());
		};
	}

	private void HandleLastExecution()
	{
		foreach (var node in _nodes)
		{
			node.Input.ResetValues();
		}
		_variableController.Reset();
	}
	
	private void InstantiateNodeView(INode baseNode, Vector2 position)
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
		_nodes.Remove(_selectedNode.Model);
		_edgeController.RemoveEdges(_selectedNode.Model);
		_selectedNode?.QueueFree();
	}
}