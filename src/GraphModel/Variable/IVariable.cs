namespace GraphModel.Variable;

public interface IVariable 
{
    string Name { get; }
    ValueType ValueType { get; }
    TypeWanted? SafeGetValueOfType<TypeWanted>();
    object GetValue();
    bool SafeSetValue(object value);
    void Reset();
}