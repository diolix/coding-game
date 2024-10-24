using System;
using System.Collections.Generic;
using CodingGame.Script.Graph.Model.Variable;
using Godot;
using GraphModel.Node;
using GraphModel.Node.Factories;
using static GraphModel.Node.Factories.ConstantFactory;
using static GraphModel.Node.Factories.ControlFlowNodeFactory;

namespace CodingGame.Scripts.Src.Graph.View.Ui;

public partial class CreateNodeContextMenu : Control
{
    [Export] private VBoxContainer _vBoxContainer;
	private readonly PrintFactory _printNodeFactory = new PrintFactory();
	public event Action<INode> OnNodeSelected;
	private readonly Dictionary<IVariable, Button[]> _getAndSetVariables = new();
	
	public override void _Ready()
	{
		AddStandardNode(_printNodeFactory.CreatePrint);
		AddStandardNode(_printNodeFactory.CreatePrintHelloWorld);
		AddStandardNode(CreateTrueConstant);
		AddStandardNode(CreateFalseConstant);
		AddStandardNode(CreatePureHelloWorldConstant);
		AddStandardNode(CreateIf);
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
		AddSelectableNode(() => VariableNodeFactory.CreateGetVariable(variable), getButton);
		AddSelectableNode(() => VariableNodeFactory.CreateSetVariable(variable), setButton);
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