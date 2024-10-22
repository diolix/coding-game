using CodingGame.Script.Util;
using GraphModel.Util;
using ValueType = GraphModel.ValueType;

namespace CodingGame.Script.Graph.Model.Variable;

public interface IVariable 
{
    string Name { get; }
    ValueType ValueType { get; }
    Optional<TypeWanted> SafeGetValueOfType<TypeWanted>();
    object GetValue();
    bool SafeSetValue(object value);
    void Reset();
}