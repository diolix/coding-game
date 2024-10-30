using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;

public partial class OutputHandleView : BaseHandleView
{
    public OutputHandleView(){}
    public OutputHandleView(IHandle handleModel, ColorRect icon) : base(handleModel, icon){}
}