namespace CodingGame.Script.Util;

public class Optional<T>
{
    public T Value { get; private set; }

    public bool HasValue() => Value != null;
    
    public Optional(T value)
    {
        Value = value;
    }
    
    public Optional() { }

    public Optional<T1> Cast<T1>()
    {
        if (Value is T1 b) return new Optional<T1>(b);
        return new Optional<T1>();
    }
}