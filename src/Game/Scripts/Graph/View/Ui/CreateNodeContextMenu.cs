using System;
using System.Collections.Generic;
using CodingGame.Script.Graph.Model.Variable;
using Godot;
using GraphModel.Node.BaseNodes;
using GraphModel.Node.NodeBuilder.Factories;
using GraphModel.Node.NodeBuilder.Factories.Print;

namespace CodingGame.Scripts.Graph.View.Ui;

public partial class CreateNodeContextMenu : Control
{
	[Export] private VBoxContainer _vBoxContainer;
	private VariableNodeFactory _variableNodeFactory = new();
	private PrintNodeFactory _printNodeFactory = new DevPrintNodeFactory();
	private ConstantNodeFactory _constantNodeFactory = new();
	private ControlFlowNodeFactory _controlFlowNodeFactory = new();
	public event Action<INode> OnNodeSelected;
	private readonly Dictionary<IVariable, Button[]> _getAndSetVariables = new();
	
	public override void _Ready()
	{
		AddStandardNode(_printNodeFactory.CreatePrint);
		AddStandardNode(_printNodeFactory.CreatePrintHelloWorld);
		AddStandardNode(_constantNodeFactory.CreatePureFalseContant);
		AddStandardNode(_constantNodeFactory.CreatePureTrueContant);
		AddStandardNode(_constantNodeFactory.CreatePureHelloWorldContant);
		AddStandardNode(_controlFlowNodeFactory.CreateIf);
	}

	private void AddStandardNode(Func<INode> createNodeFunc)
	{
		AddSelectableNode(createNodeFunc, new Button());
	}
	
	public void AddGetAndSetNode(IVariable variable)
	{
		var getButton = new Button();
		var setButton = new Button();
		_getAndSetVariables.Add(variable, new[] {getButton, setButton});
		AddSelectableNode(() => _variableNodeFactory.CreateGetVariable(variable), getButton);
		AddSelectableNode(() => _variableNodeFactory.CreateSetVariable(variable), setButton);
	}
	
	public void RemoveGetAndSetNode(IVariable variable)
	{
		foreach (var t in _getAndSetVariables[variable])
		{
			t.QueueFree();
		}
		_getAndSetVariables.Remove(variable);
	}
	
	private void AddSelectableNode(Func<INode> createNodeFunc, Button button)
	{
		button.Text = createNodeFunc().Name;
		button.Pressed += () =>
		{
			OnNodeSelected?.Invoke(createNodeFunc());
			Visible = false;
		};
		_vBoxContainer.AddChild(button);
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("right_click"))
		{
			GlobalPosition = GetGlobalMousePosition();
			GD.Print(GlobalPosition);
			Visible = true;
		}

		if (@event.IsActionPressed("left_click"))
		{
			Visible = false;
		}
	}
}