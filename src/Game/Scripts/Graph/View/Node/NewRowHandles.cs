using CodingGame.Scripts.Graph.View.Node.Handle;
using Godot;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.View.Node;

public partial class NewRowHandles : Godot.Node
{
    [Export] private NewHandleView _inputHandle;
    [Export] private NewHandleView _outputHandle;
    
    public void SetUpInputHandle(INewHandle model)
    {
        _inputHandle.SetUp(model);
    }

    public void SetUpOutputHandle(INewHandle model)
    {
        _outputHandle.SetUp(model);
    }
}