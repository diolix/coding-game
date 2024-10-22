namespace GraphModel.Util;

public class Optional<T>
{
    public T Value { get; private set; }
    private bool _hasValue;
    public bool HasValue() => _hasValue;
    
    public Optional(T value)
    {
        Value = value;
        _hasValue = true;
    }

    public Optional()
    {
        _hasValue = false;
    }

    public Optional<T1> Cast<T1>()
    {
        if (Value is T1 b) return new Optional<T1>(b);
        return new Optional<T1>();
    }
}