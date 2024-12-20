using System;
using Godot;
using GraphModel.Variable;

namespace CodingGame.Scripts.Graph.View.Ui.Variable;

internal partial class VariablesContainerView : VBoxContainer
{
    [Export] private PackedScene _variableViewScene;
    [Export] private Src.Graph.View.Ui.Variable.VariableView _exampleVariableView;
    public event Action<IVariable> OnVariableRemoved;
    
    public override void _Ready()
    {
        _exampleVariableView.QueueFree();
    }
    
    public void AddVariable(IVariable variable)
    {
        var variableView = (Src.Graph.View.Ui.Variable.VariableView) _variableViewScene.Instantiate();
        variableView.SetVariableModel(variable);
        variableView.OnRemove += variableRemoved => OnVariableRemoved?.Invoke(variableRemoved);
        AddChild(variableView);
    }
}