using System;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Graph.View.Controller.Handle;

[GlobalClass]
public partial class HandleEventBus : Resource
{
	public class HandlePosition
	{
		public Control Position;
		public IHandle Model;

		public override bool Equals(object obj)
		{
			if (obj is not HandlePosition handleObj) return false;
			return handleObj.Model == Model && handleObj.Position == Position;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Position, Model);
		}
	}
	
	public Action<HandlePosition, Control> OnOutputDragStarted;
	public Action<HandlePosition> OnOutputDragEnded;
	public Action<HandlePosition> OnOutputEnteredInput;
	public Action<HandlePosition> OnOutputExitedInput;
	public Action<IHandle> OnDeleteEdgeAtHandle;
}