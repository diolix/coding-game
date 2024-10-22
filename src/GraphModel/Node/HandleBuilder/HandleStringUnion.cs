using GraphModel.NewHandle;

namespace GraphModel.Node.HandleBuilder;

public abstract class HandleStringUnion
{
    public sealed class String : HandleStringUnion
    {
        public string Value { get; }
        public String(string value) => Value = value;
    }
    
    public sealed class Handle : HandleStringUnion
    {
        public INewHandle Value { get; }
        public Handle(INewHandle value) => Value = value;
    }
}