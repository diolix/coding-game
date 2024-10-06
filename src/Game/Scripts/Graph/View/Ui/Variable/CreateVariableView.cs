using Godot;

namespace CodingGame.Scripts.Graph.View.Ui.Variable;

public partial class CreateVariableView : Godot.Node
{
    [Export] private Button _addButton;
    [Export] private LineEdit _variableNameLineEdit;
    [Export] private OptionButton _variableTypeOptionButton;

    public delegate void VariableAddedHandler(string name, string type);
    public event VariableAddedHandler OnVariableAdded;

    public override void _Ready()
    {
        _addButton.Pressed += OnAddButtonPressed;
    }

    private void OnAddButtonPressed()
    {
        if (_variableTypeOptionButton.Text == "") return;
        OnVariableAdded?.Invoke(_variableNameLineEdit.Text, _variableTypeOptionButton.Text);
    }
}