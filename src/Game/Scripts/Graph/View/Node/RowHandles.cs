using Godot;
using GraphModel.Handle;
using HandleView = CodingGame.Scripts.Graph.View.Node.Handle.HandleView;

namespace CodingGame.Scripts.Graph.View.Node;

public partial class RowHandles : Godot.Node
{
    [Export] private HandleView _inputHandle;
    [Export] private HandleView _outputHandle;

    public void SetUpInputHandle(IHandle model)
    {
        _inputHandle.SetUp(model);
    }

    public void SetUpOutputHandle(IHandle model)
    {
        _outputHandle.SetUp(model);
    }
}