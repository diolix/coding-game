using CodingGame.Scripts.Graph.View.Node;
using CodingGame.Scripts.Util;
using Godot;
using GraphModel.Node;

namespace CodingGame.Scripts.Graph.Controller.Handle.New;

public partial class NewHandlesInstantiator : Node
{
    [Export] private NewNodeView _nodeView;
    [Export] private PackedScene _rowScene;
    [Export] private RowHandles _rowExample;

    public void BuildHandles(INewNode node)
    {
        _rowExample.QueueFree();

        foreach (var (input, output) in CollectionHelper.ZipLongest(node.Inputs, node.Outputs))
        {
            var instantiatedScene = _rowScene.Instantiate();
            var handleRow = (NewRowHandles)instantiatedScene;
            AddChild(instantiatedScene);

            if (input != null) handleRow.SetUpInputHandle(input);
            if (output != null) handleRow.SetUpOutputHandle(output);
        }
    }
}