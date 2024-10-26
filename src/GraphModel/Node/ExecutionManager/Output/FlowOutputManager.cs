using GraphModel.Handle.Flow;

namespace GraphModel.Node.ExecutionManager.Output;

public class FlowOutputManager(IEnumerable<OutputFlowHandle> outputs)
{
    private OutputFlowHandle GetHandle(string label) =>
        outputs.FirstOrDefault(handle => handle.Label == label) ?? throw new HandleFlowNonexistentException(label);
    
    public void Execute(string label) => GetHandle(label).SentExecutionFlow();
}