using System.Collections.Generic;
using CodingGame.Script.Graph.Model.Node.Nodes;
using CodingGame.Scripts.Graph.View.Node;
using CodingGame.Scripts.Graph.View.Ui;
using Godot;
using GraphModel.Node.BaseNodes;

namespace CodingGame.Scripts.Graph.View.Controller;

public partial class NodeController : Godot.Node
{
	[Export] private Control _startNodePosition;
	[Export] private PackedScene _nodeViewScene;
	[Export] private CreateNodeContextMenu _createNodeContextMenu;
	[Export] private Button _startButton;
	[Export] private EdgeController _edgeController;
	[Export] private VariableController _variableController;
	private readonly IList<INode> _nodes = new List<INode>();

	private NodeView _selectedNode;
	
	public override void _Ready()
	{
		var start = new Start();
		start.Configure();
		InstantiateNodeView(start, _startNodePosition.GlobalPosition);
		_startButton.Pressed += () => start.Execute();
		_createNodeContextMenu.OnNodeSelected += (node) =>
		{
			_nodes.Add(node);
			node.OnLastExecution += HandleLastExecution;
			InstantiateNodeView(node, _createNodeContextMenu.GetGlobalMousePosition());
		};
	}

	private void HandleLastExecution()
	{
		foreach (var node in _nodes)
		{
			node.Input.Reset();
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