using CodingGame.Script.Graph.Model.Handle.HandleValue;
using GraphModel.Edge;
using GraphModel.Handle;

namespace GraphModel.Node.Output;

public class OutputManager : IOutputManager
{
    private IList<IEdge?> EdgesFlow;
    private Dictionary<int, IList<IEdge>> _edgesValuePerHandle = null!;
    private readonly IList<IHandle> _handles;
    public IList<IHandle> Handles => _handles;

    public OutputManager(IList<IHandle> handles)
    {
        _handles = handles;
        EdgesFlow = new IEdge[_handles.Count];
        InitializeEdgesValuePerHandle(handles);
    }

    private void InitializeEdgesValuePerHandle(IList<IHandle> handles)
    {
        _edgesValuePerHandle = new Dictionary<int, IList<IEdge>>();
        for (int i = 0; i < handles.Count; i++)
        {
            if (handles[i] is IHandleValue)
                _edgesValuePerHandle.Add(i, new List<IEdge>());
        }
    }
    
    public void AddEdge(IEdge edge)
    {
        if (!_handles.Contains(edge.From))
            throw new Exception("From handle not in HandleOutputs of " + this + " , edge " + edge);
        
        if (edge.From is IHandleValue handleValue)
            AddValueOutputEdge(_handles.IndexOf(handleValue), edge);
        else AddFlowOutputEdge(edge);
    }

    public void RemoveEdge(IEdge edge)
    {
        if (edge.From is IHandleValue handleValue)
            RemoveValueOutputEdge(_handles.IndexOf(handleValue), edge);
        else RemoveFlowOutputEdge(edge);
    }
    
    public bool SafeExecuteFlowOutput(int index) {
        if (EdgesFlow.Count <= index || EdgesFlow[index] == null) return false;
        EdgesFlow[index].To.Node.Execute();
        return true;
    }
    
    public bool SetValue(int outputIndex, object value)
    {
        if (_edgesValuePerHandle.TryGetValue(outputIndex, out var edges))
        {
            if (edges == null) throw new Exception("Edges list is null");
            if (edges.Count == 0) return false;
            return edges.All(edge => edge.To.Node.Input.Set(edge.To.Index, value));
        }
        throw new Exception("Wrong output index when setting output value");
    }
    
    private void AddValueOutputEdge(int handleValue, IEdge edge)
    {
        if (edge.From.Node.IsPure)
            edge.To.Node.Input.SetPureNode(edge.To.Index, edge.From.Node);
        _edgesValuePerHandle[handleValue].Add(edge);
    }
    private void RemoveValueOutputEdge(int handleValue, IEdge edge)
    {
        if (edge.From.Node.IsPure)
            edge.To.Node.Input.ResetPureNode(edge.To.Index);
        _edgesValuePerHandle[handleValue].Remove(edge);
    }
    private void AddFlowOutputEdge(IEdge edge) => EdgesFlow[_handles.IndexOf(edge.From)] = edge;
    private void RemoveFlowOutputEdge(IEdge edge) => EdgesFlow[_handles.IndexOf(edge.From)] = null;
}