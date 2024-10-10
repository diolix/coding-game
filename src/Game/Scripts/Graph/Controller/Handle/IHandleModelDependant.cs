using GraphModel.Handle;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle;

public interface IHandleModelDependant
{
	public IHandle Model { set; }
}