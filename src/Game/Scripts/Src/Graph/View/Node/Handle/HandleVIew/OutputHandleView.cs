using CodingGame.Scripts.Src.Graph.Controller.Handle;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;

public partial class OutputHandleView : BaseHandleView
{
    [Export] private OutputDraggableController _outputDraggableController;

    public override void SetUp(IHandle model)
    {
        _outputDraggableController.Model = model;
        base.SetUp(model);
    }
}