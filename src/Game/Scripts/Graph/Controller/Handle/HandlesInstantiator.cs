using CodingGame.Scripts.Graph.View.Node;
using Godot;
using GraphModel.Node.BaseNodes;

namespace CodingGame.Scripts.Graph.View.Controller.Handle;

public partial class HandlesInstantiator : Godot.Node
{
    [Export] private NodeView _nodeView;
    [Export] private PackedScene _rowScene;
    [Export] private RowHandles _rowExample;
    public void BuildHandles(INode node)
    {
        var inputs = node.Input.Handles;
        var outputs = node.Output.Handles;
        _rowExample.QueueFree();
        
        var nbRow = inputs.Count > outputs.Count ? inputs.Count : outputs.Count;
        for (var i = 0; i < nbRow; i++)
        {
            var instantiatedScene = _rowScene.Instantiate();
            var handleRow = (RowHandles)instantiatedScene;
            AddChild(instantiatedScene);
            
            if (i <= inputs.Count - 1) handleRow.SetUpInputHandle(inputs[i]);
            if (i <= outputs.Count - 1) handleRow.SetUpOutputHandle(outputs[i]);
        }
    }
}