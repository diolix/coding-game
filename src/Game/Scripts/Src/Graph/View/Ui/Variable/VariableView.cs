using System;
using Godot;
using GraphModel.Variable;

namespace CodingGame.Scripts.Src.Graph.View.Ui.Variable;

public partial class VariableView : Godot.Node
{
    [Export] private Label _nameLabel;
    [Export] private Label _typeLabel;
    [Export] private Button _removeButton;
    private IVariable _variable;
    public event Action<IVariable> OnRemove;
    public void SetVariableModel(IVariable variable)
    {
        _variable = variable;
        _nameLabel.Text = variable.Name;
        _typeLabel.Text = variable.AsTypeEnum.ToString();
    }
    public override void _Ready()
    {
        _removeButton.Pressed += () =>
        {
            QueueFree();
            OnRemove?.Invoke(_variable);
        };
    }
}