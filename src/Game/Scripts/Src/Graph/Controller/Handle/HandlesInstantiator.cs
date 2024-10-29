using CodingGame.Scripts.Src.Util;
using Godot;
using GraphModel.Node;
using NodeView = CodingGame.Scripts.Src.Graph.View.Node.NodeView;
using RowHandles = CodingGame.Scripts.Src.Graph.View.Node.RowHandles;

namespace CodingGame.Scripts.Src.Graph.Controller.Handle;

public partial class HandlesInstantiator : Godot.Node
{
    [Export] private NodeView _nodeView;
    [Export] private PackedScene _handlesRowScene;
    [Export] private RowHandles _hanldesRowExample;

    public void BuildHandles(INode node)
    {
        _hanldesRowExample.Free();

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