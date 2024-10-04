using CodingGame.Script.Graph.Model.Variable;

namespace CodingGame.Script.Graph.Model.Node.Nodes.VariableNodes;

public class SetVariable : VariableNode
{
    public override string Name => $"Set {Variable.Name}";
    
    protected override void ConfigureHandle()
    {
        InputsConstructor.AddFlow("in flow");
        InputsConstructor.AddValue("value", Variable.ValueType);
        OutputsConstructor.AddFlow("out flow");
    }
    
    public override void Execute()
    {
        Variable.SafeSetValue(GetInputValue(1, Variable.ValueType).Value);
        SafeExecute(0);
    }
    
    public SetVariable(IVariable variable) : base(variable) { }
}