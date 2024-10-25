#nullable enable
using System.Collections.Generic;
using System.Linq;
using CodingGame.Scripts.Graph.View.Ui.Variable;
using Godot;
using GraphModel.NewValueTypes;
using GraphModel.Variable;
using CreateNodeContextMenu = CodingGame.Scripts.Src.Graph.View.Ui.CreateNodeContextMenu;
using CreateVariableView = CodingGame.Scripts.Src.Graph.View.Ui.Variable.CreateVariableView;

namespace CodingGame.Scripts.Src.Graph.Controller;

public partial class VariableController : Node
{
    [Export] private CreateVariableView _createVariableContainer = null!;
    [Export] private VariablesContainerView _variablesContainerView = null!;
    [Export] private CreateNodeContextMenu _createNodeContextMenu = null!;
    private readonly IList<IVariable> _variableModels = new List<IVariable>();

    public override void _Ready()
    {
        _createVariableContainer.OnVariableAdded += HandleCreateVariableAdded;
        _variablesContainerView.OnVariableRemoved += HandleVariableRemoved;
    }

    private void HandleVariableRemoved(IVariable variable)
    {
        _variableModels.Remove(variable);
        _createNodeContextMenu.RemoveGetAndSetNode(variable);
    }

    private void HandleCreateVariableAdded(string name, ValueTypeEnum type)
    {
        if (name == "" || _variableModels.Any(model => model.Name == name)) return;
        var variable = VariableFactory.CreateVariable(name, type);
        _variableModels.Add(variable);
        _variablesContainerView.AddVariable(variable);
        _createNodeContextMenu.AddGetAndSetNode(variable);
    }
}