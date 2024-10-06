using Godot;
using GraphModel.Edge;

namespace CodingGame.Scripts.Graph.View.Edge;

public partial class EdgeView : Godot.Node
{
	[Export] private ControlLine _controlLine;

	private IEdge _model;
	public IEdge Model
	{
		get => _model;
		set
		{
			_model = value;
			_controlLine.DefaultColor = Color.FromHtml(_model.From.Color.ToHex());
		}
	}

	public void SetPosition(Control from, Control to)
	{
		_controlLine.Set(from, to);
	}
}