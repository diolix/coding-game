using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value;

namespace GraphModel.Node.HandleBuilder;

public class InputHandlesBuilder
{
    private readonly IList<HandleStringUnion> _inputHandles;
    
    public InputHandlesBuilder()
    {
        _inputHandles = new List<HandleStringUnion>();
    }

    public void AddInputFlowHandle(string label)
    {
        _inputHandles.Add(new HandleStringUnion.String(label));
    }
    
    public void AddInputValueHandle(string label, ValueType type)
    {
        var handle = new InputValueHandle(label, type);
        _inputHandles.Add(new HandleStringUnion.Handle(handle));
    }
    
    public IEnumerable<IHandle> Build(INewNode node) => _inputHandles.Select(handleStringUnion => handleStringUnion switch
    {
        HandleStringUnion.String stringHandle => new InputFlowHandle(stringHandle.Value, node),
        HandleStringUnion.Handle handle => handle.Value,
        _ => throw new ArgumentOutOfRangeException()
    }).ToArray();
    
    private abstract class HandleStringUnion
    {
        internal sealed class String : HandleStringUnion
        {
            public string Value { get; }
            public String(string value) => Value = value;
        }
    
        internal sealed class Handle : HandleStringUnion
        {
            public IHandle Value { get; }
            public Handle(IHandle value) => Value = value;
        }
    }
}