using System;
using System.Collections.Generic;
using Godot;
using GraphModel.Node;
using GraphModel.Node.Factories;
using GraphModel.Variable;
using static GraphModel.Node.Factories.ControlFlowFactory;
using static GraphModel.Node.Factories.LiteralFactory;
using static GraphModel.Node.Factories.PrintFactory;
using static GraphModel.Node.Factories.VariableNodeFactory;

namespace CodingGame.Scripts.Src.Graph.View.Ui;

public partial class CreateNodeContextMenu : Control
{
    [Export] private VBoxContainer _vBoxContainer;
	public event Action<INode> OnNodeSelected;
	private readonly Dictionary<IVariable, Button[]> _getAndSetVariables = new();
	
	public override void _Ready()
	{
		AddStandardNode(CreatePrintObj);
		AddStandardNode(CreatePrintString);
		AddStandardNode(CreateBoolLiteralNode);
		AddStandardNode(CreateStringLiteralNode);
		AddStandardNode(CreateIntLiteralNode);
		AddStandardNode(CreateIf);
		AddStandardNode(CreateWhile);
		AddStandardNode(MathIntegerFactory.CreateAddNode);
		AddStandardNode(MathIntegerFactory.CreateSubtractNode);
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
		AddSelectableNode(() => CreateGetVariable(variable), getButton);
		AddSelectableNode(() => CreateSetVariable(variable), setButton);
	}
	
	public void RemoveGetAndSetNode(IVariable variable)
	{
		foreach (var button in _getAndSetVariables[variable])
		{
			button.QueueFree();
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
			Visible = true;
		}

		if (@event.IsActionPressed("left_click"))
		{
			Visible = false;
		}
	}
}