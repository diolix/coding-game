using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle.New;

public interface INewHandleModelDependant
{
    public INewHandle Model { set; }
}