using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle.New;

public interface IHandleModelDependant
{
    public INewHandle Model { set; }
}