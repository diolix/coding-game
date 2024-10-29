using System;
using CodingGame.Scripts.Src.Graph.View.Node;
using Godot;

namespace CodingGame.Scripts.Src.Graph.Controller.Node;

[GlobalClass]
public partial class NodeSelectionEventBus : Resource
{
    public event Action<NodeView> OnNodeSelected; 
    public void InvokeSelectNode(NodeView nodeView) => OnNodeSelected?.Invoke(nodeView);
}