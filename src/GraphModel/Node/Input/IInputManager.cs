using GraphModel.Handle;

namespace GraphModel.Node.Input;

public interface IInputManager
{
    public IList<IHandle> Handles { get; }
    public bool Set(int inputIndex, object value);
    public bool SetPureNode(int inputIndex, INode value);
    public bool ResetPureNode(int inputIndex);
    public void Reset();
}