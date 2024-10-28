using System;
using Godot;
using GraphModel.Values;

namespace CodingGame.Scripts.Src.Graph.View.Ui.Variable;

public partial class CreateVariableView : Godot.Node
{
    [Export] private Button _addButton;
    [Export] private LineEdit _variableNameLineEdit;
    [Export] private OptionButton _variableTypeOptionButton;

    public delegate void VariableAddedHandler(string name, ValueTypeEnum type);
    public event VariableAddedHandler OnVariableAdded;

    public override void _Ready() => _addButton.Pressed += OnAddButtonPressed;
    
    private void OnAddButtonPressed()
    {
        var typeSelected = _variableTypeOptionButton.Text;
        if (typeSelected == "") return;
        ValueTypeEnum type = Enum.Parse<ValueTypeEnum>(typeSelected);
        OnVariableAdded?.Invoke(_variableNameLineEdit.Text, type);
    }
}