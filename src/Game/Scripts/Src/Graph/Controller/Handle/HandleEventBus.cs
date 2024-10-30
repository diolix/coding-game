using System;
using CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;
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

    public event Action<OutputHandleView, Control> OutputDragStarted;
    public void InvokeOutputDragStarted(OutputHandleView handleView, Control draggable) =>
        OutputDragStarted?.Invoke(handleView, draggable);
    public event Action OutputDragEnded;
    public void InvokeOutputDragEnded() => OutputDragEnded?.Invoke();
    public event Action<InputHandleView> OutputEnteredInput;
    public void InvokeOutputEnteredInput(InputHandleView handlePosition) => OutputEnteredInput?.Invoke(handlePosition);
    public event Action<InputHandleView> OutputExitedInput;
    public void InvokeOutputExitedInput(InputHandleView handlePosition) => OutputExitedInput?.Invoke(handlePosition);
    public event Action<IHandle> DeleteEdgeAtHandle;
    public void InvokeDeleteEdgeAtHandle(IHandle handlePosition) => DeleteEdgeAtHandle?.Invoke(handlePosition);
}