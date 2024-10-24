using Godot;

namespace CodingGame.Scripts.Src.Util;

[GlobalClass]

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class PackedSceneWrapper : Resource
{
    [Export] private PackedScene Scene = null!;
    
    public virtual T Instantiate<T>() where T : Node
    {
        return Scene.Instantiate<T>();
    }
}