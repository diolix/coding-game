using System.Collections.Generic;
using System.Linq;
using CodingGame.Script.Graph.Model.Variable;
using CodingGame.Script.Util;
using CodingGame.Scripts.Graph.View.Ui;
using CodingGame.Scripts.Graph.View.Ui.Variable;
using Godot;
using GraphModel;
using GraphModel.Variable;

namespace CodingGame.Scripts.Graph.Controller;

public partial class VariableController : Node
{
    [Export] private CreateVariableView _createVariableContainer;
    [Export] private VariablesContainerView _variablesContainerView;
    [Export] private CreateNodeContextMenu _createNodeContextMenu;
    private VariableFactory _variableFactory = new();
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

    private void HandleCreateVariableAdded(string name, string type)
    {
        if (name == "" || _variableModels.Any(model => model.Name == name)) return;
        ValueType? typeEnum = Enumeration.FromDisplayName<ValueType>(type);
        if (typeEnum == null) return;
        var variable = _variableFactory.CreateVariable(name, typeEnum);
        _variableModels.Add(variable);
        _variablesContainerView.AddVariable(variable);
        _createNodeContextMenu.AddGetAndSetNode(variable);
    }

    public void Reset()
    {
        foreach (var variableModel in _variableModels)
        {
            variableModel.Reset();
        }
    }
}