using GraphModel.Handle;

namespace CodingGame.Scripts.Graph.Controller.Handle;

public interface IHandleModelDependant
{
	public IHandle Model { set; }
}