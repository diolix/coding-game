using System;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.Controller.Handle;

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
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return HashCode.Combine(Position, Model);
        }
    }
    public HandleEventBus(){}
    public event Action<HandlePosition, Control> OutputDragStarted;
    public void InvokeOutputDragStarted(HandlePosition handlePosition, Control draggable) =>
        OutputDragStarted?.Invoke(handlePosition, draggable);
    public event Action<HandlePosition> OutputDragEnded;
    public void InvokeOutputDragEnded(HandlePosition handlePosition) => OutputDragEnded?.Invoke(handlePosition);
    public event Action<HandlePosition> OutputEnteredInput;
    public void InvokeOutputEnteredInput(HandlePosition handlePosition) => OutputEnteredInput?.Invoke(handlePosition);
    public event Action<HandlePosition> OutputExitedInput;
    public void InvokeOutputExitedInput(HandlePosition handlePosition) => OutputExitedInput?.Invoke(handlePosition);
    public event Action<IHandle> DeleteEdgeAtHandle;
    public void InvokeDeleteEdgeAtHandle(IHandle handlePosition) => DeleteEdgeAtHandle?.Invoke(handlePosition);
}