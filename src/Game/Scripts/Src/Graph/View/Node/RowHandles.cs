using Godot;
using GraphModel.Handle;
using BaseHandleView = CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew.BaseHandleView;

namespace CodingGame.Scripts.Src.Graph.View.Node;

public partial class RowHandles : Godot.Node
{
    [Export] private BaseHandleView _inputBaseHandle;
    [Export] private BaseHandleView _outputBaseHandle;
    
    public void SetUpInputHandle(IHandle model)
    {
        _inputBaseHandle.SetUp(model);
    }

    public void SetUpOutputHandle(IHandle model)
    {
        _outputBaseHandle.SetUp(model);
    }
}