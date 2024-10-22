using CodingGame.Scripts.Graph.View.Node;
using CodingGame.Scripts.Util;
using Godot;
using GraphModel.Node;

namespace CodingGame.Scripts.Graph.Controller.Handle.New;

public partial class NewHandlesInstantiator : Node
{
    [Export] private NodeView _nodeView;
    [Export] private PackedScene _handlesRowScene;
    [Export] private RowHandles _hanldesRowExample;

    public void BuildHandles(INewNode node)
    {
        _hanldesRowExample.QueueFree();

        foreach (var (input, output) in CollectionHelper.ZipLongest(node.Inputs, node.Outputs))
        {
            var instantiatedScene = _handlesRowScene.Instantiate();
            var handleRow = (RowHandles)instantiatedScene;
            AddChild(instantiatedScene);

            if (input != null) handleRow.SetUpInputHandle(input);
            if (output != null) handleRow.SetUpOutputHandle(output);
        }
    }
}