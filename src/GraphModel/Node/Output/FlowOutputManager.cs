using GraphModel.Handle.Flow;

namespace GraphModel.Node.Output;

public class FlowOutputManager(IEnumerable<OutputFlowHandle> outputs)
{
    private OutputFlowHandle GetHandle(string label) =>
        outputs.First(handle => handle.Label == label);
    
    public void Execute(string label) => GetHandle(label).SentExecutionFlow();
}