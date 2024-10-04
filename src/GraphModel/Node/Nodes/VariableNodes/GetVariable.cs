using CodingGame.Script.Graph.Model.Variable;

namespace CodingGame.Script.Graph.Model.Node.Nodes.VariableNodes;

public class GetVariable : VariableNode
{
    public override string Name => $"Get {Variable.Name}";
    
    public GetVariable(IVariable variable) : base(variable) { }
    
    protected override void ConfigureHandle()
    {
        InputsConstructor.AddFlow("in flow");
        OutputsConstructor.AddFlow("out flow");
        OutputsConstructor.AddValue("out value", Variable.ValueType);
    }
    
    public override void Execute()
    {
        SetOutputValue(1, Variable.GetValue());
        SafeExecute(0);
    }
}